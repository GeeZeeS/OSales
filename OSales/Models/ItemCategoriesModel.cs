using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales.Models
{
    public class ItemCategoriesModel
    {
        public int ItemCategoryID { get; set; }
        public string ItemCategoryName { get; set; }

        public ItemCategoriesModel(int itemCategoryID, string itemCategoryName)
        {
            ItemCategoryID = itemCategoryID;
            ItemCategoryName = itemCategoryName;
        }

        public ItemCategoriesModel()
        {

        }

    }


}
