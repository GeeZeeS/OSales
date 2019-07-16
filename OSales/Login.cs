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

namespace OSales
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            Log();
        }

        private void Log()
        {
            List<UsersModelEdit> users = new List<UsersModelEdit>();
            users = SqliteDataAccess.Login(txtUsername.Text);
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    string hashedPassword = EncodePassword(txtPassword.Text, "smthingSpecial");
                    if (user.Password == hashedPassword)
                    {
                        Properties.Settings.Default.UserID = user.UserID;
                        Properties.Settings.Default.StoreID = 1;
                        Properties.Settings.Default.GroupID = user.GroupID;
                        Main form = new Main();
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username or password incorrect!!!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Username or password incorrect!!!");
            }
            
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

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Log();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Log();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Log();
            }
        }
    }
}