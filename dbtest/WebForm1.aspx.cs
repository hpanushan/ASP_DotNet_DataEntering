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
                // Creating a stored procedure
                string spInsert = "CREATE PROCEDURE spAddNew @username varchar(50), @rollno varchar(50) AS BEGIN INSERT INTO userinfo (username,rollno) VALUES (@username,@rollno) END;";
                SqlCommand cmd1 = new SqlCommand(spInsert, con);
                cmd1.ExecuteNonQuery();
                ////
                // Adding a new row
                string insert = "Exec spAddNew @username, @rollno;";
                SqlCommand cmd2 = new SqlCommand(insert,con);
                cmd2.Parameters.AddWithValue("@username",TextBox1.Text);
                cmd2.Parameters.AddWithValue("@rollno",TextBox2.Text);
                cmd2.ExecuteNonQuery();
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