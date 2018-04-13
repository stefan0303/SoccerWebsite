using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

public partial class ImportTeams : System.Web.UI.Page
{
    Dictionary<Guid, string> countries = new Dictionary<Guid, string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        using (soccerContext context = new soccerContext())
        {
            countries = context.Countries.Select(c => new { c.ui, c.Name }).ToDictionary(c => c.ui, c => c.Name);
        }

        //Make the dropDown List from Enum Class order by colour name
        DropDownListPrimaryKitColour.DataSource = Enumeration.GetAll<EnumColor>().OrderBy(c => c.Value);
        DropDownListPrimaryKitColour.DataTextField = "Value";
        DropDownListPrimaryKitColour.DataValueField = "Key";

        //Make the dropDown List from Enum Class order by colour name
        DropDownListSecondaryKitColour.DataSource = Enumeration.GetAll<EnumColor>().OrderBy(c => c.Value);
        DropDownListSecondaryKitColour.DataTextField = "Value";
        DropDownListSecondaryKitColour.DataValueField = "Key";

        DropDownListPrimaryKitColour.DataBind();
        DropDownListSecondaryKitColour.DataBind();
          
        using (soccerContext context = new soccerContext())
        {
            //Make the dropDown List from Competitions Data
            DropDownCompetitions.DataSource = context.Competitions.OrderBy(c => c.Name).ToList();
            DropDownCompetitions.DataTextField = "name";
            DropDownCompetitions.DataBind();

            //Make the dropDown List from Town Data
            DropDownTowns.DataSource = context.Towns.OrderBy(c => c.Name).ToList();
            DropDownTowns.DataTextField = "name";
            DropDownTowns.DataBind();


            //Get The new Team Name and import it to data
        }
        //if (Request.Form.Count > 0)
        //{
        //    string nameOfTeam = Request.Form["team"];
        //    string[] controls = Request.Form.AllKeys.Reverse().Take(5).ToArray();
        //    if (nameOfTeam != null && nameOfTeam != "")
        //    {
        //        string competition = Request.Form["ctl00$MainContent$DropDownCompetitions"];
        //        string town = Request.Form["ctl00$MainContent$DropDownTowns"];
        //        //there can be the same primary and secondary kit colour
        //        string primaryKitColour = Request.Form["ctl00$MainContent$DropDownListPrimaryKitColour"];
        //        string secondaryKitColour = Request.Form["ctl00$MainContent$DropDownListSecondaryKitColour"];
        //        if (primaryKitColour==secondaryKitColour)
        //        {
        //            throw new ArgumentException("Primary kit colour and secondary kit colour can not be the same");
        //        }
        //        //ToDO if Any is blanc like Select Competition or Select Town Throw Exeption
        //        string[] dataArgs = new string[] { nameOfTeam, competition, town, primaryKitColour, secondaryKitColour };
                

        //        CommandDispatcher commandDispatcher = new CommandDispatcher("team", dataArgs);

        //    }
        //    else
        //    {
        //        throw new ArgumentException("The Team Name is null or Empty");//ToDo this is not for here
        //    }
        //}
    }
    [WebMethod]
    public static string ImportTeam(string teamName,string competitionName,
        string townName, string primaryKitColour, string secondaryKitColour)
    {
        try
        {
            string[] dataArgs = new string[] { teamName, competitionName, townName, primaryKitColour, secondaryKitColour };
            CommandDispatcher importTeam = new CommandDispatcher("team", dataArgs);
            return $"{teamName} is add to data!";
        }
        catch (Exception)
        {

            return "There is problem with team";
        }
       
    }

    public void GetCountriesSelectOptions()
    {
        using (soccerContext context = new soccerContext())
        {
            Dictionary<Guid, string> countries = context.Countries.Select(c => new { c.ui, c.Name }).ToDictionary(c => c.ui, c => c.Name);

            foreach (var country in countries)
            {
                Response.Write(String.Format(@"<option val=""{0}"">{1}</option>", country.Key, country.Value));
            }
        }
    }
   
}