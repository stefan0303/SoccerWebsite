using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Games : System.Web.UI.Page
{
    private string newValue;
    protected void Page_Load(object sender, EventArgs e)
    {

        using (soccerContext context = new soccerContext())
        {

            //Competitions Drop Down
            string valueCompetition = DropDownListCompetitions.SelectedValue;
            this.newValue = valueCompetition;
            
            DropDownListCompetitions.DataSource = context.Competitions.OrderBy(c => c.Name).ToList();
            DropDownListCompetitions.DataTextField = "name";
            
            DropDownListCompetitions.DataBind();
            DropDownListCompetitions.Items.Insert(0, new ListItem(String.Empty, String.Empty));

            DropDownListHomeTeam.DataSource = context.Teams.Where(t => t.Competition.Name == newValue).OrderBy(t => t.Name).ToList();
            DropDownListHomeTeam.DataTextField = "name";
            DropDownListHomeTeam.DataBind();
            DropDownListHomeTeam.Items.Insert(0, new ListItem(String.Empty, String.Empty));

            DropDownListAwayTeam.DataSource = context.Teams.Where(t => t.Competition.Name == newValue).OrderBy(t => t.Name).ToList();
            DropDownListAwayTeam.DataTextField = "name";
            DropDownListAwayTeam.DataBind();
            DropDownListAwayTeam.Items.Insert(0, new ListItem(String.Empty, String.Empty));

        }
        //ToDo Check is all data is correct
        string[] controls = Request.Form.AllKeys.Reverse().Take(50).ToArray();
        if (Request.Form.Count > 0 && !controls.Any(c => c == "") && controls[0] == "submitGames")
        {
            string competition = Request.Form["ctl00$MainContent$DropDownListCompetitions"];
          

            string homeTeam = Request.Form["ctl00$MainContent$DropDownListHomeTeam"];
            string awayTeam = Request.Form["ctl00$MainContent$DropDownListAwayTeam"];
            if (homeTeam==awayTeam)
            {
                throw new ArgumentException("Home and Away team cannot have same name!");
                //Response.Write("error");
            }
            string homeTeamGoals = Request.Form["ctl00$MainContent$DropDownListHomeTeamGoals"];
            string awayTeamGoals = Request.Form["ctl00$MainContent$DropDownListAwayTeamGoals"];
            if (homeTeamGoals==""||awayTeamGoals=="")
            {
                throw new ArgumentException("Home team and Away team goals can not be empty!");
            }
            string dateOfGame = Request.Form["ctl00$MainContent$TxtDob"];
            // DateTime date = DateTime.Parse(dateOfGame);

            string[] dataArgs = new string[] { competition, homeTeam, awayTeam, homeTeamGoals, awayTeamGoals, dateOfGame };
            CommandDispatcher commandDispatcher = new CommandDispatcher("game", dataArgs);
        }
    }
    protected void DropDownList_SelectedIndexChaged(object sender, EventArgs e)
    {
        
        DropDownListCompetitions.SelectedValue = newValue;
        DropDownListCompetitions.DataBind();

        using (soccerContext context =new soccerContext())
        {
            //Teams Drop Down 
          
            DropDownListHomeTeam.DataSource = context.Teams.Where(t => t.Competition.Name == newValue).OrderBy(t => t.Name).ToList();
            DropDownListHomeTeam.DataTextField = "name";
            DropDownListHomeTeam.DataBind();
            DropDownListHomeTeam.Items.Insert(0, new ListItem(String.Empty, String.Empty));

       
            DropDownListAwayTeam.DataSource = context.Teams.Where(t => t.Competition.Name == newValue    ).OrderBy(t => t.Name).ToList();
            DropDownListAwayTeam.DataTextField = "name";
            DropDownListAwayTeam.DataBind();
            DropDownListAwayTeam.Items.Insert(0, new ListItem(String.Empty, String.Empty));

            // Team Goals

            DropDownListHomeTeamGoals.Items.AddRange(Enumerable.Range(0, 21).Select(m => new ListItem(m.ToString())).ToArray());
            DropDownListHomeTeamGoals.DataTextField = "name";
            DropDownListHomeTeamGoals.DataBind();

            
            DropDownListAwayTeamGoals.Items.AddRange(Enumerable.Range(0, 21).Select(m => new ListItem(m.ToString())).ToArray());
            DropDownListAwayTeamGoals.DataTextField = "name";
            DropDownListAwayTeamGoals.DataBind();

            
        }
    }
}

