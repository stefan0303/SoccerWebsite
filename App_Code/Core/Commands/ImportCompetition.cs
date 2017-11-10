using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ImportCompetition
/// </summary>
public class ImportCompetition : System.Web.UI.Page
{
    private string data;
    public ImportCompetition(string dataArgs)
    {
        this.data = dataArgs;
    }
    public void Execute()
    {
        Competition competition = new Competition();
        soccerContext context = new soccerContext();
        competition.ui = Guid.NewGuid();
        competition.Name = data;
        try
        {
            context.Competitions.Add(competition);
            context.SaveChanges();
            //Working!
        }
        catch (Exception)
        {

            throw new ArgumentException("There is such Competition name!");
        }
       

    }
}