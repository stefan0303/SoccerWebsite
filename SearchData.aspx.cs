using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using Models;

public partial class SearchData : Page
{
    private string newCompetitionValue;
    protected void Page_Load(object sender, EventArgs e)
    {
        using (soccerContext context = new soccerContext())
        {

            //Competitions Drop Down
            string valueCompetition = DropDownListCompetitions.SelectedValue;
            this.newCompetitionValue = valueCompetition;

            DropDownListCompetitions.DataSource = context.Competitions.OrderBy(c => c.Name).ToList();
            DropDownListCompetitions.DataTextField = "name";

            DropDownListCompetitions.DataBind();
            DropDownListCompetitions.Items.Insert(0, new ListItem(String.Empty, String.Empty));



        }
    }
    public string getWhileLoopData()
    {
        string htmlStr = "";

        List<Team> teams = new List<Team>();
        List<Game> games = new List<Game>();

        using (soccerContext context = new soccerContext())
        {
            //List of teams in that competition
            Competition competition = context.Competitions.FirstOrDefault(c => c.Name == newCompetitionValue);
            if (competition!=null)//just for test this if construction
            {
                teams = context.Teams.Where(t => t.Competition.Name == newCompetitionValue).ToList();//List of teams in this Competition
                games = context.Games.Where(g => g.Competition_ui == competition.ui).ToList();//List of games in this competition
            }
           

        }

        Dictionary<Team, List<Game>> teamGames = new Dictionary<Team, List<Game>>();
        Dictionary<Team, int> teamPoints = new Dictionary<Team, int>();

        int points = 0;
        int possition = 0;
        string teamName = "";
        int wins = 0;
        int draws = 0;
        int loses = 0;

        int scoredGoals = 0;
        int receivedGoals = 0;
        string goalDifference = "";
       

        foreach (var team in teams)
        {
            teamGames.Add(team, new List<Game>());//add key Team
            teamPoints.Add(team, 0);//Add team with zero points
            foreach (var game in games)
            {
                if (game.HomeTeam_ui == team.ui)//find is the team playing in this game and its home team
                {
                    scoredGoals += game.HomeTeamGoals;// add scored Goals
                    receivedGoals += game.AwayTeamGoals;//add received Goals
                    if (game.HomeTeamGoals > game.AwayTeamGoals)//Our team is winner we give 3 points
                    {
                        points += 3;
                        wins += 1;
                    }
                    else if(game.HomeTeamGoals == game.AwayTeamGoals)//Draw 1 points
                    {
                        points += 1;
                        draws += 1;
                    }
                    else//Team lose 0 points , one loose
                    {
                        loses += 1;
                    }

                }
                else if (game.AwayTeam_ui == team.ui)//find is the team playing in this game and its away  team
                {
                    scoredGoals += game.AwayTeamGoals;// add scored Goals
                    receivedGoals += game.HomeTeamGoals;//add received Goals


                    //To Do !!!!!!!!!!!!!!!!!
                }

            }

            htmlStr += "<tr><td>" + possition + "</td><td>" + teamName + "</td><td>" + wins +
                "</td><td>" + draws + "</td><td>" + loses + "</td><td>" + goalDifference + "</td><td>" + points + "</td><tr>";
        }

        
        htmlStr += "<tr><td>" + possition + "</td><td>" + teamName + "</td><td>" + wins +
            "</td><td>" + draws + "</td><td>" + loses + "</td><td>" + goalDifference + "</td><td>" + points + "</td><tr>";


        return htmlStr;

    }


    protected void DropDownList_SelectedIndexChaged(object sender, EventArgs e)
    {

        DropDownListCompetitions.SelectedValue = newCompetitionValue;
        DropDownListCompetitions.DataBind();

        using (soccerContext context = new soccerContext())
        {



        }
    }
}