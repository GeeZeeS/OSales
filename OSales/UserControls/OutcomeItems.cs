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
    public partial class OutcomeItems : UserControl
    {

        private int baseLogID;

        List<OutcomeItemsModelView> outcomeItemsModelViews = new List<OutcomeItemsModelView>();

        public OutcomeItems(int blID)
        {
            InitializeComponent();
            baseLogID = blID;
            outcomeItemsModelViews = SqliteDataAccess.LoadOutcometemsView(blID);
            dgvInventorizationItems.DataSource = outcomeItemsModelViews;
        }

        private void btnLoadItems_Click(object sender, EventArgs e)
        {
            frmOutcomeItems form = new frmOutcomeItems(this, outcomeItemsModelViews, baseLogID);
            form.Show();
        }

        public void Reload()
        {
            outcomeItemsModelViews = SqliteDataAccess.LoadOutcometemsView(baseLogID);
            dgvInventorizationItems.DataSource = null;
            dgvInventorizationItems.DataSource = outcomeItemsModelViews;
        }

        private void dgvInventorizationItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvInventorizationItems.ClearSelection();
            dgvInventorizationItems.Columns[4].Visible = false;
        }
    }
}
