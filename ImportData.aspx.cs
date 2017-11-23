using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ImportData : Page
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
        if (Request.Form.Count > 0)
        {
            //Every button is working only for data in that field
            string[] submitControl = Request.Form.AllKeys.Where(k => k == "competitionSubmit" && k != "" || (k == "countrySubmit" && k != "") || (k == "townSubmit" && k != "")).ToArray();

            //Todo check is the string empty make first letter uppercase no numbers!
            switch (submitControl[0])
            {
                case "competitionSubmit":
                    data = String.Format("{0}", Request.Form["competition"]);
                    dataArgs = new string[] { data };
                    service = new CommandDispatcher("competition", dataArgs);
                    break;
                case "countrySubmit":
                    data = String.Format("{0}", Request.Form["country"]);
                    dataArgs = new string[] { data };
                    service = new CommandDispatcher("country", dataArgs);
                    break;
                case "townSubmit":
                    data = String.Format("{0}", Request.Form["town"]);
                    string countryName = String.Format("{0}", Request.Form["ctl00$MainContent$DropDownCountry"]);
                    dataArgs = new string[] { data, countryName };
                    service = new CommandDispatcher("town", dataArgs);
                    break;
            }

        }
    }
}