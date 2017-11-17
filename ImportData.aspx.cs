using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ImportData : Page
{
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

            //Vzima vsichki formi dori koito ne mi triabvat! vzima i praznite poleta

            //string[] controls = Request.Form.AllKeys.Where(c=>c== "countryInput" || c=="town").Reverse().Take(7).ToArray();//take only forms we need from page ??? can this be done in different way
            string[] controls = Request.Form.AllKeys.Reverse().Take(15).ToArray();//take only forms we need from page ??? can this be done in different way
           
            // string countryName = String.Format("{0}", Request.Form["ctl00$MainContent$DropDownCountry"]);*///get argument in dropDown menu to add later town in data

            
            foreach (var control in controls)
            {
                string data = String.Format("{0}", Request.Form[control]);
                string[] dataArgs = new string[] { data };

                //can make a regex for dataArgs (no spaces in words, no numbers, make first letter Uppercase for Competition,Country and Town)
                if (dataArgs.Length > 0 && control != "town" && data != "")
                {
                    CommandDispatcher service = new CommandDispatcher(control, dataArgs);

                }
                if (control == "town" && dataArgs[0] != "")
                {
                    string countryName = String.Format("{0}", Request.Form["countryInput"]); ///get argument in dropDown menu to add later town in data
                    dataArgs = new string[] { data, countryName };
                    CommandDispatcher service = new CommandDispatcher(control, dataArgs);
                }             
            }
        }
    }
}