using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
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

        protected void DropDownList_SelectedIndexChaged(object sender, EventArgs e)
    {

        DropDownListCompetitions.SelectedValue = newCompetitionValue;
        DropDownListCompetitions.DataBind();


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
            if (competition != null)
            {
                teams = context.Teams.Where(t => t.Competition.Name == newCompetitionValue).ToList();//List of teams in this Competition
                games = context.Games.Where(g => g.Competition_ui == competition.ui).ToList();//List of games in this competition
            }


        }

        Dictionary<Team, List<Game>> teamGames = new Dictionary<Team, List<Game>>();
        Dictionary<Team, List<int>> teamPoints = new Dictionary<Team, List<int>>();

        int points = 0;
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
            teamPoints.Add(team,new List<int>());//Add team with zero points
            teamName = team.Name;
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
                    else if (game.HomeTeamGoals == game.AwayTeamGoals)//Draw 1 points
                    {
                        points += 1;
                        draws += 1;
                    }
                    else if (game.HomeTeamGoals < game.AwayTeamGoals)//Team lose 0 points , one loose
                    {
                        loses += 1;
                    }

                }
                else if (game.AwayTeam_ui == team.ui)//find is the team playing in this game and its away  team
                {
                    scoredGoals += game.AwayTeamGoals;// add scored Goals
                    receivedGoals += game.HomeTeamGoals;//add received Goals
                    if (game.HomeTeamGoals < game.AwayTeamGoals)//Our team is winner we give 3 points
                    {
                        points += 3;
                        wins += 1;
                    }
                    else if (game.HomeTeamGoals == game.AwayTeamGoals)//Draw 1 points
                    {
                        points += 1;
                        draws += 1;
                    }
                    else if (game.HomeTeamGoals > game.AwayTeamGoals)//Team lose 0 points , one loose
                    {
                        loses += 1;
                    }

                }

            }
            teamPoints[team].Add( points);
            teamPoints[team].Add(wins);
            teamPoints[team].Add(draws);
            teamPoints[team].Add(loses);
            teamPoints[team].Add(scoredGoals);
            teamPoints[team].Add(receivedGoals);
          

            points = 0;    
            teamName = "";
            wins = 0;
            draws = 0;
            loses = 0;

            scoredGoals = 0;
            receivedGoals = 0;
            goalDifference = "";
        }
        int possition = 1;
        foreach (var team in teamPoints.OrderByDescending(t=>t.Value[0]))
        {
            goalDifference = (team.Value[4] + "/" + team.Value[5] + "(" + (team.Value[4] - team.Value[5]) + ")").ToString();
            htmlStr += "<tr><td>" + possition + "</td><td>" + team.Key.Name + "</td><td>" + team.Value[1] +
                  "</td><td>" + team.Value[2] + "</td><td>" + team.Value[3] + "</td><td>" + goalDifference + "</td><td>" + team.Value[0] + "</td><tr>";

            possition++;
           

        }

        return htmlStr;
    }
   

   
}