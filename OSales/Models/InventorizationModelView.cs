using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales.Models
{
    public class InventorizationModelView
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemSum { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
