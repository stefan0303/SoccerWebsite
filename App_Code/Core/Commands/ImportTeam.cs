using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ImportTeam
{
    private string teamName;
    private string competitionName;
    private string townName;
    private string primaryColour;
    private string secondaryColour;

    public ImportTeam(string teamName, string competitionName, string townName,
        string primaryColour, string secondaryColour)
    {
        this.teamName = teamName;
        this.competitionName = competitionName;
        this.townName = townName;
        this.primaryColour = primaryColour;
        this.secondaryColour = secondaryColour;
    }

    public void Execute()
    {
        Team team = new Team();
        team.Name = teamName;
        team.ui = Guid.NewGuid();


        using (soccerContext context = new soccerContext())
        {

            Competition competition = context.Competitions.FirstOrDefault(c => c.Name == competitionName);
            //competition.Teams.Add(team);

            Town town = context.Towns.FirstOrDefault(t => t.Name == townName);
            //town.Teams.Add(team);
            team.Competition_ui = competition.ui;
            team.Town_ui = town.ui;
            int idFirst = int.Parse(primaryColour);
            int idSecond = int.Parse(secondaryColour);
            Colour colourOne= context.Colours.FirstOrDefault(c => c.Name == idFirst);
            Colour colourTwo = context.Colours.FirstOrDefault(c => c.Name == idSecond);
         
            team.Colour= colourOne;           
            team.Colour1= colourTwo;

            try
            {
                context.Teams.Add(team);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw new ArgumentException("There is such team in data");
            }
          
        }

        // Colour colour = context.Colours.FirstOrDefault(c => c.Name == 1);

    }

}
