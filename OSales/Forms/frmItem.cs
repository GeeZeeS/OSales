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
    public partial class frmItem : DevExpress.XtraEditors.XtraForm
    {
        List<ItemCategoriesModel> categories = new List<ItemCategoriesModel>();
        List<ItemModelEdit> items = new List<ItemModelEdit>();
        Items form = new Items();

        public frmItem(int itemID, Items uc)
        {
            InitializeComponent();
            LoadContent(itemID);
            form = uc; 
        }

        private void LoadContent(int itemID)
        {
            LoadCats();

            if (itemID != 0)
            {
                items = SqliteDataAccess.LoadEditItem(itemID);
                foreach (var item in items)
                {
                    txtItemID.Text = item.ItemID.ToString();
                    txtItemName.Text = item.ItemName.ToString();
                    txtItemPrice.Text = item.ItemPrice.ToString();
                    txtItemBarcode.Text = item.ItemBarcode.ToString();
                    txtSelfCost.Text = item.SelfCost.ToString();
                    cmbItemCategory.SelectedValue = Convert.ToInt32(item.ItemCategoryID);
                }
            }
        }

        private bool Checker()
        {
            bool confirm = true;

            if (txtItemName.Text == "")
            {
                confirm = false;
                MessageBox.Show("Item Name Tab could not be empty!");
            }
            if (txtItemPrice.Text == "")
            {
                confirm = false;
                MessageBox.Show("Item Price Tab could not be empty!");
            }
            if (Convert.ToInt32(cmbItemCategory.SelectedValue) == 0)
            {
                confirm = false;
                MessageBox.Show("Item Group Tab could not be empty!");
            }
            return confirm;
        }

        private void GenerateBarcode()
        {
            items = new List<ItemModelEdit>();
            items = SqliteDataAccess.GetItemsBarcode();
            foreach (var item in items)
            {
                SqliteDataAccess.EditBarcode(item.ItemID, GenBcode(item.ItemID.ToString()));
            }
            form.Refresh();
        }

        private string GenBcode(string id)
        {
            string countryCode = "21";
            string manufCode = "00000";
            string productCode = Convert.ToInt32(id).ToString("D5");
            string code = countryCode + manufCode + productCode;
            return AppendChecksum(code);
        }

        public string AppendChecksum(string code)
        {
            var sum = 0;

            for (var i = code.Length; i >= 1; i--)
            {
                var d = Convert.ToInt32(code.Substring(i - 1, 1));
                var f = i % 2 == 0 ? 3 : 1;
                sum += d * f;
            }
            var checksum = (10 - (sum % 10)) % 10;

            return code + checksum;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Checker())
            {
                if (txtItemID.Text != "")
                {
                    ItemModelEdit item = new ItemModelEdit(
                            Convert.ToInt32(txtItemID.Text),
                            txtItemName.Text,
                            Convert.ToDecimal(txtSelfCost.Text),
                            Convert.ToInt32(cmbItemCategory.SelectedValue)
                        );
                    SqliteDataAccess.EditItem(item);
                }
                else
                {
                    ItemModelEdit item = new ItemModelEdit(
                            txtItemName.Text,
                            Convert.ToDecimal(txtSelfCost.Text),
                            Convert.ToDecimal(txtItemPrice.Text),
                            Convert.ToInt32(cmbItemCategory.SelectedValue),
                            DateTime.Now
                        );
                    SqliteDataAccess.CreateItem(item);

                }
            }
            GenerateBarcode();
            this.Close();
        }

        public void LoadCats()
        {
            categories = SqliteDataAccess.LoadAllItemCategories();
            cmbItemCategory.DataSource = categories;
            cmbItemCategory.DisplayMember = "ItemCategoryName";
            cmbItemCategory.ValueMember = "ItemCategoryID";
        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            frmCategories cat = new frmCategories(this);
            cat.Show();
        }
    }
}