using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Real_Estate
{
    public partial class loginPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Real_EstateConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand con1 = new SqlCommand("[dbo].[LoginPage]", con);
                con1.CommandType = CommandType.StoredProcedure;
                con1.Parameters.AddWithValue("@EmailID", txtUsername.Text);
                con1.Parameters.AddWithValue("@Password", txtpassword.Text);
                con.Open();
                SqlDataReader dr = con1.ExecuteReader();
                if (dr.Read())
                {
                    if ((dr["EmailID"].ToString() == txtUsername.Text.ToString()) && (dr["Password"].ToString() == txtpassword.Text.ToString()))
                    {
                        Label1.Text = "Login Sucess......!!";
                        Response.Redirect("DisplayDetails.aspx", false);
                        return;
                    }

                    //else
                    //{
                    //    Label1.Text = "UserId & Password Is not correct Try again..!!";
                    //}
                }
                else
                {
                    Label1.Text = "UserId & Password Is not correct Try again..!!";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    }
}

