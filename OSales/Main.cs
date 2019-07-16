using OSales.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OSales
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Main()
        {
            InitializeComponent();
            Sales sales = new Sales();
            sales.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(sales);

            if (Properties.Settings.Default.GroupID != 1)
            {
                pageManagement.Visible = false;
                pageAdministration.Visible = false;

                bbInventorization.Enabled = false;
                bbInventorizationResults.Enabled = false;
            }
        }

        private void ribbonControl1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (ribbonControl1.SelectedPage == pageAdministration)
            {
                pnlMain.Controls.Clear();
                Users users = new Users();
                users.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(users);
            }
            if (ribbonControl1.SelectedPage == pageSales)
            {
                pnlMain.Controls.Clear();
                Sales sales = new Sales();
                sales.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(sales);
            }
            if (ribbonControl1.SelectedPage == pageItems)
            {
                pnlMain.Controls.Clear();
                Items items = new Items();
                items.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(items);

            }
            if (ribbonControl1.SelectedPage == pageManagement)
            {
                pnlMain.Controls.Clear();
                ChartsSales sales = new ChartsSales();
                sales.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(sales);

            }
        }

        private void bBUsers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlMain.Controls.Clear();
            Users users = new Users();
            users.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(users);
        }

        private void bbSales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlMain.Controls.Clear();
            Sales sales = new Sales();
            sales.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(sales);
        }

        private void bbItems_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlMain.Controls.Clear();
            Items items = new Items();
            items.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(items);
        }

        private void bbChecksView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlMain.Controls.Clear();
            ChecksView checksView = new ChecksView();
            checksView.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(checksView);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void bbInventorization_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlMain.Controls.Clear();
            Operations checksView = new Operations(1);
            checksView.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(checksView);
        }
        
        private void bbInventorizationResults_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlMain.Controls.Clear();
            Operations checksView = new Operations(2);
            checksView.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(checksView);
        }

        private void bbIncomeItems_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlMain.Controls.Clear();
            Operations checksView = new Operations(3);
            checksView.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(checksView);
        }

        private void bbOutcomeItems_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlMain.Controls.Clear();
            Operations checksView = new Operations(4);
            checksView.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(checksView);
        }

        private void bbClients_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlMain.Controls.Clear();
            Clients clients = new Clients();
            clients.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(clients);
        }

        private void bbChartsSales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlMain.Controls.Clear();
            ChartsSales sales = new ChartsSales();
            sales.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(sales);
        }

        private void bbChartsStocks_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlMain.Controls.Clear();
            ChartsStocks stocks = new ChartsStocks();
            stocks.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(stocks);
        }

        private void bbItemsRating_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
