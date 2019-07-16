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
    public partial class IncomeItems : UserControl
    {

        private int baseLogID;

        List<IncomeItemsModelView> incomeItemsModelViews = new List<IncomeItemsModelView>();
        
        public IncomeItems(int blID)
        {
            InitializeComponent();
            baseLogID = blID;
            incomeItemsModelViews = SqliteDataAccess.LoadIncomeItemsView(blID);
            dgvInventorizationItems.DataSource = incomeItemsModelViews;
        }

        private void btnLoadItems_Click(object sender, EventArgs e)
        {
            frmIncomeItems form = new frmIncomeItems(this, incomeItemsModelViews, baseLogID);
            form.Show();
        }

        public void Reload()
        {
            incomeItemsModelViews = SqliteDataAccess.LoadIncomeItemsView(baseLogID);
            dgvInventorizationItems.DataSource = null;
            dgvInventorizationItems.DataSource = incomeItemsModelViews;
        }

        private void dgvInventorizationItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvInventorizationItems.ClearSelection();
            dgvInventorizationItems.Columns[4].Visible = false;
        }
    }
}
