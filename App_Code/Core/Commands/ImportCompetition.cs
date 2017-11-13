﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ImportCompetition
/// </summary>
public class ImportCompetition : System.Web.UI.Page
{
    private string competitionName;
    public ImportCompetition(string dataArgs)
    {
        this.competitionName = dataArgs;
    }
    public void Execute()
    {
        Competition competition = new Competition();
        soccerContext context = new soccerContext();
        competition.ui = Guid.NewGuid();
        competition.Name = competitionName;
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