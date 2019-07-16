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
    public partial class Inventorization : UserControl
    {
        private int baseLogID;

        List<InventorizationModelView> inventorizationModelViews = new List<InventorizationModelView>();

        public Inventorization(int blID)
        {
            InitializeComponent();
            baseLogID = blID;
            inventorizationModelViews = SqliteDataAccess.LoadInventorizationView(blID);
            dgvInventorizationItems.DataSource = inventorizationModelViews;
        }

        private void btnLoadItems_Click(object sender, EventArgs e)
        {
            frmInventorization form = new frmInventorization(this, inventorizationModelViews, baseLogID);
            form.Show();
        }

        public void Reload()
        {
            inventorizationModelViews = SqliteDataAccess.LoadInventorizationView(baseLogID);
            dgvInventorizationItems.DataSource = null;
            dgvInventorizationItems.DataSource = inventorizationModelViews;
        }

        private void dgvInventorizationItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvInventorizationItems.ClearSelection();
            dgvInventorizationItems.Columns[4].Visible = false;
        }
    }
}
