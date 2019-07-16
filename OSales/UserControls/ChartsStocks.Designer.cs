namespace OSales.UserControls
{
    partial class ChartsStocks
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
            this.dgvItemsInStock = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsInStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItemsInStock
            // 
            this.dgvItemsInStock.AllowUserToAddRows = false;
            this.dgvItemsInStock.AllowUserToDeleteRows = false;
            this.dgvItemsInStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItemsInStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvItemsInStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemsInStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemsInStock.Location = new System.Drawing.Point(0, 48);
            this.dgvItemsInStock.Name = "dgvItemsInStock";
            this.dgvItemsInStock.ReadOnly = true;
            this.dgvItemsInStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemsInStock.Size = new System.Drawing.Size(996, 728);
            this.dgvItemsInStock.TabIndex = 5;
            this.dgvItemsInStock.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvItemsInStock_DataBindingComplete);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 48);
            this.panel1.TabIndex = 4;
            // 
            // ChartsStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvItemsInStock);
            this.Controls.Add(this.panel1);
            this.Name = "ChartsStocks";
            this.Size = new System.Drawing.Size(996, 776);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsInStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItemsInStock;
        private System.Windows.Forms.Panel panel1;
    }
}
