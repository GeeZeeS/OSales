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
using OSales.UserControls;

namespace OSales.Forms
{
    public partial class frmClient : DevExpress.XtraEditors.XtraForm
    {
        List<ClientsModel> client = new List<ClientsModel>();
        Clients form = new Clients();

        public frmClient(int clientID, Clients frm)
        {
            InitializeComponent();
            LoadContent(clientID);
            form = frm;
        }

        private void LoadContent(int clientID)
        {
            if (clientID != 0)
            {
                client = SqliteDataAccess.LoadEditClient(clientID);
                txtClientID.Text = client[0].ClientID.ToString();
                txtFirstName.Text = client[0].ClientFirstName.ToString();
                txtLastName.Text = client[0].ClientLastName.ToString();
                txtPhoneNumber.Text = client[0].ClientPhone;
                txtDiscount.Text = client[0].ClientDiscount.ToString();
                txtBarcode.Text = client[0].ClientBarcode.ToString();
            }
        }

        private bool Checker()
        {
            bool confirm = true;
            if (txtFirstName.Text == "")
            {
                confirm = false;
                MessageBox.Show("FirstName Tab could not be empty!");
            }
            if (txtLastName.Text == "")
            {
                confirm = false;
                MessageBox.Show("LastName Tab could not be empty!");
            }
            if (txtPhoneNumber.Text == "")
            {
                confirm = false;
                MessageBox.Show("PhoneNumber Tab could not be empty!");
            }
            if (txtDiscount.Text == "")
            {
                confirm = false;
                MessageBox.Show("Discount Tab could not be empty!");
            }
            return confirm;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Checker())
            {
                if (txtClientID.Text != "")
                {
                    ClientsModel client = new ClientsModel(
                            Convert.ToInt32(txtClientID.Text),
                            txtFirstName.Text,
                            txtLastName.Text,
                            txtBarcode.Text,
                            txtPhoneNumber.Text,
                            Convert.ToDecimal(txtDiscount.Text)
                        );
                    SqliteDataAccess.EditClient(client);
                }
                else
                {
                    ClientsModel client = new ClientsModel(
                            txtFirstName.Text,
                            txtLastName.Text,
                            txtBarcode.Text,
                            txtPhoneNumber.Text,
                            Convert.ToDecimal(txtDiscount.Text),
                            0
                        );
                    SqliteDataAccess.CreateClient(client);
                }
                form.Refresh();
                this.Close();
            }
        }
    }
}