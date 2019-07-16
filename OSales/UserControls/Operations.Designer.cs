namespace OSales.UserControls
{
    partial class Operations
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dgvBaseLog = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreateBaseLog = new DevExpress.XtraEditors.SimpleButton();
            this.pnlOperations = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaseLog)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.dgvBaseLog);
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.pnlOperations);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1015, 832);
            this.splitContainerControl1.SplitterPosition = 225;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // dgvBaseLog
            // 
            this.dgvBaseLog.AllowUserToAddRows = false;
            this.dgvBaseLog.AllowUserToDeleteRows = false;
            this.dgvBaseLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaseLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvBaseLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaseLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaseLog.Location = new System.Drawing.Point(0, 54);
            this.dgvBaseLog.Name = "dgvBaseLog";
            this.dgvBaseLog.ReadOnly = true;
            this.dgvBaseLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaseLog.Size = new System.Drawing.Size(1015, 171);
            this.dgvBaseLog.TabIndex = 4;
            this.dgvBaseLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBaseLog_CellClick_1);
            this.dgvBaseLog.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvBaseLog_DataBindingComplete_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCreateBaseLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 54);
            this.panel1.TabIndex = 0;
            // 
            // btnCreateBaseLog
            // 
            this.btnCreateBaseLog.Location = new System.Drawing.Point(15, 17);
            this.btnCreateBaseLog.Name = "btnCreateBaseLog";
            this.btnCreateBaseLog.Size = new System.Drawing.Size(75, 23);
            this.btnCreateBaseLog.TabIndex = 0;
            this.btnCreateBaseLog.Text = "Create";
            this.btnCreateBaseLog.Click += new System.EventHandler(this.btnCreateBaseLog_Click);
            // 
            // pnlOperations
            // 
            this.pnlOperations.BackColor = System.Drawing.Color.White;
            this.pnlOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOperations.Location = new System.Drawing.Point(0, 0);
            this.pnlOperations.Name = "pnlOperations";
            this.pnlOperations.Size = new System.Drawing.Size(1015, 602);
            this.pnlOperations.TabIndex = 0;
            // 
            // Operations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "Operations";
            this.Size = new System.Drawing.Size(1015, 832);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaseLog)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnCreateBaseLog;
        private System.Windows.Forms.DataGridView dgvBaseLog;
        private System.Windows.Forms.Panel pnlOperations;
    }
}
