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
        if (Request.Form.Count > 0)
        {
            //Vzima vsichki formi dori koito ne mi triabvat! vzima i praznite poleta
            Console.WriteLine(Request.Form.AllKeys.Reverse().Count());
            string[] controls = Request.Form.AllKeys.Where(k=>k== "country").Reverse().Take(3).ToArray();//take only forms we need from page ??? can this be done in different way
            int n = Request.Form.AllKeys.Reverse().Count();
            foreach (var control in controls)
            {
                string dataArgs = String.Format("{0}", Request.Form[control]);
                if (dataArgs != "")
                {
                    CommandDispatcher service = new CommandDispatcher(control,dataArgs);
                   
                }
            }
            // string dataArgs = String.Format("{0}", Request.Form["country"]);//we get the data from site

        }
    }
}