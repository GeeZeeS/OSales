using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales.Models
{
    public class BaseLogModel
    {
        public int BaseLogID { get; set; }
        public int OperationID { get; set; }
        public int StoreID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserID { get; set; }

        public BaseLogModel(int operationID, int storeID, DateTime createdDate, int userID)
        {
            OperationID = operationID;
            StoreID = storeID;
            CreatedDate = createdDate;
            UserID = userID;
        }

        public BaseLogModel()
        {

        }
    }
}
