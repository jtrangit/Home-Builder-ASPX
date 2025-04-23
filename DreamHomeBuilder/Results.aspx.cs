using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Data.SqlClient;

namespace DreamHomeBuilder
{
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, decimal> homePrices = new Dictionary<string, decimal>()
            {
                {"Ferndale", 675000},
                {"Remodeled Bensalem", 750000},
                {"Cozy Central Ave", 515000},
                {"Luxury Clement", 900000},
                {"Norwalk Mansion", 1970000},
                {"Quaint Milford", 340000},
                {"Somerton Maple", 425000},
                {"Default Suburban House", 559900},
                {"The House From Up", 469999},
                {"Slasher's Paradise", 950000}
            };

            Dictionary<string, decimal> roofingPrices = new Dictionary<string, decimal>()
            {
                {"Asphalt Shingles", 1050},
                {"Architechural Shingles", 1750},
                {"Metal", 4500},
                {"Tile", 14000},
                {"Wood Shakes", 5000},
                {"Slate/Stone", 11000},
                {"Flat/Rolled/Built-up", 4070},
                {"Aluminum", 6000},
                {"Copper", 14000},
                {"Solar Shingle", 17500}
            };

            Dictionary<string, decimal> countertopPrices = new Dictionary<string, decimal>()
            {
                {"Marble", 2250},
                {"Granite", 1450},
                {"Engineered Quartz/Quartz", 1200},
                {"Slate", 550},
                {"Soapstone", 1500},
                {"Lava Stone", 2750},
                {"Limestone", 1100},
                {"Travertine", 750},
                {"Concrete", 1000},
                {"Stainless Steel", 1500}
            };

            Dictionary<string, decimal> additionPrices = new Dictionary<string, decimal>()
            {
                {"Attic Conversion", 40000},
                {"Room Addition/Bump Out", 50000},
                {"Sunroom Addition", 30000},
                {"Basement Conversion", 40000},
                {"Garage Conversion", 15000},
                {"Tiny House", 100000},
                {"Garage Second Floor", 50000},
                {"Kitchen Extension", 16000},
                {"Mudroom ", 10000},
                {"Small Deck Addition", 8000},
                {"Front Porch Addition", 13000},
                {"Carport Addition", 3500},
                {"Outside Living Space and Outdoor Kitchen", 50000},
                {"Upgraded Laundry Room", 20000},
                {"Living Room Fireplace", 4500}
            };

            string name = Session["bName"].ToString();
            string email = Session["bEmail"].ToString();
            string address = Session["bAddress"].ToString();
            string phoneNumber = Session["bPhone"].ToString();
            string employment = Session["bEmployment"].ToString();
            string income = Session["bIncome"].ToString();
            string move_in = Session["bMoveIn"].ToString();
            string homePlan = Session["Homeplan"].ToString(); //Slasher&#39;s Paradise this is what the session saves for the last homeplan
            homePlan = homePlan.Replace("&#39;", "'");        //changes Slasher&#39;s to Slasher's
            string roofing = Session["Roofing"].ToString();
            string counterPrice = Session["CountertopPrice"].ToString();
            ArrayList homeAdds = new ArrayList();
            homeAdds = (ArrayList)Session["HomeAdditions"];
            

            decimal total = 0;

            lblName.Text = name;
            lblEmail.Text = email;
            lblAddress.Text = address;
            lblPhone.Text = phoneNumber;
            lblEmployment.Text = employment;
            lblIncome.Text = "$" + income + " / year";
            lblMoveIn.Text = move_in;

            foreach (KeyValuePair<string, decimal> plan in homePrices)
            {
                if (homePlan == plan.Key)
                {
                    total += plan.Value;
                }
            }

            foreach (KeyValuePair<string, decimal> roofs in roofingPrices)
            {
                if (counterPrice == roofs.Key)
                {
                    total += roofs.Value;
                }
            }

            foreach (KeyValuePair<string, decimal> countertop in countertopPrices)
            {
                if (counterPrice == countertop.Key)
                {
                    total += countertop.Value;
                }
            }


            var table = new DataTable();
            table.Columns.Add("Home Options");
            table.Columns.Add("Cost");

            //row for homeplan
            var homeP = table.NewRow();
            homeP["Home Options"] = homePlan;
            homeP["Cost"] = String.Format("{0:C2}", homePrices[homePlan]);

            table.Rows.Add(homeP);

            //row for roofing
            var roof = table.NewRow();
            roof["Home Options"] = roofing;
            roof["Cost"] = String.Format("{0:C2}", roofingPrices[roofing]);

            table.Rows.Add(roof);

            //row for counter
            var counterT = table.NewRow();
            counterT["Home Options"] = counterPrice;
            counterT["Cost"] = String.Format("{0:C2}", countertopPrices[counterPrice]);

            table.Rows.Add(counterT);

            //row for home additions
            DataRow row;
            foreach(string homeAddition in homeAdds)
            {
                row = table.NewRow();
                row["Home Options"] = homeAddition.ToString();

                foreach (KeyValuePair<string, decimal> addition in additionPrices)
                {
                    if (homeAddition == addition.Key)
                    {
                        total += addition.Value;
                        row["Cost"] = String.Format("{0:C2}", addition.Value);
                    }
                }
                table.Rows.Add(row);
            }

            //row for total
            var totalPrice = table.NewRow();
            totalPrice["Home Options"] = "TOTAL:";
            totalPrice["Cost"] = String.Format("{0:C2}", total);

            table.Rows.Add(totalPrice);

            gvReceipt.DataSource = table;
            gvReceipt.DataBind();

            //update homesales table
            DBConnect dBConnect =  new DBConnect();
            dBConnect.UpdateHomeSales(total, homePlan);

        }
    }
}