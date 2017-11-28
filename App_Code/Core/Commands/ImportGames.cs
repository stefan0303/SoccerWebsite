using Models;
using System;
using System.Linq;



internal class ImportGames : IImport
{
    private string competition;
    private string homeTeam;
    private string awayTeam;
    private int homeTeamGoals;
    private int awayTeamGoals;
    private DateTime dateOfGame;

    public ImportGames(string competition, string homeTeam,
        string awayTeam, int homeTeamGoals, int awayTeamGoals, DateTime dateOfGame)
    {
        this.competition = competition;
        this.homeTeam = homeTeam;
        this.awayTeam = awayTeam;
        this.homeTeamGoals = homeTeamGoals;
        this.awayTeamGoals = awayTeamGoals;
        this.dateOfGame = dateOfGame;
    }
    public void Execute()
    {
        Game game = new Game
        {
            ui = Guid.NewGuid()
        };

        using (soccerContext context = new soccerContext())
        {
            Competition competitionData = context.Competitions.FirstOrDefault(c => c.Name == competition);
            Team teamHomeData = context.Teams.FirstOrDefault(t => t.Name == homeTeam);
            Team teamAwayData = context.Teams.FirstOrDefault(t => t.Name == awayTeam);

            game.Competition_ui = competitionData.ui;
            game.HomeTeam_ui = teamHomeData.ui;
            game.AwayTeam_ui = teamAwayData.ui;
            game.HomeTeamGoals = homeTeamGoals;
            game.AwayTeamGoals = awayTeamGoals;
            game.Date = dateOfGame.Date;

            try
            {
                context.Games.Add(game);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw new ArgumentException("There is problem with Games Import!");
            }
            
        }
    }

    
}