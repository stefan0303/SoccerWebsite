using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class _Default : Page
{
    private string data;
    private string[] dataArgs;
    private CommandDispatcher service;

    protected void Page_Load(object sender, EventArgs e)
    {
        using (soccerContext context = new soccerContext())
        {
            //Make the dropDown List of Counries names from Data
            DropDownCountry.DataSource = context.Countries.OrderBy(c => c.Name).ToList();
            DropDownCountry.DataTextField = "name";
            DropDownCountry.DataBind();

        }
    }
    public void OnClick_Competition(object sender, EventArgs e)
    {
        this.data = String.Format("{0}", Request.Form["competition"]);
        if (CheckDataIsNotEmpty(this.data) == true)
        {
            dataArgs = new string[] { data };
            service = new CommandDispatcher("competition", dataArgs);
        }
            
       
    }
    public void OnClick_Country(object sender, EventArgs e)
    {

        data = String.Format("{0}", Request.Form["country"]);
        if (CheckDataIsNotEmpty(this.data) == true)
        {
            dataArgs = new string[] { data };
            service = new CommandDispatcher("country", dataArgs);
        }

    }
    public void OnClick_Town(object sender, EventArgs e)
    {

        this.data = String.Format("{0}", Request.Form["town"]);
        if (CheckDataIsNotEmpty(this.data) == true)
        {
            string countryName = String.Format("{0}", Request.Form["ctl00$MainContent$DropDownCountry"]);
            dataArgs = new string[] { data, countryName };
            service = new CommandDispatcher("town", dataArgs);
        }

    }
    private bool CheckDataIsNotEmpty(string data)
    {
        if (data == "")
        {
            return false;
        }
        return true;
    }
}