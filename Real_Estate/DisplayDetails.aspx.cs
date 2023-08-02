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
using System.IO;
using System.Reflection.Emit;
using System.Xml.Linq;
using Label = System.Web.UI.WebControls.Label;

namespace Real_Estate
{
    public partial class DisplayDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Real_EstateConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetBuildingDet();
            }
        }

        public void GetBuildingDet()
        {
            SqlCommand SqlCmd = new SqlCommand("[dbo].[GetBuildingDetails]", con);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(SqlCmd);
            adapter.Fill(dt);
            gvBuildingDetails12.DataSource = dt;
            gvBuildingDetails12.DataBind();
            lblCount.Text = gvBuildingDetails12.Rows.Count.ToString();
        }
        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainForm.aspx");
        }

        protected void gvBuildingDetails12_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBuildingDetails12.EditIndex = e.NewEditIndex;
            GetBuildingDet();
        }
        protected void gvBuildingDetails12_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBuildingDetails12.Visible = true;
            gvBuildingDetails12.EditIndex = -1;
            GetBuildingDet();
        }

        protected void gvBuildingDetails12_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Label lblBuilding_ID = (Label)gvBuildingDetails12.Rows[e.RowIndex].FindControl("lblBuilding_ID") as Label;
            TextBox TextBuildingName = (TextBox)gvBuildingDetails12.Rows[e.RowIndex].FindControl("TextBuildingName") as TextBox;
            TextBox TextEmailid = (TextBox)gvBuildingDetails12.Rows[e.RowIndex].FindControl("TextEmailid") as TextBox;
            TextBox TextCountry = (TextBox)gvBuildingDetails12.Rows[e.RowIndex].FindControl("TextCountry") as TextBox;
            TextBox TextPrice = (TextBox)gvBuildingDetails12.Rows[e.RowIndex].FindControl("TextPrice") as TextBox;
            TextBox TextCarpetArea = (TextBox)gvBuildingDetails12.Rows[e.RowIndex].FindControl("TextCarpetArea") as TextBox;
            TextBox TextBuiltUpArea = (TextBox)gvBuildingDetails12.Rows[e.RowIndex].FindControl("TextBuiltUpArea") as TextBox;
            TextBox TextAddress = (TextBox)gvBuildingDetails12.Rows[e.RowIndex].FindControl("TextAddress") as TextBox;
            DropDownList ddlConfig_ID = (DropDownList)gvBuildingDetails12.Rows[e.RowIndex].FindControl("ddlConfig_ID") as DropDownList;
            // TextBox txtDescription = (TextBox)gvBuildingDetails12.Rows[e.RowIndex].FindControl("TextDecription") as TextBox;

            try
            {


                SqlCommand cmd = new SqlCommand("[dbo].[Updategridview]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Building_ID", Convert.ToInt32(lblBuilding_ID.Text));
                cmd.Parameters.AddWithValue("@BuildingName", TextBuildingName.Text);
                cmd.Parameters.AddWithValue("@Email_ID", TextEmailid.Text);
                cmd.Parameters.AddWithValue("@Country", TextCountry.Text);
                cmd.Parameters.AddWithValue("@Price", TextPrice.Text);

                cmd.Parameters.AddWithValue("@CarpetArea", TextCarpetArea.Text);
                cmd.Parameters.AddWithValue("@BuildingUpArea", TextBuiltUpArea.Text);
                cmd.Parameters.AddWithValue("@BuildingAddress", TextAddress.Text);
                cmd.Parameters.AddWithValue("@ConfigID", ddlConfig_ID.SelectedValue);
                //  cmd.Parameters.AddWithValue("@Description", txtDescription.Text);

                //  cmd.Parameters.AddWithValue("@BuildingID", Convert.ToInt32(lblBuildingID.Text));  
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                gvBuildingDetails12.EditIndex = -1;
                GetBuildingDet();



            }
            catch (Exception ex)
            {

            }
        }

        protected void gvBuildingDetails12_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblBuilding_ID = (Label)gvBuildingDetails12.Rows[e.RowIndex].FindControl("lblBuilding_ID");

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[DeleteBuildingDetails]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Building_ID", Convert.ToInt32(lblBuilding_ID.Text));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetBuildingDet();
            }
            catch (Exception ex)
            {

            }

        }

        protected void gvBuildingDetails12_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    con.Open();
                    DropDownList dropDownList = (e.Row.FindControl("ddlConfig_ID") as DropDownList);
                    SqlCommand cmd = new SqlCommand("[dbo].[BindConfigurationDropdown]", con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    con.Close();
                    dropDownList.DataSource = dt;
                    dropDownList.DataTextField = "ConfigName";
                    dropDownList.DataValueField = "ConfigID";
                    dropDownList.DataBind();
                    dropDownList.Items.Insert(0, new ListItem("Please Select"));
                    String Country = (e.Row.FindControl("lblConfig_ID") as HiddenField).Value;
                    dropDownList.Items.FindByValue(Country).Selected = true;
                }
            }
            catch (Exception ex)
            {

            }
        }


       

        

        protected void btnsearch_Click1(object sender, EventArgs e)
        {
            try
            {

                //  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RealEstateConnection"].ToString());
                SqlCommand cmd = new SqlCommand("[dbo].[GridviewSearch]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search",txtsearch.Text);
                con.Open();
                //  cmd.Parameters.AddWithValue("@Country", txtSearch.Text);
                //  DataSet ds = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    gvBuildingDetails12.DataSource = dt;
                    gvBuildingDetails12.DataBind();
                }
                con.Close() ;
            }
            catch (Exception ex)
            {
            }
        }

        protected void gvBuildingDetails12_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBuildingDetails12.PageIndex = e.NewPageIndex;
            this.GetBuildingDet();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment;filename=EmployeeDetails.xls");
            Response.ContentType = "application/excel";

            StringWriter stringwriter = new StringWriter();
            HtmlTextWriter htmtextwriter = new HtmlTextWriter(stringwriter);

            gvBuildingDetails12.HeaderRow.Style.Add("background-color", "#ffffff");

            foreach (TableCell tableCell in gvBuildingDetails12.HeaderRow.Cells)
            {
                tableCell.Style["background-color"] = "#ffffff";
            }

            foreach (GridViewRow gridviewrow in gvBuildingDetails12.Rows)
            {
                gridviewrow.BackColor = System.Drawing.Color.White;
                foreach (TableCell gridviewrowtablecell in gridviewrow.Cells)
                {
                    gridviewrowtablecell.Style["background-color"] = "#ffffff";
                }
            }

            gvBuildingDetails12.RenderControl(htmtextwriter);
            Response.Write(stringwriter.ToString());
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

    }


       

    }
   




