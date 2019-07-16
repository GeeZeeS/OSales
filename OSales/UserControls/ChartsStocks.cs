using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSales.Models;

namespace OSales.UserControls
{
    public partial class ChartsStocks : UserControl
    {
        List<ItemsModel> items = new List<ItemsModel>();
        List<InventorizationModelView> inventorizationModel = new List<InventorizationModelView>();
        List<StoreItemsSalesLoad> sales = new List<StoreItemsSalesLoad>();
        List<StoreItemsIncomeItemsModel> income = new List<StoreItemsIncomeItemsModel>();
        List<StoreItemsOutcomeItemsModel> outcome = new List<StoreItemsOutcomeItemsModel>();

        List<StoreItemSalesViewModel> basic = new List<StoreItemSalesViewModel>();
        List<InventorizationDateModelView> dates = new List<InventorizationDateModelView>();

        DateTime date;
        DateTime lastInvDate;

        public ChartsStocks()
        {
            InitializeComponent();
            dates = SqliteDataAccess.LoadInvDates();
            if (dates.Count > 0)
            {
                basic = SqliteDataAccess.LoadInventorizationResults(dates[0].BaseLogID);
                items = SqliteDataAccess.LoadAllItems();
                dgvItemsInStock.DataSource = basic;
                LoadItems();
            }
        }

        private void LoadInventorization()
        {
            foreach (var item in items)
            {
                var matchingInventorizationValues = inventorizationModel.Find(x => x.ItemID == item.ItemID);
                if (matchingInventorizationValues == null)
                {
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.InventorizationItemQuantity = 0);
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.ItemsInStoreQuantity = 0);
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.ItemsInStoreSum = 0);
                }
                else
                {
                    var i = inventorizationModel.Where(x => x.ItemID == item.ItemID).ToArray();
                    int itemQuantity = i[0].ItemQuantity;
                    decimal itemsSum = i[0].ItemSum;
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.InventorizationItemQuantity = itemQuantity);
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.ItemsInStoreQuantity += itemQuantity);
                }
            }
        }

        private void LoadSales()
        {
            foreach (var item in items)
            {
                var matchingSalesnValues = sales.Find(x => x.ItemID == item.ItemID);
                if (matchingSalesnValues == null)
                {
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.SalesItemQuantity = 0);
                }
                else
                {
                    var i = sales.Where(x => x.ItemID == item.ItemID).ToArray();
                    int itemQuantity = i[0].ItemQuantity;
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.SalesItemQuantity = itemQuantity);
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.ItemsInStoreQuantity -= itemQuantity);
                }
            }
        }

        private void LoadIncome()
        {
            foreach (var item in items)
            {
                var matchingIncomeValues = income.Find(x => x.ItemID == item.ItemID);
                if (matchingIncomeValues == null)
                {
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.IncomeItemQuantity = 0);
                }
                else
                {
                    var i = income.Where(x => x.ItemID == item.ItemID).ToArray();
                    int itemQuantity = i[0].ItemQuantity;
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.IncomeItemQuantity = itemQuantity);
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.ItemsInStoreQuantity += itemQuantity);
                }
            }
            var e = basic;
        }

        private void LoadOutcome()
        {
            foreach (var item in items)
            {
                var matchingOutcomeValues = outcome.Find(x => x.ItemID == item.ItemID);
                if (matchingOutcomeValues == null)
                {
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.OutcomeItemQuantity = 0);
                }
                else
                {
                    var i = outcome.Where(x => x.ItemID == item.ItemID).ToArray();
                    int itemQuantity = i[0].ItemQuantity;
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.OutcomeItemQuantity = itemQuantity);
                    basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.ItemsInStoreQuantity -= itemQuantity);
                }
            }
        }

        private void LoadItems()
        {
            basic.Clear();
            foreach (var item in items)
            {
                basic.Add(new StoreItemSalesViewModel()
                {
                    ItemID = item.ItemID,
                    ItemName = item.ItemName,
                    ItemPrice = item.ItemPrice,
                    InventorizationItemQuantity = 0,
                    SalesItemQuantity = 0,
                    IncomeItemQuantity = 0,
                    OutcomeItemQuantity = 0,
                    ItemsInStoreQuantity = 0,
                    ItemsInStoreSum = 0
                });
            }

            inventorizationModel = SqliteDataAccess.LoadStoreItemsInventorizationView();
            if (inventorizationModel.Count == 0)
            {
                date = DateTime.Now;
            }
            else
            {
                date = inventorizationModel[0].CreatedDate;
            }
            if (dates.Count < 2)
            {
                date = DateTime.Now;
                lastInvDate = dates[0].CreatedDate;
            }
            else
            {
                lastInvDate = dates[1].CreatedDate;
            }

            sales = SqliteDataAccess.LoadStoreItemsSalesView(date, lastInvDate);
            income = SqliteDataAccess.LoadStoreItemsIncomeView(date, lastInvDate);
            outcome = SqliteDataAccess.LoadStoreItemsOutcomeView(date, lastInvDate);

            LoadInventorization();
            LoadSales();
            LoadIncome();
            LoadOutcome();

            foreach (var item in items)
            {
                basic.Where(x => x.ItemID == item.ItemID).ToList().ForEach(s => s.ItemsInStoreSum = s.ItemsInStoreQuantity * s.ItemPrice);
            }
            (dgvItemsInStock.BindingContext[basic] as CurrencyManager).Refresh();
        }

        private void dgvItemsInStock_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvItemsInStock.ClearSelection();
            dgvItemsInStock.Columns[0].Visible = false;
        }
    }
}
