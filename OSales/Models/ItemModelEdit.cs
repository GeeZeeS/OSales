using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales.Models
{
    public class ItemModelEdit
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemBarcode { get; set; }
        public decimal SelfCost { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemCategoryID { get; set; }
        public DateTime ItemAddedDate { get; set; }

        public ItemModelEdit(string itemName, decimal selfCost, decimal itemPrice, int itemCategoryID, DateTime itemAddedDate)
        {
            ItemName = itemName;
            SelfCost = selfCost;
            ItemPrice = itemPrice;
            ItemCategoryID = itemCategoryID;
            ItemAddedDate = itemAddedDate;
        }

        public ItemModelEdit(int itemID, string itemName, decimal selfCost, int itemCategoryID)
        {
            ItemID = itemID;
            ItemName = itemName;
            SelfCost = selfCost;
            ItemCategoryID = itemCategoryID;
        }

        public ItemModelEdit(int itemID, string itemBarcode)
        {
            ItemID = itemID;
            ItemBarcode = itemBarcode;
        }

        public ItemModelEdit(int itemID, decimal itemPrice)
        {
            ItemID = itemID;
            ItemPrice = itemPrice;
        }

        public ItemModelEdit()
        {

        }

    }
}
