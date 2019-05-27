using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace dbtest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString);
                con.Open();
                string insert = "insert into userinfo (username,rollno) values(@username,@rollno)";
                SqlCommand cmd = new SqlCommand(insert,con);
                cmd.Parameters.AddWithValue("@username",TextBox1.Text);
                cmd.Parameters.AddWithValue("@rollno",TextBox2.Text);
                cmd.ExecuteNonQuery();
                Response.Redirect("home.aspx");
                con.Close();
            }
            catch(Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}