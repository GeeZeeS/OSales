using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales.Models
{
    public class ChecksModel
    {
        public int CheckID { get; set; }
        public int StoreID { get; set; }
        public DateTime Date { get; set; }
        public int PayType { get; set; }
        public int UserID { get; set; }
        public int SumQuantity { get; set; }
        public decimal SumTotal { get; set; }
        public decimal SumTVA { get; set; }
        public decimal SumPay { get; set; }
        public decimal SumRest { get; set; }
        public int ClientID { get; set; }
        public decimal Discount { get; set; }
        public decimal SumDiscount { get; set; }
        public int DiscountType { get; set; }
        public int FPC { get; set; }
        public int StateID { get; set; }

        public ChecksModel(int storeID, DateTime date, int payType, int userID, decimal sumTotal, decimal sumTVA, decimal sumPay, decimal sumRest, int clientID, decimal discount, decimal sumDiscount, int discountType, int fPC, int stateID)
        {
            StoreID = storeID;
            Date = date;
            PayType = payType;
            UserID = userID;
            SumTotal = sumTotal;
            SumTVA = sumTVA;
            SumPay = sumPay;
            SumRest = sumRest;
            ClientID = clientID;
            Discount = discount;
            SumDiscount = sumDiscount;
            DiscountType = discountType;
            FPC = fPC;
            StateID = stateID;
        }

        public ChecksModel()
        {

        }
    }
}
