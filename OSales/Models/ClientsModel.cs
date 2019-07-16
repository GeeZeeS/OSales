using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales.Models
{
    public class ClientsModel
    {
        public int ClientID { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientBarcode { get; set; }
        public string ClientPhone { get; set; }
        public decimal ClientDiscount { get; set; }
        public decimal ClientBought { get; set; }
        
        public ClientsModel(int clientID, string clientFirstName, string clientLastName, string clientBarcode, string clientPhone, decimal clientDiscount)
        {
            ClientID = clientID;
            ClientFirstName = clientFirstName;
            ClientLastName = clientLastName;
            ClientBarcode = clientBarcode;
            ClientPhone = clientPhone;
            ClientDiscount = clientDiscount;
        }

        public ClientsModel(string clientFirstName, string clientLastName, string clientBarcode, string clientPhone, decimal clientDiscount, decimal clientBought)
        {
            ClientFirstName = clientFirstName;
            ClientLastName = clientLastName;
            ClientBarcode = clientBarcode;
            ClientPhone = clientPhone;
            ClientDiscount = clientDiscount;
            ClientBought = clientBought;
        }

        public ClientsModel()
        {

        }
    }
}
