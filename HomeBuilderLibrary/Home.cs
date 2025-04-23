using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilderLibrary
{
    public class Home
    {
        string homeName;
        decimal homePrice;
        string homeRoof;
        decimal homeRoofPrice;
        string homeCountertop;
        decimal homeCountertopPrice;
        string homeFloor;
        decimal homeFloorPrice;
        ArrayList homeAdditions = new ArrayList();
        decimal homeAdditionsPrice;

        public Home()
        {

        }

        public Home(string homeName, decimal homePrice, string homeRoof, decimal homeRoofPrice, string homeCountertop, decimal homeCountertopPrice, string homeFloor, decimal homeFloorPrice, ArrayList homeAdditions)
        {
            this.homeName = homeName;
            this.homePrice = homePrice;
            this.homeRoof = homeRoof;
            this.homeRoofPrice = homeRoofPrice;
            this.homeCountertop = homeCountertop;
            this.homeCountertopPrice = homeCountertopPrice;
            this.homeFloor = homeFloor;
            this.homeFloorPrice = homeFloorPrice;
            this.homeAdditions = homeAdditions;
        }

        public string HomeName
        {
            get { return homeName; }
            set { this.homeName = value; }
        }
        public decimal HomePrice
        {
            get { return homePrice; }
            set { this.homePrice = value; }
        }
        public string HomeRoof
        {
            get { return homeRoof; }
            set { this.homeRoof = value; }
        }
        public decimal HomeRoofPrice
        {
            get { return homeRoofPrice; }
            set { this.homeRoofPrice = value; }
        }
        public string HomeCountertop
        {
            get { return homeCountertop; }
            set { this.homeCountertop = value; }
        }
        public decimal HomeCountertopPrice
        {
            get { return homeCountertopPrice; }
            set { this.HomeCountertopPrice = value; }
        }
        public string HomeFloor
        {
            get { return homeFloor; }
            set { this.homeFloor = value; }
        }
        public decimal HomeFloorPrice
        {
            get { return homeFloorPrice; }
            set { this.homeFloorPrice = value; }
        }
        public ArrayList HomeAdditions
        {
            get { return HomeAdditions; }
            set { this.HomeAdditions = value; }
        }
        public decimal HomeAdditionPrices
        {
            get { return homeAdditionsPrice; }
            set { this.homeAdditionsPrice = value; }
        }
        public decimal CalculateHomeTotal()
        {
            return homePrice + homeRoofPrice + homeCountertopPrice + homeFloorPrice + homeAdditionsPrice;
        }
    }
}
