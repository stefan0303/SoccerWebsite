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

public partial class _Default : Page
{
    private string data;
    private string[] dataArgs;
    private CommandDispatcher service;
    private static string checkData;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //if ("true".Equals(Request.Params["ajax_call"]))
            //{

            //    Response.Write(Request.Params["input"]);
            //    Response.End();
            //}
            //using (soccerContext context = new soccerContext())
            //{
            //    // Make the dropDown List of Counries names from Data
            //    DropDownCountry.DataSource = context.Countries.OrderBy(c => c.Name).ToList();
            //    DropDownCountry.DataTextField = "name";
            //    DropDownCountry.DataBind();

            //}
        
        }

    }

    [WebMethod]
    public static object DropDownCountries()
    {
        
        using (soccerContext context = new soccerContext())
        {
            // Make the dropDown List of Counries names from Data
            List<Country> competitions = context.Countries.OrderBy(c => c.Name).ToList();
            var objList = (new[] { new { Text = ""} }).ToList();
            foreach (var competition in competitions)
            {               
                objList.Add(new { Text = competition.Name});
            }
            objList = objList.Skip(1).ToList();
            return objList;

        }     

       
    }
   
    [System.Web.Services.WebMethod]

    public static string Competition(string competitionName)
    {
        checkData = CheckDataIsNotEmpty(competitionName, "Competition");

        if (checkData !="Ok")
        {
            return checkData;
        }

        try
        {
            using (soccerContext context = new soccerContext())
            {
                Competition competition = new Competition
                {
                    ui = Guid.NewGuid(),
                    Name = competitionName
                };
                context.Competitions.Add(competition);
                context.SaveChanges();
            }
            return $"Competition {competitionName} is add to data!";

        }
        catch (Exception)
        {
            return $"There is problem to add Competition {competitionName} ";
        }


    }
    [System.Web.Services.WebMethod]
    public static string Country(string countryName)
    {
        checkData = CheckDataIsNotEmpty(countryName, "Country");

        if (checkData != "Ok")
        {
            return checkData;
        }
        try
        {
            using (soccerContext context = new soccerContext())
            {
                Country country = new Country
                {
                    ui = Guid.NewGuid(),
                    Name = countryName,

                };
                context.Countries.Add(country);
                context.SaveChanges();
                return $"Country: {country.Name} is add to data!";
            }

        }
        catch (Exception)
        {

            return $"There is problem to add Competition {countryName} ";
        }
    
       
    }
    [System.Web.Services.WebMethod]
    public static string Town(string townName, string countryName)
    {
        checkData = CheckDataIsNotEmpty(townName, "Town");

        if (checkData != "Ok")
        {
            return checkData;
        }
        try
        {
            using (soccerContext context = new soccerContext())
            {
                var country = context.Countries.FirstOrDefault(c => c.Name == countryName);

                Town town = new Town
                {
                    ui = Guid.NewGuid(),
                    Country_ui =country.ui,
                    Name = townName
                };
                
                context.Towns.Add(town);
                context.SaveChanges();
                return $"Town: {town.Name} is add to data!";
            }

        }
        catch (Exception)
        {

            return $"There is problem to add Town {townName}  ";
        }

    }
  
   
    private static string CheckDataIsNotEmpty(string data, string typeOfData)
    {
        if (data == "")
        {
            return $"{typeOfData} can not be Empty!";
        }
        return "Ok";
    }
}
