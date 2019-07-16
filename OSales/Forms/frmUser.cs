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
using System.Security.Cryptography;
using OSales.UserControls;

namespace OSales.Forms
{
    public partial class frmUser : DevExpress.XtraEditors.XtraForm
    {
        List<UsersModelEdit> userEdit = new List<UsersModelEdit>();
        List<UserGroupsModel> userGroups = new List<UserGroupsModel>();
        Users form = new Users();

        public frmUser(int userID, Users frm)
        {
            InitializeComponent();
            LoadContent(userID);
            form = frm;
        }

        private void LoadContent(int userID)
        {
            userGroups = SqliteDataAccess.LoadAllUserGroups();
            cmbUserGroup.DataSource = userGroups;
            cmbUserGroup.DisplayMember = "GroupName";
            cmbUserGroup.ValueMember = "GroupID";

            if (userID != 0)
            {
                userEdit = SqliteDataAccess.LoadEditUser(userID);
                foreach (var user in userEdit)
                {
                    txtUserID.Text = user.UserID.ToString();
                    txtUsername.Text = user.Username.ToString();
                    txtFirstName.Text = user.FirstName.ToString();
                    txtLastName.Text = user.LastName.ToString();
                    cmbUserGroup.SelectedValue = Convert.ToInt32(user.GroupID);
                }
            }
        }

        private bool Checker()
        {
            bool confirm = true;
            if (txtUsername.Text == "")
            {
                confirm = false;
                MessageBox.Show("Username Tab could not be empty!");
            }
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
            if (Convert.ToInt32(cmbUserGroup.SelectedValue) == 0)
            {
                confirm = false;
                MessageBox.Show("User Group Tab could not be empty!");
            }
            if (txtPassword.Text == "" && txtConfirmPassword.Text == "")
            {
                confirm = false;
                MessageBox.Show("Passwords Tab could not be empty!");
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                confirm = false;
                MessageBox.Show("Passwords do not match!");
            }
            return confirm;
        }

        private string EncodePassword(string password, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inarray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inarray);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Checker())
            {
                string password = EncodePassword(txtPassword.Text, "smthingSpecial");
                if (txtUserID.Text != "")
                {
                    UsersModelEdit user = new UsersModelEdit(
                            Convert.ToInt32(txtUserID.Text),
                            password,
                            txtUsername.Text,
                            txtFirstName.Text,
                            txtLastName.Text,
                            Convert.ToInt32(cmbUserGroup.SelectedValue)
                        );
                    SqliteDataAccess.EditUser(user);
                }
                else
                {
                    UsersModelEdit user = new UsersModelEdit(
                            password,
                            txtUsername.Text,
                            txtFirstName.Text,
                            txtLastName.Text,
                            Convert.ToInt32(cmbUserGroup.SelectedValue)
                        );
                    SqliteDataAccess.CreateUser(user);
                }
                form.Refresh();
                this.Close();
            }
        }
    }
}