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
using OSales.Models;
using System.Text.RegularExpressions;
using OSales.UserControls;

namespace OSales.Forms
{
    public partial class Payment : DevExpress.XtraEditors.XtraForm
    {
        private decimal sumPay = 0;
        private decimal paid = 0;
        private decimal rest = 0;
        private int fpc = 0;
        private Sales checks = new Sales();
        List<PaymentTypeModel> paymentType = new List<PaymentTypeModel>();

        public Payment(Sales form, int FF, decimal SumPay)
        {
            InitializeComponent();
            sumPay = SumPay;
            fpc = FF;
            paymentType = SqliteDataAccess.LoadPaymentType();
            cmbPaymentType.DataSource = paymentType;
            cmbPaymentType.DisplayMember = "PaymentName";
            cmbPaymentType.ValueMember = "PaymentID";
            txtSumm.Text = sumPay.ToString("F");
            checks = form;
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtPaid.Text, @"^\d+$"))
            {
                paid = Convert.ToDecimal(txtPaid.Text);
                rest = sumPay - paid;
                txtRest.Text = rest.ToString("F");
            }
        }

        private void txtPaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClosePayment();
            }
        }

        private void cmbPaymentType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClosePayment();
            }
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            ClosePayment();
        }

        private void ClosePayment()
        {
            if (txtPaid.Text != "")
            {
                checks.ClosePayment(Convert.ToInt32(cmbPaymentType.SelectedValue), fpc, rest);
                this.Close();
            }
            else
            {
                MessageBox.Show("Payment Tab could not be blank!!!");
            }
        }

        
    }
}