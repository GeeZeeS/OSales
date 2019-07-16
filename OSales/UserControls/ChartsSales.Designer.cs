namespace OSales.UserControls
{
    partial class ChartsSales
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
            this.btnSearchSales = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dgvChecks = new System.Windows.Forms.DataGridView();
            this.dgvChecksDetails = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSumm = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecksDetails)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearchSales
            // 
            this.btnSearchSales.Location = new System.Drawing.Point(237, 29);
            this.btnSearchSales.Name = "btnSearchSales";
            this.btnSearchSales.Size = new System.Drawing.Size(75, 23);
            this.btnSearchSales.TabIndex = 9;
            this.btnSearchSales.Text = "Search";
            this.btnSearchSales.Click += new System.EventHandler(this.btnSearchSales_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search By Date";
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
            this.splitContainerControl1.Size = new System.Drawing.Size(1048, 720);
            this.splitContainerControl1.SplitterPosition = 329;
            this.splitContainerControl1.TabIndex = 5;
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
            this.dgvChecks.Size = new System.Drawing.Size(1048, 329);
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
            this.dgvChecksDetails.Size = new System.Drawing.Size(1048, 386);
            this.dgvChecksDetails.TabIndex = 4;
            this.dgvChecksDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvChecksDetails_DataBindingComplete);
            this.dgvChecksDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChecksDetails_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblSumm);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.btnSearchSales);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 64);
            this.panel1.TabIndex = 4;
            // 
            // lblSumm
            // 
            this.lblSumm.AutoSize = true;
            this.lblSumm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumm.Location = new System.Drawing.Point(835, 29);
            this.lblSumm.Name = "lblSumm";
            this.lblSumm.Size = new System.Drawing.Size(57, 20);
            this.lblSumm.TabIndex = 11;
            this.lblSumm.Text = "label1";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // ChartsSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panel1);
            this.Name = "ChartsSales";
            this.Size = new System.Drawing.Size(1048, 784);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecksDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSearchSales;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.DataGridView dgvChecks;
        private System.Windows.Forms.DataGridView dgvChecksDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblSumm;
    }
}
