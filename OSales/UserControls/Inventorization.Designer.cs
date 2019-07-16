﻿namespace OSales.UserControls
{
    partial class Inventorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventorization));
            this.btnLoadItems = new DevExpress.XtraEditors.SimpleButton();
            this.dgvInventorizationItems = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventorizationItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadItems
            // 
            this.btnLoadItems.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadItems.ImageOptions.Image")));
            this.btnLoadItems.Location = new System.Drawing.Point(16, 20);
            this.btnLoadItems.Name = "btnLoadItems";
            this.btnLoadItems.Size = new System.Drawing.Size(100, 23);
            this.btnLoadItems.TabIndex = 0;
            this.btnLoadItems.Text = "Load Items";
            this.btnLoadItems.Click += new System.EventHandler(this.btnLoadItems_Click);
            // 
            // dgvInventorizationItems
            // 
            this.dgvInventorizationItems.AllowUserToAddRows = false;
            this.dgvInventorizationItems.AllowUserToDeleteRows = false;
            this.dgvInventorizationItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventorizationItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventorizationItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventorizationItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventorizationItems.Location = new System.Drawing.Point(0, 61);
            this.dgvInventorizationItems.Name = "dgvInventorizationItems";
            this.dgvInventorizationItems.ReadOnly = true;
            this.dgvInventorizationItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventorizationItems.Size = new System.Drawing.Size(1043, 676);
            this.dgvInventorizationItems.TabIndex = 7;
            this.dgvInventorizationItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvInventorizationItems_DataBindingComplete);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnLoadItems);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1043, 61);
            this.panel1.TabIndex = 6;
            // 
            // Inventorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvInventorizationItems);
            this.Controls.Add(this.panel1);
            this.Name = "Inventorization";
            this.Size = new System.Drawing.Size(1043, 737);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventorizationItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLoadItems;
        private System.Windows.Forms.DataGridView dgvInventorizationItems;
        private System.Windows.Forms.Panel panel1;
    }
}
