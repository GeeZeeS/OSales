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
using OSales.UserControls;

namespace OSales.Forms
{
    public partial class frmCategories : DevExpress.XtraEditors.XtraForm
    {
        frmItem item;
        public frmCategories(frmItem i)
        {
            InitializeComponent();
            item = i;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text != "")
            {
                SqliteDataAccess.CreateCategory(txtCategoryName.Text);
                this.Close();
                item.LoadCats();
            }
            else
            {
                MessageBox.Show("Category Name Form must not be blank!");
            }
        }
    }
}