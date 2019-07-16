using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales.Models
{
    public class ChecksDetailsModel
    {
        public int StoreID { get; set; }
        public int CheckID { get; set; }
        public int ItemID { get; set; }
        public int ItemQuantity { get; set; }
    }
}
