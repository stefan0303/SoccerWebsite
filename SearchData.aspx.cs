using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class SearchData : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //SQL CONNECTION
        //SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //sql.Open();

        //SqlCommand cmd = sql.CreateCommand();

        //cmd.CommandType = System.Data.CommandType.Text;
        //Guid guid = Guid.NewGuid();
        //cmd.CommandText = $"insert into Country values ('{guid}','Varna')";
        //cmd.ExecuteNonQuery(); 
        //Response.Write("test213");
        //Response.End();

        //CONTEXT

        //SoccerContext context = new SoccerContext();
      
        //Guid guid = Guid.NewGuid();
        //Country country = new Country();
        //country.ui = guid;
        //country.Name = "testAdo.NEt3";
        //context.Countries.Add(country);
        //context.SaveChanges();
    }
}