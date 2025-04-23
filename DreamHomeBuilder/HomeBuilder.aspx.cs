using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Globalization;
using System.Diagnostics;

namespace DreamHomeBuilder
{
    public partial class HomeBuilder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //connects to database and puts the homeplan table data to gridview
                DBConnect dBConnect = new DBConnect();
                DataSet myData = dBConnect.GetDataSet("SELECT * FROM HomePlans");

                gvHomes.DataSource = myData;
                gvHomes.DataBind();

                DBConnect dBConnect2 = new DBConnect();
                DataSet myData2 = dBConnect2.GetDataSet("SELECT * FROM RoofingMaterialOptions");

                gvRoofing.DataSource = myData2;
                gvRoofing.DataBind();

                DBConnect dBConnect3 = new DBConnect();
                DataSet myData3 = dBConnect3.GetDataSet("SELECT * FROM CountertopOptions");
                gvCountertop.DataSource = myData3;
                gvCountertop.DataBind();

                DBConnect dBConnect4 = new DBConnect();
                DataSet myData4 = dBConnect4.GetDataSet("SELECT * FROM HomeAdditions");
                gvHomeAdditions.DataSource = myData4;
                gvHomeAdditions.DataBind();

                //default selections for homeplan, roofing, countertop, and flooring so we don't have to validate
                GridViewRow defaultHome = gvHomes.Rows[0];
                lblSelectedHomePlan.Text = defaultHome.Cells[0].Text;
                string imageUrl = gvHomes.DataKeys[0].Value.ToString();
                Image img = (Image)FindControl("homeImage");
                img.ImageUrl = imageUrl;

                GridViewRow defaultRoofing = gvRoofing.Rows[0];
                lblSelectedRoofing.Text = defaultRoofing.Cells[0].Text;

                GridViewRow defaultCountertop = gvCountertop.Rows[0];
                lblSelectedCountertop.Text = defaultCountertop.Cells[0].Text;
            }
            else
            {
                
            }
        }

        protected void gvHomes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectHomePlan")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString()); //finds the selected row
                GridViewRow row = gvHomes.Rows[index];

                string imageUrl = gvHomes.DataKeys[index].Value.ToString(); //url for house image

                lblSelectedHomePlan.Text = row.Cells[0].Text; //puts the selected homeplan into the label
                Image img = (Image)FindControl("homeImage");
                img.ImageUrl = imageUrl;
                

            }
        }

        protected void gvRoofing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectRoofing")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString()); //finds the selected row
                GridViewRow row = gvRoofing.Rows[index];

                lblSelectedRoofing.Text = row.Cells[0].Text; //puts the selected homeplan into the label
                
            }
        }

        protected void gvCountertop_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectCountertop")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString()); //finds the selected row
                GridViewRow row = gvCountertop.Rows[index];

                lblSelectedCountertop.Text = row.Cells[0].Text; //puts the selected homeplan into the label
            }
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            
            ArrayList arrAdditions = new ArrayList();
            //ArrayList arrTotal = new ArrayList();

            for (int row = 0; row < gvHomeAdditions.Rows.Count; row++)
            {
                CheckBox CBox;

                CBox = (CheckBox)gvHomeAdditions.Rows[row].FindControl("chkAdditionSelect");

                if (CBox.Checked)
                {
                    String additions = "";
                    String prices = "";
                    char clean = '$';

                    additions = gvHomeAdditions.Rows[row].Cells[1].Text;
                    arrAdditions.Add(additions);
                    //prices = gvHomeAdditions.Rows[row].Cells[3].Text.Trim(clean);
                    //arrTotal.Add(prices);
                }
            }
        
            Session["bName"] = txtBuyerName.Text;
            Session["bEmail"] = txtBuyerEmail.Text;
            Session["bAddress"] = txtBuyerAddress.Text;
            Session["bPhone"] = txtBuyerPhoneNumber.Text;
            Session["bEmployment"] = txtBuyerEmployment.Text;
            Session["bIncome"] = txtBuyerIncome.Text;
            Session["bMoveIn"] = txtBuyerMoveDate.Text;
            Session["Homeplan"] = lblSelectedHomePlan.Text;
            Session["Roofing"] = lblSelectedRoofing.Text;
            Session["CountertopPrice"] = lblSelectedCountertop.Text;
            Session["HomeAdditions"] = arrAdditions;

            //Debug.WriteLine(Session["Homeplan"].ToString()); For someone reason when Homeplan Slasher's Paradise is sessioned, the apostrophe becomes &#39; due to htmlencoding
            Response.Redirect("Results.aspx");
        }

        protected void gvHomes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}