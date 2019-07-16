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
using OSales.Forms;

namespace OSales.UserControls
{
    public partial class Items : UserControl
    {
        List<ItemsModel> items = new List<ItemsModel>();
        private int itemID = 0;

        public Items()
        {
            InitializeComponent();
            LoadItemsList();
        }

        private void LoadItemsList()
        {
            items = SqliteDataAccess.LoadAllItems();
            dgvItems.DataSource = items;
        }

        private void btnCreateItem_Click(object sender, EventArgs e)
        {
            frmItem form = new frmItem(0, this);
            form.Show();

        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (itemID != 0)
            {
                frmItem form = new frmItem(itemID, this);
                form.Show();
            }
            else
            {
                MessageBox.Show("Please Select Item to Edit");
            }
            
        }

        public override void Refresh()
        {
            items = SqliteDataAccess.LoadAllItems();
            dgvItems.DataSource = items;
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                itemID = Convert.ToInt32(dgvItems[0, e.RowIndex].Value);
            }
        }

        private void dgvItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvItems.ClearSelection();
        }
    }
}
