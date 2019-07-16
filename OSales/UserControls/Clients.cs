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
    public partial class Clients : UserControl
    {
        List<ClientsModel> clients = new List<ClientsModel>();
        private int clientID = 0;

        public Clients()
        {
            InitializeComponent();
            Refresh();
        }

        public override void Refresh()
        {
            clients = SqliteDataAccess.LoadAllClients();
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = clients;
        }

        private void btnCreateClient_Click(object sender, EventArgs e)
        {
            frmClient user = new frmClient(0, this);
            user.Show();
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (clientID != 0)
            {
                frmClient user = new frmClient(clientID, this);
                user.Show();
            }
            else
            {
                MessageBox.Show("Please Select User to Edit");
            }
        }
        
        private void dgvUsers_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                clientID = Convert.ToInt32(dgvUsers[0, e.RowIndex].Value);
            }
        }

        private void dgvUsers_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUsers.ClearSelection();
        }
    }
}
