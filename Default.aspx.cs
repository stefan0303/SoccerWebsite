using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Way to import Colors Dont need it now

        //if (Request.Form.Count > 0)
        //{
        //    //Every button is working only for data in that field
        //    string[] submitControl = Request.Form.AllKeys.Where(k => k == "submitColor").ToArray();
        //    //string[] nameOfColor = Request.Form.AllKeys.Where(k => k == "color").ToArray();
        //    if (Request.Form.Count > 0)
        //    {
        //      string  data = String.Format("{0}", Request.Form["color"]);
        //      string[]  dataArgs = new string[] { data };
        //      CommandDispatcher  service = new CommandDispatcher("colours", dataArgs);

        //    }
        //}
    }
}