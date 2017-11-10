using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoccerWebsite;


public class CommandDispatcher
{
    public CommandDispatcher(string typeOfData, string dataArgs)
    {

        switch (typeOfData)
        {
            case "team":
                break;
            case "game":
                break;
            case "town":
                break;
            case "country":
                ImportCountry importCountry = new ImportCountry(dataArgs);
                importCountry.Execute();
                break;
            case "competition":
                ImportCompetition importCompetition = new ImportCompetition(dataArgs);
                importCompetition.Execute();
                break;
            case "colours":
                ImportColour importColours = new ImportColour(dataArgs);
                importColours.Execute();
                break;
                //Query
        }


    }
}

