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
    public partial class Users : UserControl
    {
        List<UsersModel> users = new List<UsersModel>();
        private int userID = 0;

        public Users()
        {
            InitializeComponent();
            LoadUsersList();
        }

        private void LoadUsersList()
        {
            users = SqliteDataAccess.LoadAllUsers();
            dgvUsers.DataSource = users;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            frmUser user = new frmUser(0, this);
            user.Show();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (userID != 0)
            {
                frmUser user = new frmUser(userID, this);
                user.Show();
            }
            else
            {
                MessageBox.Show("Please Select User to Edit");
            }
        }

        public override void Refresh()
        {
            users = SqliteDataAccess.LoadAllUsers();
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = users;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                userID = Convert.ToInt32(dgvUsers[0, e.RowIndex].Value);
            }
        }

        private void dgvUsers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUsers.ClearSelection();
        }
    }
}
