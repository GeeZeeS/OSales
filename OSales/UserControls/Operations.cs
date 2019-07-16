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

namespace OSales.UserControls
{
    public partial class Operations : UserControl
    {
        List<BaseLogModelView> baseLogs = new List<BaseLogModelView>();
        List<BaseLogModel> currentBaseLog = new List<BaseLogModel>();
        int operationID;
        int baseLogID;
        public Operations(int oID)
        {
            InitializeComponent();
            operationID = oID;
            baseLogs = SqliteDataAccess.LoadBaseLogs(operationID);
            dgvBaseLog.DataSource = baseLogs;
        }

        private void btnCreateBaseLog_Click(object sender, EventArgs e)
        {
            BaseLogModel bl = new BaseLogModel(
                    operationID,
                    Properties.Settings.Default.StoreID,
                    DateTime.Now,
                    Properties.Settings.Default.UserID
                );
            currentBaseLog = SqliteDataAccess.CreateBaseLog(bl);
            baseLogs = SqliteDataAccess.LoadBaseLogs(operationID);
            dgvBaseLog.DataSource = baseLogs;
            RunOperation(currentBaseLog[0].BaseLogID);

        }

        private void RunOperation(int logID)
        {
            if (operationID == 1)
            {
                pnlOperations.Controls.Clear();
                Inventorization checksView = new Inventorization(logID);
                checksView.Dock = DockStyle.Fill;
                pnlOperations.Controls.Add(checksView);
            }
            if (operationID == 2)
            {
                pnlOperations.Controls.Clear();
                InventorizationResults checksView = new InventorizationResults(logID);
                checksView.Dock = DockStyle.Fill;
                pnlOperations.Controls.Add(checksView);
            }
            if (operationID == 3)
            {
                pnlOperations.Controls.Clear();
                IncomeItems checksView = new IncomeItems(logID);
                checksView.Dock = DockStyle.Fill;
                pnlOperations.Controls.Add(checksView);
            }
            if (operationID == 4)
            {
                pnlOperations.Controls.Clear();
                OutcomeItems checksView = new OutcomeItems(logID);
                checksView.Dock = DockStyle.Fill;
                pnlOperations.Controls.Add(checksView);
            }
            if (operationID == 5)
            {
                //pnlOperations.Controls.Clear();
                //InventorizationResults checksView = new InventorizationResults(logID);
                //checksView.Dock = DockStyle.Fill;
                //pnlOperations.Controls.Add(checksView);
            }
        }

        private void dgvBaseLog_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                baseLogID = Convert.ToInt32(dgvBaseLog[0, e.RowIndex].Value);
                RunOperation(baseLogID);
            }
        }

        private void dgvBaseLog_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvBaseLog.ClearSelection();
            dgvBaseLog.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
