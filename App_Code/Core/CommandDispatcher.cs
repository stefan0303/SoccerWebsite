using System;


public class CommandDispatcher
{
    public CommandDispatcher(string typeOfData, string[] dataArgs)
    {

        switch (typeOfData)
        {
            case "team":

                IImport importTeam = new ImportTeam(dataArgs[0], dataArgs[1],
                    dataArgs[2], dataArgs[3], dataArgs[4]);
                importTeam.Execute();
                break;

            case "game":
                string competition = dataArgs[0];
                string homeTeam = dataArgs[1];
                string awayTeam = dataArgs[2];
                int homeTeamGoals = int.Parse(dataArgs[3]);
                int awayTeamGoals = int.Parse(dataArgs[4]);
                DateTime dateOfGame = DateTime.Parse(dataArgs[5]);

                IImport importGames = new ImportGames(competition, homeTeam, awayTeam,
                    homeTeamGoals, awayTeamGoals, dateOfGame);
                importGames.Execute();
                break;

            case "town":

                string townName = dataArgs[0];
                string countryName = dataArgs[1];
                IImport importTown = new ImportTown(townName, countryName);
                importTown.Execute();
                break;

            case "country":
                IImport importCountry = new ImportCountry(dataArgs[0]);
                importCountry.Execute();
                break;

            case "competition":
                IImport importCompetition = new ImportCompetition(dataArgs[0]);
                importCompetition.Execute();
               
                break;

            case "colours":
                IImport importColours = new ImportColour(dataArgs[0]);
                importColours.Execute();
                break;
         
        }


    }
}

