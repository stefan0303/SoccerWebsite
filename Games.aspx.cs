using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class Games : System.Web.UI.Page
{
    string name = "Test";
}
    public partial class Games : System.Web.UI.Page
{
    private string newValue;
  

    protected void Page_Load(object sender, EventArgs e)
    {
        
        using (soccerContext context = new soccerContext())
        {
            string test = name;
            //Competitions Drop Down
            string valueCompetition = DropDownListCompetitions.SelectedValue;
            this.newValue = valueCompetition;


            // TODO: set val to database ui 
            DropDownListCompetitions.DataSource = context.Competitions.OrderBy(c => c.Name).ToList();
            DropDownListCompetitions.DataTextField = "name";
            DropDownListCompetitions.DataValueField = "ui";//!!

            DropDownListCompetitions.DataBind();
            DropDownListCompetitions.Items.Insert(0, new ListItem(String.Empty, String.Empty));


            DropDownListHomeTeam.DataSource = context.Teams.Where(t => t.Competition.Name == newValue).OrderBy(t => t.Name).ToList();
            DropDownListHomeTeam.DataTextField = "name";
            DropDownListHomeTeam.DataBind();
            DropDownListHomeTeam.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            DropDownListHomeTeam.Attributes.Add("disabled", "true");

            DropDownListAwayTeam.DataSource = context.Teams.Where(t => t.Competition.Name == newValue).OrderBy(t => t.Name).ToList();
            DropDownListAwayTeam.DataTextField = "name";
            DropDownListAwayTeam.DataBind();
            DropDownListAwayTeam.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            DropDownListAwayTeam.Attributes.Add("disabled", "true");

            // Team Goals

            DropDownListHomeTeamGoals.Items.AddRange(Enumerable.Range(0, 21).Select(m => new ListItem(m.ToString())).ToArray());
            DropDownListHomeTeamGoals.DataTextField = "name";
            DropDownListHomeTeamGoals.DataBind();
            //DropDownListHomeTeamGoals.Attributes.Add("disabled", "true");

            DropDownListAwayTeamGoals.Items.AddRange(Enumerable.Range(0, 21).Select(m => new ListItem(m.ToString())).ToArray());
            DropDownListAwayTeamGoals.DataTextField = "name";
            DropDownListAwayTeamGoals.DataBind();
            //DropDownListAwayTeamGoals.Attributes.Add("disabled", "true");

        }

        //string[] controls = Request.Form.AllKeys.Reverse().Take(50).ToArray();
        //if (Request.Form.Count > 0 && !controls.Any(c => c == "") && controls[0] == "submitGames")
        //{
        //    string competition = Request.Form["ctl00$MainContent$DropDownListCompetitions"];
          

        //    string homeTeam = Request.Form["ctl00$MainContent$DropDownListHomeTeam"];
        //    string awayTeam = Request.Form["ctl00$MainContent$DropDownListAwayTeam"];
        //    if (homeTeam==awayTeam)
        //    {
        //        throw new ArgumentException("Home and Away team cannot have same name!");
             
        //    }
        //    string homeTeamGoals = Request.Form["ctl00$MainContent$DropDownListHomeTeamGoals"];
        //    string awayTeamGoals = Request.Form["ctl00$MainContent$DropDownListAwayTeamGoals"];
        //    if (homeTeamGoals==""||awayTeamGoals=="")
        //    {
        //        throw new ArgumentException("Home team and Away team goals can not be empty!");
        //    }
        //    string dateOfGame = Request.Form["ctl00$MainContent$TxtDob"];          

        //    string[] dataArgs = new string[] { competition, homeTeam, awayTeam, homeTeamGoals, awayTeamGoals, dateOfGame };
        //    CommandDispatcher commandDispatcher = new CommandDispatcher("game", dataArgs);
        //}
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
            DropDownListAwayTeam.Attributes.Add("disabled", "true");


            DropDownListAwayTeam.DataSource = context.Teams.Where(t => t.Competition.Name == newValue    ).OrderBy(t => t.Name).ToList();
            DropDownListAwayTeam.DataTextField = "name";
            DropDownListAwayTeam.DataBind();
            DropDownListAwayTeam.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            DropDownListAwayTeam.Attributes.Add("disabled", "true");

           


        }
    }
    [WebMethod]
    public static string AddGameToData(string competition, string homeTeam,string awayTeam,
        string homeTeamGoals, string awayTeamGoals, string dateOfGame)
    {

        string[] dataArgs = new string[] { competition, homeTeam, awayTeam, homeTeamGoals, awayTeamGoals, dateOfGame };
       CommandDispatcher commandDispatcher = new CommandDispatcher("game", dataArgs);
        
        return $"{competition} {homeTeam} {awayTeam} {homeTeamGoals} {awayTeamGoals} {dateOfGame}";
    }
    [WebMethod]
    public static string TeamsFromSelectedCompetition(string competitionUi)
    {
        // TODO: ako iskash da go napravish po-vnimatelno
        //Guid parseGuid = new Guid();
        //if (!Guid.TryParse(competitionUi, out parseGuid))
        //{
        //    return "error"; //tuka nekuv error, deto javascripta moje da go pokaje
        //}
        StringBuilder teamsDropDownOptionsMarkUp = new StringBuilder();
        using (soccerContext context = new soccerContext())
        {
            Dictionary<Guid, string> teams = context.Teams.Where(t=>t.Competition.ui == new Guid(competitionUi)).Select(t => new { t.ui, t.Name }).ToDictionary(t => t.ui, t => t.Name);
            foreach (var team in teams)
            {
                  teamsDropDownOptionsMarkUp.Append($"<option value=\"{team.Key}\">{team.Value}</option>");
                //teamsDropDownOptionsMarkUp.AppendFormat(@"<option value=""{0}"">{1}</option>", team.Key, team.Value);
                //teamForAjax += team.Value+"\n";
            }
            return teamsDropDownOptionsMarkUp.ToString();
        }
    }
}

