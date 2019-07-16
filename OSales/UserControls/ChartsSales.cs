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
    public partial class ChartsSales : UserControl
    {
        List<ChecksModelView> checksModelView = new List<ChecksModelView>();
        List<CheckDetailsModelPreview> checkDetailsModelPreview = new List<CheckDetailsModelPreview>();
        private int checkID;

        public ChartsSales()
        {
            InitializeComponent();
            LoadChecks(2, DateTime.Now);
            lblSumm.Visible = false;
        }

        private void LoadChecks(int type, DateTime time)
        {
            checksModelView = SqliteDataAccess.LoadChecksPreviewByDate(time);
            dgvChecks.DataSource = null;
            var results = new List<ChecksModelView>();
            foreach (var check in checksModelView)
            {
                if (check.FPC == type)
                {
                    results.Add(check);
                }
            }
            dgvChecks.DataSource = results;
            dgvChecksDetails.DataSource = null;
            CalculateSum(results);
        }

        private void CalculateSum(List<ChecksModelView> checks)
        {
            lblSumm.Visible = true;
            decimal summ = 0;
            foreach (var i in checks)
            {
                summ += i.SumPay;
            }
            lblSumm.Text = "Summ: " + summ.ToString("F");
        }

        private void dgvChecks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                checkID = Convert.ToInt32(dgvChecks[0, e.RowIndex].Value);
                checkDetailsModelPreview = SqliteDataAccess.LoadChecksDetailsPreview(checkID);
                dgvChecksDetails.DataSource = checkDetailsModelPreview;
            }
        }

        private void dgvChecks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvChecks.ClearSelection();
            dgvChecks.DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
            dgvChecks.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvChecks.Columns[10].Visible = false;
        }

        private void dgvChecksDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvChecksDetails.ClearSelection();
            dgvChecksDetails.DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
            dgvChecksDetails.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnSearchSales_Click(object sender, EventArgs e)
        {
            LoadChecks(2, dateTimePicker1.Value);
        }

        private void dgvChecks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                LoadChecks(2, dateTimePicker1.Value);
            }
            if (e.KeyCode == Keys.F11)
            {
                LoadChecks(1, dateTimePicker1.Value);
            }
        }

        private void dgvChecksDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                LoadChecks(2, dateTimePicker1.Value);
            }
            if (e.KeyCode == Keys.F11)
            {
                LoadChecks(1, dateTimePicker1.Value);
            }
        }
    }
}
