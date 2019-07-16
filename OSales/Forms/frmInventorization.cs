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
using OSales.UserControls;
using OSales.Models;

namespace OSales.Forms
{
    public partial class frmInventorization : DevExpress.XtraEditors.XtraForm
    {
        List<ItemCategoriesModel> categories = new List<ItemCategoriesModel>();
        List<ItemsModel> items = new List<ItemsModel>();
        List<InventorizationModelView> inventorizationModel = new List<InventorizationModelView>();
        Inventorization inv;

        int itemID;
        int baseLogID;
        public frmInventorization(Inventorization inventorization, List<InventorizationModelView> inventorizationModelViews, int blID)
        {
            InitializeComponent();
            inv = inventorization;
            baseLogID = blID;
            btnEditItem.Visible = false;
            LoadContent();
            if (inventorizationModelViews.Count > 0)
            {
                inventorizationModel = inventorizationModelViews;
            }
            dgvInventorization.DataSource = inventorizationModel;
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
        

        private void frmInventorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqliteDataAccess.DeleteInventorization(baseLogID);

            foreach (var inv in inventorizationModel)
            {
                SqliteDataAccess.CreateInventorization(inv, baseLogID);
            }

            inv.Reload();
        }

        private void btnInsertItem_Click(object sender, EventArgs e)
        {
            InsertItem();
        }

        private void InsertItem()
        {
            if (txtItemQuantity.Text != "")
            {
                var matchingValues = inventorizationModel.Find(x => x.ItemID == Convert.ToInt32(cmbItems.SelectedValue));
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

                    inventorizationModel.Add(new InventorizationModelView()
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

                    inventorizationModel.Where(x => x.ItemID == Convert.ToInt32(cmbItems.SelectedValue)).ToList().ForEach(s => s.ItemQuantity += Convert.ToInt32(txtItemQuantity.Text));
                    inventorizationModel.Where(x => x.ItemID == Convert.ToInt32(cmbItems.SelectedValue)).ToList().ForEach(s => s.ItemSum = s.ItemQuantity * itemPrice);
                }
                txtItemQuantity.Text = "";
                (dgvInventorization.BindingContext[inventorizationModel] as CurrencyManager).Refresh();
            }
            else
            {
                MessageBox.Show("ItemQuantity cannot be blank!");
            }
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
                inventorizationModel.Where(x => x.ItemID == itemID).ToList().ForEach(s => s.ItemQuantity = Convert.ToInt32(txtItemQuantity.Text));
                inventorizationModel.Where(x => x.ItemID == itemID).ToList().ForEach(s => s.ItemSum = s.ItemQuantity * itemPrice);
                txtItemQuantity.Text = "";
                (dgvInventorization.BindingContext[inventorizationModel] as CurrencyManager).Refresh();
                itemID = 0;
                btnEditItem.Visible = false;
            }
        }

        private void dgvInventorization_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                itemID = Convert.ToInt32(dgvInventorization[0, e.RowIndex].Value);
                btnEditItem.Visible = true;
                cmbItems.Text = dgvInventorization[1, e.RowIndex].Value.ToString();
                var iq = inventorizationModel.Where(x => x.ItemID == itemID).ToArray();
                string itemQ = iq[0].ItemQuantity.ToString();
                txtItemQuantity.Text = itemQ;
            }
        }
    }
}