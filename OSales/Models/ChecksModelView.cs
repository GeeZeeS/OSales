using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales.Models
{
    public class ChecksModelView
    {
        public int CheckID { get; set; }
        public DateTime Date { get; set; }
        public string PayType { get; set; }
        public int SumQuantity { get; set; }
        public decimal SumPay { get; set; }
        public decimal SumTVA { get; set; }
        public decimal SumPaid { get; set; }
        public string ClientFullName { get; set; }
        public decimal Discount { get; set; }
        public decimal SumDiscount { get; set; }
        public int FPC { get; set; }
    }
}
