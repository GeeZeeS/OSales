using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales.Models
{
    public class ChecksClientsModel
    {
        public int ClientID { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientBarcode { get; set; }
        public string ClientPhone { get; set; }
        public int ClientDiscount { get; set; }
        public decimal ClientBought { get; set; }
    }
}
