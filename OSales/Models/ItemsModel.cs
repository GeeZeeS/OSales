using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales.Models
{
    public class ItemsModel
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemBarcode { get; set; }
        public decimal SelfCost { get; set; }
        public string ItemCategoryName { get; set; }
        public decimal ItemPrice { get; set; }
        public DateTime ItemAddedDate { get; set; }
    }
}
