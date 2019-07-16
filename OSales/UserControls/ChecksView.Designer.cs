namespace OSales.UserControls
{
    partial class ChecksView
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
            this.btnInsertItem = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemQuantity = new System.Windows.Forms.TextBox();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dgvChecks = new System.Windows.Forms.DataGridView();
            this.dgvChecksDetails = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecksDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnInsertItem);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtItemQuantity);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 64);
            this.panel1.TabIndex = 2;
            // 
            // btnInsertItem
            // 
            this.btnInsertItem.Location = new System.Drawing.Point(242, 27);
            this.btnInsertItem.Name = "btnInsertItem";
            this.btnInsertItem.Size = new System.Drawing.Size(75, 23);
            this.btnInsertItem.TabIndex = 9;
            this.btnInsertItem.Text = "Insert";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search By ID";
            // 
            // txtItemQuantity
            // 
            this.txtItemQuantity.Location = new System.Drawing.Point(16, 29);
            this.txtItemQuantity.Name = "txtItemQuantity";
            this.txtItemQuantity.Size = new System.Drawing.Size(220, 20);
            this.txtItemQuantity.TabIndex = 4;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 64);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.dgvChecks);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.dgvChecksDetails);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1000, 704);
            this.splitContainerControl1.SplitterPosition = 329;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // dgvChecks
            // 
            this.dgvChecks.AllowUserToAddRows = false;
            this.dgvChecks.AllowUserToDeleteRows = false;
            this.dgvChecks.AllowUserToOrderColumns = true;
            this.dgvChecks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChecks.BackgroundColor = System.Drawing.Color.White;
            this.dgvChecks.ColumnHeadersHeight = 24;
            this.dgvChecks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChecks.Location = new System.Drawing.Point(0, 0);
            this.dgvChecks.Name = "dgvChecks";
            this.dgvChecks.ReadOnly = true;
            this.dgvChecks.RowTemplate.Height = 35;
            this.dgvChecks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChecks.Size = new System.Drawing.Size(1000, 329);
            this.dgvChecks.TabIndex = 4;
            this.dgvChecks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChecks_CellClick);
            this.dgvChecks.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvChecks_DataBindingComplete);
            this.dgvChecks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChecks_KeyDown);
            // 
            // dgvChecksDetails
            // 
            this.dgvChecksDetails.AllowUserToAddRows = false;
            this.dgvChecksDetails.AllowUserToDeleteRows = false;
            this.dgvChecksDetails.AllowUserToOrderColumns = true;
            this.dgvChecksDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChecksDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvChecksDetails.ColumnHeadersHeight = 24;
            this.dgvChecksDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChecksDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvChecksDetails.Name = "dgvChecksDetails";
            this.dgvChecksDetails.ReadOnly = true;
            this.dgvChecksDetails.RowTemplate.Height = 35;
            this.dgvChecksDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChecksDetails.Size = new System.Drawing.Size(1000, 370);
            this.dgvChecksDetails.TabIndex = 4;
            this.dgvChecksDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvChecksDetails_DataBindingComplete);
            this.dgvChecksDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChecksDetails_KeyDown);
            // 
            // ChecksView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panel1);
            this.Name = "ChecksView";
            this.Size = new System.Drawing.Size(1000, 768);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecksDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnInsertItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemQuantity;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.DataGridView dgvChecks;
        private System.Windows.Forms.DataGridView dgvChecksDetails;
    }
}
