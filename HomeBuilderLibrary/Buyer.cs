using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilderLibrary
{
    internal class Buyer
    {
        string buyerName;
        string buyerEmail;
        string buyerAddress;
        string buyerPhone;
        string buyerEmployment;
        decimal buyerIncome;
        DateTime buyerMoveIn;

        public Buyer() { 
        
        }

        public Buyer(string buyerName, string buyerEmail, string buyerAddress, string buyerPhone, string buyerEmployment, decimal buyerIncome, DateTime buyerMoveIn)
        {
            this.buyerName = buyerName;
            this.buyerEmail = buyerEmail;
            this.buyerAddress = buyerAddress;
            this.buyerPhone = buyerPhone;
            this.buyerEmployment = buyerEmployment;
            this.buyerIncome = buyerIncome;
            this.buyerMoveIn = buyerMoveIn;
        }

        public string BuyerName
        {
            get { return buyerName; }
            set { buyerName = value; }
        }
        public string BuyerEmail
        {
            get { return buyerEmail; }
            set { buyerEmail = value; }
        }
        public string BuyerAddress
        {
            get { return buyerAddress; }
            set { buyerAddress = value; }
        }
        public string BuyerPhone
        {
            get { return buyerPhone; }
            set { buyerPhone = value; }
        }
        public string BuyerEmployment
        {
            get { return buyerEmployment; }
            set { buyerEmployment = value; }
        }
        public decimal BuyerIncome
        {
            get { return buyerIncome; }
            set { buyerIncome = value; }
        }
        public DateTime BuyerMoveIn
        {
            get { return buyerMoveIn; }
            set { buyerMoveIn = value; }
        }
    }
}
