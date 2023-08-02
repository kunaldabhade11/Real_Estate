using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;
using System.EnterpriseServices.Internal;
using System.Reflection.Emit;
using System.Web.Mail;
using System.Net.Mail;
using System.Net;
using MailMessage = System.Net.Mail.MailMessage;
using System.Activities.Statements;

namespace Real_Estate
{
    public partial class MainForm : System.Web.UI.Page
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Real_EstateConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Confbindiguration();
            }


        }

        //n1.Close();


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var result = this.checkBuildingNameAlreadyExists();
                if (result == true)
                {
                    Label1.Text = "Already Exsist";

                }
                else
                {
                    if (FileUpload.HasFile)
                    {
                        String fileName = FileUpload.FileName;
                        FileUpload.PostedFile.SaveAs(Server.MapPath("~/Building Image/" + fileName));
                        String imagePath = "~/Building Image/" + fileName.ToString();
                        SqlCommand cmd = new SqlCommand("[dbo].[InsertintoBuilding_Details]", con1);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BuildingName", txtBuildingName.Text);
                        cmd.Parameters.AddWithValue("@Price", TxtPrice.Text);
                        cmd.Parameters.AddWithValue("@Country", TxtCountry.Text);
                        cmd.Parameters.AddWithValue("@CarpetArea", TxtCarpetArea.Text);
                        cmd.Parameters.AddWithValue("@BuildingUpArea", TxtBuildingUpArea.Text);
                        cmd.Parameters.AddWithValue("@BuildingAddress", TxtBuildingAddress.Text);
                        cmd.Parameters.AddWithValue("@Email_ID", TextEmailid.Text);

                        cmd.Parameters.AddWithValue("@Description", txtDecription.Text);
                        cmd.Parameters.AddWithValue("@ConfigID", ddlConfiguration.SelectedValue);
                        cmd.Parameters.AddWithValue("@Image", imagePath);

                        con1.Open();
                        int i = cmd.ExecuteNonQuery();
                        con1.Close();
                        send_mail();
                        if (i == -1)
                        {

                            lbltxt.Text = "Inserted SuccessFully";
                           // Response.Redirect("DisplayDetails.aspx");
                            this.CleartextBox();
                        }
                        else
                        {
                            lbltxt.Text = "Something is Wring";
                        }

                    }
                    else
                    {

                    }

                }
                
            }
            catch (Exception ex)
            {
            }
            
        }

        public void CleartextBox()
        {
            txtBuildingName.Text = "";
            TxtPrice.Text = "";
            TxtCountry.Text = "";
            TxtCarpetArea.Text = "";
            TxtBuildingUpArea.Text = "";
            TxtBuildingAddress.Text = "";
            ddlConfiguration.SelectedValue = "0";
        }
        protected void Goto_GridView_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisplayDetails.aspx");
        }


        public void Confbindiguration()
        {
            SqlCommand SqlCmd = new SqlCommand("[dbo].[ConfigurationDdl]", con1);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(SqlCmd);
            adapter.Fill(dt);
            ddlConfiguration.DataSource = dt;
            ddlConfiguration.DataTextField = ("ConfigName");
            ddlConfiguration.DataValueField = ("ConfigID");
            ddlConfiguration.DataBind();
        }


        protected void txtBuildingName_TextChanged(object sender, EventArgs e)
        {

            this.checkBuildingNameAlreadyExists();
        }


        public bool checkBuildingNameAlreadyExists()
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand("[dbo].[duplicateValue]", con1);

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@BuildingName", txtBuildingName.Text);
                con1.Open();
                // SqlCmd.Parameters.Add("@BuildingName", SqlDbType.Int).Value = txtBuildingName;
                SqlDataReader rd = SqlCmd.ExecuteReader();
                while (rd.Read())
                {
                    Label1.Text = "";

                    if (rd["BuildingName"].ToString().ToLower() == txtBuildingName.Text.ToString().ToLower())

                    {
                        Label1.Visible = true;

                        Label1.Text = "Already Exists";

                        // break;
                        return true;

                    }

                }
                con1.Close();
                // return false;
            }
            catch (Exception ex)
            {

            }
            return false;
            

        }

        public void send_mail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(TextEmailid.Text);
                mail.From = new MailAddress("kunaldabhade11@gmail.com");
                mail.Subject = "Welcome Email";
                mail.Body = "Hello Welcome to Our Webpage,HAVE A NICE DAY";
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("masstechdev123@gmail.com", "zgsfkhdrykrarwfv");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                lbltxt.Text = "MAil Send Succesfully";
            }
            catch (Exception ex)
            {
                lbltxt.Text = "Mail Not Sent";
            }
        }
    }
}