using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales.Models
{
    public class BaseLogModelView
    {
        public int BaseLogID { get; set; }
        public string OperationName { get; set; }
        public int StoreID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserFullName { get; set; }
    }
}
