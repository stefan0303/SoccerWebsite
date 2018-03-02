using Models;
using System;


internal class ImportCompetition : System.Web.UI.Page, IImport
{
    private string competitionName;
    public ImportCompetition(string dataArgs)
    {
        this.competitionName = dataArgs;
    }
    public void Execute()
    {
        Competition competition = new Competition
        {
            ui = Guid.NewGuid(),
            Name = competitionName
        };
        try
        {
            using (soccerContext context = new soccerContext())
            {
                context.Competitions.Add(competition);
                context.SaveChanges();
            }

            //Working!
        }
        catch (Exception)
        {

            throw new ArgumentException("There is such Competition name!");
        }
        

    }
  
}