using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OSales.Models;
using OSales.UserControls;

namespace OSales.Forms
{
    public partial class frmIncomeItems : DevExpress.XtraEditors.XtraForm
    {
        List<ItemCategoriesModel> categories = new List<ItemCategoriesModel>();
        List<ItemsModel> items = new List<ItemsModel>();
        List<IncomeItemsModelView> incomeItemsModel = new List<IncomeItemsModelView>();
        IncomeItems inv;

        int itemID;
        int baseLogID;

        public frmIncomeItems(IncomeItems incomeItems, List<IncomeItemsModelView> model, int blID)
        {
            InitializeComponent();
            inv = incomeItems;
            baseLogID = blID;
            btnEditItem.Visible = false;
            LoadContent();
            if (model.Count > 0)
            {
                incomeItemsModel = model;
            }
            else
            {
                incomeItemsModel.Clear();
            }
            //(dgvInventorization.BindingContext[incomeItemsModel] as CurrencyManager).Refresh();
            dgvInventorization.DataSource = incomeItemsModel;
        }

        private void LoadContent()
        {
            categories = SqliteDataAccess.LoadAllItemCategories();
            cmbItemCategory.DataSource = categories;
            cmbItemCategory.DisplayMember = "ItemCategoryName";
            cmbItemCategory.ValueMember = "ItemCategoryID";

            items = SqliteDataAccess.LoadItemsByCategoryID(Convert.ToInt32(cmbItemCategory.SelectedValue));
            cmbItems.DataSource = items;
            cmbItems.DisplayMember = "ItemName";
            cmbItems.ValueMember = "ItemID";
        }



        private void btnInsertItem_Click(object sender, EventArgs e)
        {
            InsertItem();
        }

        private void InsertItem()
        {
            if (txtItemQuantity.Text != "")
            {
                var matchingValues = incomeItemsModel.Find(x => x.ItemID == Convert.ToInt32(cmbItems.SelectedValue));
                if (matchingValues == null)
                {

                    List<ItemsModel> itemQ = new List<ItemsModel>();
                    itemQ = SqliteDataAccess.LoadItemsPriceAndNameByID(Convert.ToInt32(cmbItems.SelectedValue));
                    string itemName = "";
                    decimal itemPrice = 0;

                    foreach (var item in itemQ)
                    {
                        itemName = item.ItemName;
                        itemPrice = item.ItemPrice;
                    }

                    incomeItemsModel.Add(new IncomeItemsModelView()
                    {
                        ItemID = Convert.ToInt32(cmbItems.SelectedValue),
                        ItemName = itemName,
                        ItemQuantity = Convert.ToInt32(txtItemQuantity.Text),
                        ItemSum = itemPrice * Convert.ToInt32(txtItemQuantity.Text)
                    });
                }
                else
                {
                    List<ItemsModel> itemQ = new List<ItemsModel>();
                    itemQ = SqliteDataAccess.LoadItemsPriceAndNameByID(Convert.ToInt32(cmbItems.SelectedValue));
                    string itemName = "";
                    decimal itemPrice = 0;

                    foreach (var item in itemQ)
                    {
                        itemName = item.ItemName;
                        itemPrice = item.ItemPrice;
                    }

                    incomeItemsModel.Where(x => x.ItemID == Convert.ToInt32(cmbItems.SelectedValue)).ToList().ForEach(s => s.ItemQuantity += Convert.ToInt32(txtItemQuantity.Text));
                    incomeItemsModel.Where(x => x.ItemID == Convert.ToInt32(cmbItems.SelectedValue)).ToList().ForEach(s => s.ItemSum = s.ItemQuantity * itemPrice);
                }
                txtItemQuantity.Text = "";
                (dgvInventorization.BindingContext[incomeItemsModel] as CurrencyManager).Refresh();
            }
            else
            {
                MessageBox.Show("ItemQuantity cannot be blank!");
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (itemID > 0)
            {
                List<ItemsModel> itemQ = new List<ItemsModel>();
                itemQ = SqliteDataAccess.LoadItemsPriceAndNameByID(Convert.ToInt32(cmbItems.SelectedValue));
                string itemName = "";
                decimal itemPrice = 0;

                foreach (var item in itemQ)
                {
                    itemName = item.ItemName;
                    itemPrice = item.ItemPrice;
                }
                incomeItemsModel.Where(x => x.ItemID == itemID).ToList().ForEach(s => s.ItemQuantity = Convert.ToInt32(txtItemQuantity.Text));
                incomeItemsModel.Where(x => x.ItemID == itemID).ToList().ForEach(s => s.ItemSum = s.ItemQuantity * itemPrice);
                txtItemQuantity.Text = "";
                (dgvInventorization.BindingContext[incomeItemsModel] as CurrencyManager).Refresh();
                itemID = 0;
                btnEditItem.Visible = false;
            }
        }

        private void frmIncomeItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqliteDataAccess.DeleteIncomeItems(baseLogID);

            foreach (var inv in incomeItemsModel)
            {
                SqliteDataAccess.CreateIncomeItems(inv, baseLogID);
            }

            inv.Reload();
        }

        private void cmbItemCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbItemCategory.ValueMember == "ItemCategoryID")
            {
                items = SqliteDataAccess.LoadItemsByCategoryID(Convert.ToInt32(cmbItemCategory.SelectedValue));
                cmbItems.DataSource = items;
                cmbItems.DisplayMember = "ItemName";
                cmbItems.ValueMember = "ItemID";
            }
        }

        private void dgvInventorization_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvInventorization.ClearSelection();
            dgvInventorization.Columns[4].Visible = false;
        }

        private void dgvInventorization_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                itemID = Convert.ToInt32(dgvInventorization[0, e.RowIndex].Value);
                btnEditItem.Visible = true;
                cmbItems.Text = dgvInventorization[1, e.RowIndex].Value.ToString();
                var iq = incomeItemsModel.Where(x => x.ItemID == itemID).ToArray();
                string itemQ = iq[0].ItemQuantity.ToString();
                txtItemQuantity.Text = itemQ;
            }
        }
    }
}