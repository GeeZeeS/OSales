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
using System.Text.RegularExpressions;
using OSales.Forms;

namespace OSales.UserControls
{
    public partial class Sales : UserControl
    {
        List<ItemCategoriesModel> categories = new List<ItemCategoriesModel>();
        List<ItemsModel> items = new List<ItemsModel>();
        List<ChecksModel> checkReturned = new List<ChecksModel>();
        ChecksModel check = new ChecksModel();
        List<ChecksDetailsModel> checkDetails = new List<ChecksDetailsModel>();
        List<CurrentCheckModel> displayCheck = new List<CurrentCheckModel>();
        List<ChecksClientsModel> clients = new List<ChecksClientsModel>();

        private decimal summ;
        private decimal topay;
        private decimal discount;
        private int discountType;
        private int clientID;
        private int itemsQuantity;

        public Sales()
        {
            InitializeComponent();
            lblTVA.Visible = false;
            lblSumm.Visible = false;
            lblDiscount.Visible = false;
            lblToPay.Visible = false;
            LoadContent();
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

        private void btnInsertItem_Click(object sender, EventArgs e)
        {
            InsertItem();
        }

        private void InsertItem()
        {
            if (txtItemQuantity.Text != "")
            {
                var matchingValues = displayCheck.Find(x => x.ItemID == Convert.ToInt32(cmbItems.SelectedValue));
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

                    displayCheck.Add(new CurrentCheckModel()
                    {
                        ItemID = Convert.ToInt32(cmbItems.SelectedValue),
                        ItemName = itemName,
                        ItemQuantity = Convert.ToInt32(txtItemQuantity.Text),
                        ItemPrice = itemPrice,
                        SumItemPrice = Convert.ToDecimal(Convert.ToInt32(txtItemQuantity.Text) * itemPrice)
                    });
                    //var qq = displayCheck;
                }
                else
                {
                    displayCheck.Where(x => x.ItemID == Convert.ToInt32(cmbItems.SelectedValue)).ToList().ForEach(s => s.ItemQuantity += Convert.ToInt32(txtItemQuantity.Text));
                    displayCheck.Where(x => x.ItemID == Convert.ToInt32(cmbItems.SelectedValue)).ToList().ForEach(s => s.SumItemPrice = s.ItemQuantity * s.ItemPrice);
                    //var qq = displayCheck;
                }
                itemsQuantity += Convert.ToInt32(txtItemQuantity.Text);
                txtItemQuantity.Text = "";
                dgvSales.DataSource = null;
                dgvSales.DataSource = displayCheck;
                Calculations();
            }
            else
            {
                MessageBox.Show("ItemQuantity cannot be blank!");
            }
        }

        private void Calculations()
        {
            lblTVA.Visible = true;
            lblSumm.Visible = true;
            lblToPay.Visible = true;
            summ = 0;
            foreach (var item in displayCheck)
            {
                summ += item.SumItemPrice;
            }
            if (discountType > 0)
            {
                if (discountType == 1)
                {
                    topay = (summ - (summ * (discount / 100)));
                }
                if (discountType == 2)
                {
                    topay = (summ - discount);
                }
            }
            else
            {
                topay = summ;
            }

            lblSumm.Text = "SUM: " + summ.ToString("F");
            lblTVA.Text = "TVA: " + (summ / 6).ToString("F");
            lblToPay.Text = "PAY: " + topay.ToString("F");
        }

        private void SaleExecute(int FF)
        {
            check.StoreID = Properties.Settings.Default.StoreID;
            check.Date = DateTime.Now;
            check.PayType = 1;
            check.UserID = Properties.Settings.Default.UserID;
            check.SumQuantity = itemsQuantity;
            check.SumTotal = summ;
            check.SumTVA = summ / 6;
            check.SumPay = topay;
            check.SumRest = 0;
            check.ClientID = clientID;
            check.Discount = discount;
            check.SumDiscount = summ - topay;
            check.DiscountType = discountType;
            check.FPC = 1;
            check.StateID = 1;
            Payment form = new Payment(this, FF, check.SumPay);
            form.Show();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtDiscount.Text, @"^\d+$"))
            {
                txtDiscountSum.Text = "";
                discount = Convert.ToDecimal(txtDiscount.Text);
                discountType = 1;
                Calculations();
                lblDiscount.Visible = true;
                lblDiscount.Text = "%: " + (summ - topay).ToString("F");
            }
            else
            {
                lblDiscount.Visible = false;
                discountType = 0;
                discount = 0;
                Calculations();
            }
        }

        private void txtDiscountSum_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtDiscountSum.Text, @"^\d+$"))
            {
                txtDiscount.Text = "";
                discount = Convert.ToDecimal(txtDiscountSum.Text);
                discountType = 2;
                Calculations();
                lblDiscount.Visible = true;
                lblDiscount.Text = "%: " + (summ - topay).ToString("F");
            }
            else
            {
                lblDiscount.Visible = false;
                discountType = 0;
                discount = 0;
                Calculations();
            }
        }

        private void txtClientID_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtClientID.Text, @"^\d+$"))
            {
                clientID = Convert.ToInt32(txtClientID.Text);
                clients = SqliteDataAccess.LoadClientsByID(clientID);
                if (clients.Count > 0)
                {
                    string clientName = "";
                    foreach (var client in clients)
                    {
                        clientName = client.ClientFirstName + " " + client.ClientLastName;
                        txtClientName.Text = clientName;
                        txtDiscount.Text = client.ClientDiscount.ToString();
                    }
                }
                else
                {
                    clientID = 0;
                    txtClientName.Text = "";
                    txtDiscount.Text = "";
                }
            }
            else
            {
                clientID = 0;
                txtClientName.Text = "";
                txtDiscount.Text = "";
            }
        }

        private void dgvSales_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSales.ClearSelection();
            dgvSales.DefaultCellStyle.Font = new Font("Tahoma", 13, FontStyle.Bold);
        }

        private void txtItemQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InsertItem();
            }
            if (e.KeyCode == Keys.F12)
            {
                SaleExecute(2);
            }
            if (e.KeyCode == Keys.F11)
            {
                SaleExecute(1);
            }
        }

        private void dgvSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                SaleExecute(2);
            }
            if (e.KeyCode == Keys.F11)
            {
                SaleExecute(1);
            }
        }

        public void ClosePayment(int PayType, int FPC, decimal SumRest)
        {
            check.PayType = PayType;
            check.FPC = FPC;
            check.SumRest = Math.Abs(SumRest);
            checkReturned = SqliteDataAccess.InsertCheck(check);
            var i = check;

            int checkID = 0;

            foreach(var ch in checkReturned)
            {
                checkID = ch.CheckID;
            }
            checkDetails.Clear();
            foreach (var item in displayCheck)
            {
                checkDetails.Add(new ChecksDetailsModel()
                {
                    StoreID = Properties.Settings.Default.StoreID,
                    CheckID = checkID,
                    ItemID = item.ItemID,
                    ItemQuantity = item.ItemQuantity
                });
            }
            foreach (var c in checkDetails)
            {
                SqliteDataAccess.InsertCheckDetails(c);
            }
            if (clientID > 0)
            {
                SqliteDataAccess.UpdateClientsSum(clientID, topay);
            }
            displayCheck.Clear();
            checkDetails.Clear();
            checkReturned.Clear();
            dgvSales.DataSource = null;
            txtClientID.Text = "";
            txtClientName.Text = "";
            txtDiscount.Text = "";
            clientID = 0;
            itemsQuantity = 0;
            lblTVA.Visible = false;
            lblSumm.Visible = false;
            lblToPay.Visible = false;
        }
    }
}
