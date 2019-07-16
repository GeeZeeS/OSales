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
    public partial class frmOutcomeItems : DevExpress.XtraEditors.XtraForm
    {

        List<ItemCategoriesModel> categories = new List<ItemCategoriesModel>();
        List<ItemsModel> items = new List<ItemsModel>();
        List<OutcomeItemsModelView> outcomeItemsModel = new List<OutcomeItemsModelView>();
        OutcomeItems inv;

        int itemID;
        int baseLogID;

        public frmOutcomeItems(OutcomeItems outcomeItems, List<OutcomeItemsModelView> model, int blID)
        {
            InitializeComponent();
            inv = outcomeItems;
            baseLogID = blID;
            btnEditItem.Visible = false;
            LoadContent();
            if (model.Count > 0)
            {
                outcomeItemsModel = model;
            }
            else
            {
                outcomeItemsModel.Clear();
            }
            //(dgvInventorization.BindingContext[incomeItemsModel] as CurrencyManager).Refresh();
            dgvInventorization.DataSource = outcomeItemsModel;
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
                var matchingValues = outcomeItemsModel.Find(x => x.ItemID == Convert.ToInt32(cmbItems.SelectedValue));
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

                    outcomeItemsModel.Add(new OutcomeItemsModelView()
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

                    outcomeItemsModel.Where(x => x.ItemID == Convert.ToInt32(cmbItems.SelectedValue)).ToList().ForEach(s => s.ItemQuantity += Convert.ToInt32(txtItemQuantity.Text));
                    outcomeItemsModel.Where(x => x.ItemID == Convert.ToInt32(cmbItems.SelectedValue)).ToList().ForEach(s => s.ItemSum = s.ItemQuantity * itemPrice);
                }
                txtItemQuantity.Text = "";
                (dgvInventorization.BindingContext[outcomeItemsModel] as CurrencyManager).Refresh();
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
                outcomeItemsModel.Where(x => x.ItemID == itemID).ToList().ForEach(s => s.ItemQuantity = Convert.ToInt32(txtItemQuantity.Text));
                outcomeItemsModel.Where(x => x.ItemID == itemID).ToList().ForEach(s => s.ItemSum = s.ItemQuantity * itemPrice);
                txtItemQuantity.Text = "";
                (dgvInventorization.BindingContext[outcomeItemsModel] as CurrencyManager).Refresh();
                itemID = 0;
                btnEditItem.Visible = false;
            }
        }

        private void frmOutcomeItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqliteDataAccess.DeleteOutcomeItems(baseLogID);

            foreach (var inv in outcomeItemsModel)
            {
                SqliteDataAccess.CreateOutcomeItems(inv, baseLogID);
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

        private void dgvInventorization_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                itemID = Convert.ToInt32(dgvInventorization[0, e.RowIndex].Value);
                btnEditItem.Visible = true;
                cmbItems.Text = dgvInventorization[1, e.RowIndex].Value.ToString();
                var iq = outcomeItemsModel.Where(x => x.ItemID == itemID).ToArray();
                string itemQ = iq[0].ItemQuantity.ToString();
                txtItemQuantity.Text = itemQ;
            }
        }

        private void dgvInventorization_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvInventorization.ClearSelection();
            dgvInventorization.Columns[4].Visible = false;
        }
    }
}