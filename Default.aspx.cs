using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using Models;

public partial class Default : Page
{
    private string data;
    private string[] dataArgs;
    private CommandDispatcher service;
    private static string checkData;

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
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
   
    [WebMethod]

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
    [WebMethod]
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
    [WebMethod]
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


