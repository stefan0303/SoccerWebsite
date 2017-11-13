using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoccerWebsite;


public class CommandDispatcher
{
    public CommandDispatcher(string typeOfData, string[] dataArgs)
    {

        switch (typeOfData)
        {
            case "team":
             
                ImportTeam importTeam = new ImportTeam(dataArgs[0],dataArgs[1],dataArgs[2],dataArgs[3],dataArgs[4]);//CHeck!
                importTeam.Execute();
                break;
            case "game":
                break;
            case "town":
               
                string townName = dataArgs[0];
                string countryName = dataArgs[1];
                ImportTown importTown = new ImportTown(townName,countryName);
                importTown.Execute();
                break;
            case "country":
                ImportCountry importCountry = new ImportCountry(dataArgs[0]);
                importCountry.Execute();
                break;
            case "competition":
                ImportCompetition importCompetition = new ImportCompetition(dataArgs[0]);
                importCompetition.Execute();
                break;
            case "colours":
                ImportColour importColours = new ImportColour(dataArgs[0]);
                importColours.Execute();
                break;
                //Query
        }


    }
}

