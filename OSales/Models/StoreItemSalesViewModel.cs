using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales.Models
{
    public class StoreItemSalesViewModel
    {
        public int BaseLogID { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int InventorizationItemQuantity { get; set; }
        public int SalesItemQuantity { get; set; }
        public int IncomeItemQuantity { get; set; }
        public int OutcomeItemQuantity { get; set; }
        public int ItemsInStoreQuantity { get; set; }
        public decimal ItemsInStoreSum { get; set; }

        public StoreItemSalesViewModel()
        {

        }

        public StoreItemSalesViewModel(int baseLogID, int itemID, string itemName, int inventorizationItemQuantity, int salesItemQuantity, int incomeItemQuantity, int outcomeItemQuantity, int itemsInStoreQuantity, decimal itemsInStoreSum)
        {
            BaseLogID = baseLogID;
            ItemID = itemID;
            ItemName = itemName;
            InventorizationItemQuantity = inventorizationItemQuantity;
            SalesItemQuantity = salesItemQuantity;
            IncomeItemQuantity = incomeItemQuantity;
            OutcomeItemQuantity = outcomeItemQuantity;
            ItemsInStoreQuantity = itemsInStoreQuantity;
            ItemsInStoreSum = itemsInStoreSum;
        }
    }
}
