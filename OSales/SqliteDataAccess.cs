using Dapper;
using OSales.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSales
{
    public class SqliteDataAccess
    {

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        //------------------------------------Users-------------------------------------------------------//
        public static List<UsersModelEdit> Login(string username)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UsersModelEdit>("SELECT * FROM users WHERE Username = '" + username.ToString() + "' LIMIT 1", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<UsersModel> LoadAllUsers()
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UsersModel>("SELECT UserID, Username, FirstName, LastName, GroupID FROM users", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<UsersModelEdit> LoadEditUser(int userID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UsersModelEdit>("SELECT UserID, Username, FirstName, LastName, GroupID FROM users WHERE UserID = " + userID.ToString(), new DynamicParameters());
                return output.ToList();
            }
        }

        public static void CreateUser(UsersModelEdit user)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO users (Username, Password, FirstName, LastName, GroupID) " +
                                       "VALUES (@Username, @Password, @FirstName, @LastName, @GroupID)", user);
            }
        }

        public static void EditUser(UsersModelEdit user)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE users SET Username = @Username, " +
                                             "Password = @Password, " +
                                             "FirstName = @FirstName, " +
                                             "LastName = @LastName, " +
                                             "GroupID = @GroupID " +
                                          "WHERE UserID = @UserID ", user);
            }
        }
        //------------------------------------UserGroups-------------------------------------------------------//
        public static List<UserGroupsModel> LoadAllUserGroups()
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserGroupsModel>("SELECT * FROM usergroups", new DynamicParameters());
                return output.ToList();
            }
        }
        //------------------------------------Sales-------------------------------------------------------//
        public static List<ItemsModel> LoadItemsByCategoryID(int ItemCategoryID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ItemsModel>("SELECT ItemID, ItemName FROM items WHERE ItemCategoryID = " + ItemCategoryID, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ItemsModel> LoadItemsPriceAndNameByID(int ItemID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ItemsModel>("SELECT ItemID, ItemName, ItemPrice FROM items WHERE ItemID = " + ItemID, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ChecksClientsModel> LoadClientsByID(int ClientID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ChecksClientsModel>("SELECT * FROM clients WHERE ClientID = " + ClientID, new DynamicParameters());
                return output.ToList();
            }
        }

        public static void UpdateClientsSum(int ClientID, decimal SumBought)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE clients SET ClientBought = ClientBought + " + SumBought + " WHERE ClientID = " + ClientID);
            }
        }

        public static List<PaymentTypeModel> LoadPaymentType()
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PaymentTypeModel>("SELECT * FROM paymenttype", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ChecksModel> InsertCheck(ChecksModel check)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO checks (StoreID, " +
                                                "Date, " +
                                                "PayType, " +
                                                "UserID, " +
                                                "SumQuantity, " +
                                                "SumTotal, " +
                                                "SumTVA, " +
                                                "SumPay, " +
                                                "SumRest, " +
                                                "ClientID, " +
                                                "Discount, " +
                                                "SumDiscount, " +
                                                "DiscountType, " +
                                                "FPC, " +
                                                "StateID) " +
                                       "VALUES (@StoreID, " +
                                                "@Date, " +
                                                "@PayType, " +
                                                "@UserID, " +
                                                "@SumQuantity, " +
                                                "@SumTotal, " +
                                                "@SumTVA, " +
                                                "@SumPay, " +
                                                "@SumRest, " +
                                                "@ClientID, " +
                                                "@Discount, " +
                                                "@SumDiscount, " +
                                                "@DiscountType, " +
                                                "@FPC, " +
                                                "@StateID);", check);

                var output = cnn.Query<ChecksModel>("SELECT * FROM checks ORDER BY CheckID DESC LIMIT 1", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void UpdateCheck(ChecksModel check, int CheckID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE checks SET StoreID = @StoreID, " +
                                                "Date = @Date, " +
                                                "PayType = @PayType, " +
                                                "UserID = @UserID, " +
                                                "SumQuantity = @SumQuantity, " +
                                                "SumTotal = @SumTotal, " +
                                                "SumTVA = @SumTVA, " +
                                                "SumPay = @SumPay, " +
                                                "SumRest = @SumRest, " +
                                                "ClientID = @ClientID, " +
                                                "Discount = @Discount, " +
                                                "SumDiscount = @SumDiscount, " +
                                                "DiscountType = @DiscountType, " +
                                                "FPC = @FPC, " +
                                                "StateID = @StateID " +
                                                "WHERE CheckID = " + CheckID.ToString(), check);
            }
        }

        public static void InsertCheckDetails(ChecksDetailsModel checkdetails)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO checksdetails (StoreID, " +
                                                "CheckID, " +
                                                "ItemID, " +
                                                "ItemQuantity) " +
                                       "VALUES (@StoreID, " +
                                                "@CheckID, " +
                                                "@ItemID, " +
                                                "@ItemQuantity);", checkdetails);
            }
        }
        //------------------------------------ChecksPreview-------------------------------------------------------//
        public static List<ChecksModelView> LoadChecksPreview()
        {
            string data = DateTime.Now.ToString("yyyy-MM-dd");
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ChecksModelView>("SELECT " +
                                                            "cmv.CheckID, " +
                                                            "cmv.Date, " +
                                                            "pt.PaymentName AS PayType, " +
                                                            "cmv.SumQuantity, " +
                                                            "cmv.SumPay, " +
                                                            "cmv.SumTVA, " +
                                                            "(cmv.SumPay + cmv.SumRest) AS SumPaid, " +
                                                            "concat(c.ClientFirstName, ' ', c.ClientLastName) AS ClientFullName, " +
                                                            "cmv.Discount, " +
                                                            "cmv.SumDiscount, " +
                                                            "cmv.FPC " +
                                                        "FROM checks cmv " +
                                                        "LEFT JOIN paymenttype pt ON cmv.PayType = pt.PaymentID " +
                                                        "LEFT JOIN clients c ON cmv.ClientID = c.ClientID " +
                                                        "WHERE DATE(cmv.Date) = CURDATE() " +
                                                        "ORDER BY CheckID DESC", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ChecksModelView> LoadChecksPreviewByDate(DateTime date)
        {
            string data = date.ToString("yyyy-MM-dd");
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ChecksModelView>("SELECT " +
                                                            "cmv.CheckID, " +
                                                            "cmv.Date, " +
                                                            "pt.PaymentName AS PayType, " +
                                                            "cmv.SumQuantity, " +
                                                            "cmv.SumPay, " +
                                                            "cmv.SumTVA, " +
                                                            "(cmv.SumPay + cmv.SumRest) AS SumPaid, " +
                                                            "concat(c.ClientFirstName, ' ', c.ClientLastName) AS ClientFullName, " +
                                                            "cmv.Discount, " +
                                                            "cmv.SumDiscount, " +
                                                            "cmv.FPC " +
                                                        "FROM checks cmv " +
                                                        "LEFT JOIN paymenttype pt ON cmv.PayType = pt.PaymentID " +
                                                        "LEFT JOIN clients c ON cmv.ClientID = c.ClientID " +
                                                        "WHERE DATE(cmv.Date) = '" + data + "' " +
                                                        "ORDER BY CheckID DESC", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ChecksModelView> LoadChecksPreviewAll()
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ChecksModelView>("SELECT " +
                                                            "cmv.CheckID, " +
                                                            "cmv.Date, " +
                                                            "pt.PaymentName AS PayType, " +
                                                            "cmv.SumQuantity, " +
                                                            "cmv.SumPay, " +
                                                            "cmv.SumTVA, " +
                                                            "(cmv.SumPay + cmv.SumRest) AS SumPaid, " +
                                                            "concat(c.ClientFirstName, ' ', c.ClientLastName) AS ClientFullName, " +
                                                            "cmv.Discount, " +
                                                            "cmv.SumDiscount " +
                                                        "FROM checks cmv " +
                                                        "LEFT JOIN paymenttype pt ON cmv.PayType = pt.PaymentID " +
                                                        "LEFT JOIN clients c ON cmv.ClientID = c.ClientID " +
                                                        "ORDER BY CheckID DESC", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<CheckDetailsModelPreview> LoadChecksDetailsPreview(int CheckID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CheckDetailsModelPreview>("SELECT " +
                                                                    "cd.ItemID, " +
                                                                    "i.ItemName, " +
                                                                    "i.ItemPrice, " +
                                                                    "cd.ItemQuantity, " +
                                                                    "(i.ItemPrice * cd.ItemQuantity) AS PriceSum, " +
                                                                    "CASE WHEN c.DiscountType = 0 THEN 0 " +
                                                                    "     WHEN c.DiscountType = 1 THEN FORMAT((i.ItemPrice * cd.ItemQuantity) - ((i.ItemPrice * cd.ItemQuantity) * (c.Discount / 100)), 2) " +
                                                                    "     WHEN c.DiscountType = 2 THEN FORMAT((i.ItemPrice * cd.ItemQuantity) - (cd.ItemQuantity * (c.Discount / c.SumQuantity)), 2) " +
                                                                    "END AS PriceDiscount " +
                                                                    "FROM checksdetails cd " +
                                                                    "LEFT JOIN items i ON cd.ItemID = i.ItemID " +
                                                                    "LEFT JOIN checks c ON cd.CheckID = c.CheckID " +
                                                                    "WHERE cd.CheckID = " + CheckID, new DynamicParameters());
                return output.ToList();
            }
        }

        //------------------------------------BaseLog-------------------------------------------------------//

        public static List<BaseLogModelView> LoadBaseLogs(int OperationID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<BaseLogModelView>("SELECT " +
                                                        "bl.BaseLogID, " +
                                                        "O.OperationName, " +
                                                        "bl.StoreID, " +
                                                        "bl.CreatedDate, " +
                                                        "concat(U.FirstName, ' ', U.LastName) AS UserFullName " +
                                                     "FROM baselog bl " +
                                                     "LEFT JOIN operations O ON bl.OperationID = O.OperationID " +
                                                     "LEFT JOIN users U ON bl.UserID = U.UserID " +
                                                     "WHERE bl.OperationID = " + OperationID + " " +
                                                     "ORDER BY bl.BaseLogID DESC;", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<BaseLogModel> CreateBaseLog(BaseLogModel baseLog)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO baselog(OperationID, StoreID, CreatedDate, UserID) " +
                                       "VALUES (@OperationID, @StoreID, @CreatedDate, @UserID)", baseLog);

                var output = cnn.Query<BaseLogModel>("SELECT * FROM baselog ORDER BY BaseLogID DESC LIMIT 1", new DynamicParameters());

                return output.ToList();
            }
        }

        //------------------------------------Inventorization-------------------------------------------------------//

        public static List<InventorizationModelView> LoadInventorizationView(int BaseLogID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<InventorizationModelView>("SELECT II.ItemID, " +
                                                                        "I.ItemName, " +
                                                                        "II.ItemQuantity, " +
                                                                        "(I.ItemPrice * II.ItemQuantity) AS ItemSum " +
                                                                        "FROM inventorizationsitems II " +
                                                                        "LEFT JOIN items I ON II.ItemID = I.ItemID " +
                                                                        "WHERE II.BaseLogID = " + BaseLogID , new DynamicParameters());
                return output.ToList();
            }
        }

        public static void DeleteInventorization(int BaseLogID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM inventorizationsitems WHERE BaseLogID = " + BaseLogID);
            }
        }

        public static void CreateInventorization(InventorizationModelView inv, int BaseLogID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO inventorizationsitems (BaseLogID, ItemID, ItemQuantity) " +
                                       "VALUES (" + BaseLogID + ", @ItemID, @ItemQuantity)", inv);
            }
        }

        //------------------------------------IncomeItems-------------------------------------------------------//

        public static List<IncomeItemsModelView> LoadIncomeItemsView(int BaseLogID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<IncomeItemsModelView>("SELECT II.ItemID, " +
                                                                        "I.ItemName, " +
                                                                        "II.ItemQuantity, " +
                                                                        "(I.ItemPrice * II.ItemQuantity) AS ItemSum " +
                                                                        "FROM incomeitems II " +
                                                                        "LEFT JOIN items I ON II.ItemID = I.ItemID " +
                                                                        "WHERE II.BaseLogID = " + BaseLogID, new DynamicParameters());
                return output.ToList();
            }
        }

        public static void DeleteIncomeItems(int BaseLogID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM incomeitems WHERE BaseLogID = " + BaseLogID);
            }
        }

        public static void CreateIncomeItems(IncomeItemsModelView inv, int BaseLogID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO incomeitems (BaseLogID, ItemID, ItemQuantity) " +
                                       "VALUES (" + BaseLogID + ", @ItemID, @ItemQuantity)", inv);
            }
        }

        //------------------------------------OutcomeItems-------------------------------------------------------//

        public static List<OutcomeItemsModelView> LoadOutcometemsView(int BaseLogID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<OutcomeItemsModelView>("SELECT II.ItemID, " +
                                                                        "I.ItemName, " +
                                                                        "II.ItemQuantity, " +
                                                                        "(I.ItemPrice * II.ItemQuantity) AS ItemSum " +
                                                                        "FROM outcomeitems II " +
                                                                        "LEFT JOIN items I ON II.ItemID = I.ItemID " +
                                                                        "WHERE II.BaseLogID = " + BaseLogID, new DynamicParameters());
                return output.ToList();
            }
        }

        public static void DeleteOutcomeItems(int BaseLogID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM outcomeitems WHERE BaseLogID = " + BaseLogID);
            }
        }

        public static void CreateOutcomeItems(OutcomeItemsModelView inv, int BaseLogID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO outcomeitems (BaseLogID, ItemID, ItemQuantity) " +
                                       "VALUES (" + BaseLogID + ", @ItemID, @ItemQuantity)", inv);
            }
        }

        //------------------------------------InventorizationResults-------------------------------------------------------//

        public static List<StoreItemSalesViewModel> LoadInventorizationResults(int BaseLogID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StoreItemSalesViewModel>("SELECT " +
                                                                    "IR.ItemID, " +
                                                                    "I.ItemName, " +
                                                                    "I.ItemPrice, " +
                                                                    "IR.InventorizationItemQuantity, " +
                                                                    "IR.SalesItemQuantity, " +
                                                                    "IR.IncomeItemQuantity, " +
                                                                    "IR.OutcomeItemQuantity, " +
                                                                    "IR.ItemsInStoreQuantity, " +
                                                                    "IR.ItemsInStoreSum " +
                                                                 "FROM inventorizationsresults IR " +
                                                                 "LEFT JOIN items I ON IR.ItemID = I.ItemID " +
                                                                 "WHERE IR.BaseLogID = " + BaseLogID +
                                                                 " ORDER BY I.ItemID;", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<InventorizationDateModelView> LoadInvDates()
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<InventorizationDateModelView>(
                    "SELECT BaseLogID, CreatedDate FROM baselog WHERE OperationID = 1 ORDER BY BaseLogID DESC LIMIT 2", 
                    new DynamicParameters());

                return output.ToList();
            }
        }

        public static List<InventorizationModelView> LoadStoreItemsInventorizationView()
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<InventorizationModelView>("SELECT II.ItemID, " +
                                                                        "I.ItemName, " +
                                                                        "II.ItemQuantity, " +
                                                                        "(I.ItemPrice * II.ItemQuantity) AS ItemSum, " +
                                                                        "bl.CreatedDate " +
                                                                        "FROM inventorizationsitems II " +
                                                                        "LEFT JOIN items I ON II.ItemID = I.ItemID " +
                                                                        "LEFT JOIN baselog bl ON II.BaseLogID = bl.BaseLogID " +
                                                                        "WHERE II.BaseLogID = " +
                                                                        "(SELECT BaseLogID FROM inventorizationsitems ORDER BY BaseLogID DESC LIMIT 1)", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<StoreItemsSalesLoad> LoadStoreItemsSalesView(DateTime date, DateTime last)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                string data = date.ToString("yyyy-MM-dd HH:mm:ss");
                string lasts = last.ToString("yyyy-MM-dd HH:mm:ss");
                var output = cnn.Query<StoreItemsSalesLoad>("SELECT " +
                                                                "cd.ItemID, "+
                                                                "SUM(cd.ItemQuantity) AS ItemQuantity " +
                                                                "FROM checksdetails cd " +
                                                                "LEFT JOIN checks c ON cd.CheckID = c.CheckID " +
                                                                "WHERE c.Date BETWEEN '" + lasts + "' AND '" + data + "' " +
                                                                " GROUP BY ItemID;", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<StoreItemsIncomeItemsModel> LoadStoreItemsIncomeView(DateTime date, DateTime last)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                string data = date.ToString("yyyy-MM-dd HH:mm:ss");
                string lasts = last.ToString("yyyy-MM-dd HH:mm:ss");
                var output = cnn.Query<StoreItemsIncomeItemsModel>("SELECT " +
                                                                "cd.ItemID, " +
                                                                "SUM(cd.ItemQuantity) AS ItemQuantity " +
                                                                "FROM incomeitems cd " +
                                                                "LEFT JOIN baselog bl ON cd.BaseLogID = bl.BaseLogID " +
                                                                "WHERE bl.CreatedDate BETWEEN '" + lasts + "' AND '" + data + "' AND bl.OperationID = 3 " +
                                                                "GROUP BY ItemID;", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<StoreItemsOutcomeItemsModel> LoadStoreItemsOutcomeView(DateTime date, DateTime last)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                string data = date.ToString("yyyy-MM-dd HH:mm:ss");
                string lasts = last.ToString("yyyy-MM-dd HH:mm:ss");
                var output = cnn.Query<StoreItemsOutcomeItemsModel>("SELECT " +
                                                                "cd.ItemID, " +
                                                                "SUM(cd.ItemQuantity) AS ItemQuantity " +
                                                                "FROM outcomeitems cd " +
                                                                "LEFT JOIN baselog bl ON cd.BaseLogID = bl.BaseLogID " +
                                                                "WHERE bl.CreatedDate BETWEEN '" + lasts + "' AND '" + data + "' AND bl.OperationID = 4 " +
                                                                "GROUP BY ItemID;", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void CreateInventorizationResult(StoreItemSalesViewModel model, int BaseLogID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO inventorizationsresults (BaseLogID, ItemID, InventorizationItemQuantity, SalesItemQuantity, IncomeItemQuantity, OutcomeItemQuantity, ItemsInStoreQuantity, ItemsInStoreSum) " +
                                       "VALUES (" + BaseLogID + ", @ItemID, @InventorizationItemQuantity, @SalesItemQuantity, @IncomeItemQuantity, @OutcomeItemQuantity, @ItemsInStoreQuantity, @ItemsInStoreSum)", model);
            }
        }



        //------------------------------------Items-------------------------------------------------------//
        public static List<ItemsModel> LoadAllItems()
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ItemsModel>("SELECT      i.ItemID, " +
                                                               "i.ItemName, " +
                                                               "i.ItemBarcode, " +
                                                               "ic.ItemCategoryName, " +
                                                               "i.SelfCost, " +
                                                               "i.ItemPrice, " +
                                                               "i.ItemAddedDate " +
                                                        "FROM items i " +
                                                        "LEFT JOIN itemcategories ic ON i.ItemCategoryID = ic.ItemCategoryID " +
                                                        "ORDER BY i.ItemID DESC ", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ItemModelEdit> LoadEditItem(int itemID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ItemModelEdit>("SELECT * FROM items WHERE ItemID = " + itemID.ToString(), new DynamicParameters());
                return output.ToList();
            }
        }

        public static void CreateItem(ItemModelEdit item)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO items (ItemName, ItemBarcode, SelfCost, ItemPrice, ItemCategoryID, ItemAddedDate) " +
                                       "VALUES (@ItemName, '', @SelfCost, @ItemPrice, @ItemCategoryID, @ItemAddedDate)", item);
            }
        }

        public static void EditItem(ItemModelEdit item)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE items SET ItemName = @ItemName, " +
                                             "SelfCost = @SelfCost, " +
                                             "ItemCategoryID = @ItemCategoryID " +
                                          "WHERE ItemID = @ItemID ", item);
            }
        }

        public static List<ItemModelEdit> GetItemsBarcode()
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ItemModelEdit>("SELECT ItemID, ItemBarcode FROM items WHERE ItemBarcode = ''", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void EditBarcode(int ItemID, string ItemBarcode)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE items SET ItemBarcode = " + ItemBarcode + " " +
                                          "WHERE ItemID = " + ItemID.ToString());
            }
        }

        //------------------------------------ItemGroups-------------------------------------------------------//

        public static List<ItemCategoriesModel> LoadAllItemCategories()
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ItemCategoriesModel>("SELECT * FROM itemcategories ORDER BY ItemCategoryID DESC", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void CreateCategory(string category)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO itemcategories (ItemCategoryName) VALUES ('" + category + "')");
            }
        }

        //------------------------------------Clients-------------------------------------------------------//

        public static List<ClientsModel> LoadAllClients()
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ClientsModel>("SELECT * FROM clients ORDER BY ClientID DESC", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ClientsModel> LoadEditClient(int clientID)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ClientsModel>("SELECT ClientID, ClientFirstName, ClientLastName, ClientBarcode, ClientPhone, ClientDiscount FROM clients WHERE ClientID = " + clientID.ToString(), new DynamicParameters());
                return output.ToList();
            }
        }

        public static void CreateClient(ClientsModel client)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO clients (ClientFirstName, ClientLastName, ClientBarcode, ClientPhone, ClientDiscount, ClientBought) " +
                                       "VALUES (@ClientFirstName, @ClientLastName, @ClientBarcode, @ClientPhone, @ClientDiscount, @ClientBought)", client);
            }
        }

        public static void EditClient(ClientsModel client)
        {
            using (IDbConnection cnn = new MySqlConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE clients SET ClientFirstName = @ClientFirstName, " +
                                             "ClientLastName = @ClientLastName, " +
                                             "ClientPhone = @ClientPhone, " +
                                             "ClientDiscount = @ClientDiscount, " +
                                             "ClientBought = @ClientBought " +
                                          "WHERE ClientID = @ClientID ", client);
            }
        }
    }
}
