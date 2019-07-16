namespace OSales.UserControls
{
    partial class InventorizationResults
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadItems = new DevExpress.XtraEditors.SimpleButton();
            this.dgvStoreItems = new System.Windows.Forms.DataGridView();
            this.btnSaveInventorization = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnSaveInventorization);
            this.panel1.Controls.Add(this.btnLoadItems);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 61);
            this.panel1.TabIndex = 0;
            // 
            // btnLoadItems
            // 
            this.btnLoadItems.Location = new System.Drawing.Point(16, 20);
            this.btnLoadItems.Name = "btnLoadItems";
            this.btnLoadItems.Size = new System.Drawing.Size(75, 23);
            this.btnLoadItems.TabIndex = 0;
            this.btnLoadItems.Text = "Load Items";
            this.btnLoadItems.Click += new System.EventHandler(this.btnLoadItems_Click);
            // 
            // dgvStoreItems
            // 
            this.dgvStoreItems.AllowUserToAddRows = false;
            this.dgvStoreItems.AllowUserToDeleteRows = false;
            this.dgvStoreItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStoreItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvStoreItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStoreItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStoreItems.Location = new System.Drawing.Point(0, 61);
            this.dgvStoreItems.Name = "dgvStoreItems";
            this.dgvStoreItems.ReadOnly = true;
            this.dgvStoreItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStoreItems.Size = new System.Drawing.Size(847, 465);
            this.dgvStoreItems.TabIndex = 5;
            this.dgvStoreItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvStoreItems_DataBindingComplete);
            // 
            // btnSaveInventorization
            // 
            this.btnSaveInventorization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveInventorization.Location = new System.Drawing.Point(682, 20);
            this.btnSaveInventorization.Name = "btnSaveInventorization";
            this.btnSaveInventorization.Size = new System.Drawing.Size(135, 23);
            this.btnSaveInventorization.TabIndex = 1;
            this.btnSaveInventorization.Text = "Save Inventorization";
            this.btnSaveInventorization.Click += new System.EventHandler(this.btnSaveInventorization_Click);
            // 
            // InventorizationResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvStoreItems);
            this.Controls.Add(this.panel1);
            this.Name = "InventorizationResults";
            this.Size = new System.Drawing.Size(847, 526);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvStoreItems;
        private DevExpress.XtraEditors.SimpleButton btnLoadItems;
        private DevExpress.XtraEditors.SimpleButton btnSaveInventorization;
    }
}
