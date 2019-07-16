namespace OSales.Forms
{
    partial class Payment
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblToPay = new System.Windows.Forms.Label();
            this.lblRest = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.txtSumm = new System.Windows.Forms.TextBox();
            this.txtRest = new System.Windows.Forms.TextBox();
            this.btnSale = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lblToPay
            // 
            this.lblToPay.AutoSize = true;
            this.lblToPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToPay.Location = new System.Drawing.Point(12, 30);
            this.lblToPay.Name = "lblToPay";
            this.lblToPay.Size = new System.Drawing.Size(97, 31);
            this.lblToPay.TabIndex = 0;
            this.lblToPay.Text = "Suma:";
            // 
            // lblRest
            // 
            this.lblRest.AutoSize = true;
            this.lblRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRest.Location = new System.Drawing.Point(12, 191);
            this.lblRest.Name = "lblRest";
            this.lblRest.Size = new System.Drawing.Size(84, 31);
            this.lblRest.TabIndex = 1;
            this.lblRest.Text = "Rest:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Paid:";
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Location = new System.Drawing.Point(150, 129);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(203, 41);
            this.cmbPaymentType.TabIndex = 6;
            this.cmbPaymentType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPaymentType_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Type:";
            // 
            // txtPaid
            // 
            this.txtPaid.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.Location = new System.Drawing.Point(150, 75);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(203, 40);
            this.txtPaid.TabIndex = 1;
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            this.txtPaid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaid_KeyDown);
            // 
            // txtSumm
            // 
            this.txtSumm.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumm.Location = new System.Drawing.Point(150, 26);
            this.txtSumm.Name = "txtSumm";
            this.txtSumm.ReadOnly = true;
            this.txtSumm.Size = new System.Drawing.Size(203, 40);
            this.txtSumm.TabIndex = 9;
            // 
            // txtRest
            // 
            this.txtRest.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRest.Location = new System.Drawing.Point(150, 187);
            this.txtRest.Name = "txtRest";
            this.txtRest.ReadOnly = true;
            this.txtRest.Size = new System.Drawing.Size(203, 40);
            this.txtRest.TabIndex = 10;
            // 
            // btnSale
            // 
            this.btnSale.Location = new System.Drawing.Point(236, 260);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(117, 38);
            this.btnSale.TabIndex = 11;
            this.btnSale.Text = "PAY";
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // Payment
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 310);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.txtRest);
            this.Controls.Add(this.txtSumm);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPaymentType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRest);
            this.Controls.Add(this.lblToPay);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblToPay;
        private System.Windows.Forms.Label lblRest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.TextBox txtSumm;
        private System.Windows.Forms.TextBox txtRest;
        private DevExpress.XtraEditors.SimpleButton btnSale;
    }
}