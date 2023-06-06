namespace WindowsFormsApp2
{
    partial class frmCancelDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCancelDetails));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtTransNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVoid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCancel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboAction = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCancelQty = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 45);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(804, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "CANCEL ORDER DETAILS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(188, 87);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(217, 29);
            this.txtID.TabIndex = 5;
            this.txtID.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // txtTransNo
            // 
            this.txtTransNo.Enabled = false;
            this.txtTransNo.Location = new System.Drawing.Point(612, 87);
            this.txtTransNo.Name = "txtTransNo";
            this.txtTransNo.Size = new System.Drawing.Size(217, 29);
            this.txtTransNo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(448, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Transaction No";
            // 
            // txtPCode
            // 
            this.txtPCode.Enabled = false;
            this.txtPCode.Location = new System.Drawing.Point(188, 122);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.Size = new System.Drawing.Size(217, 29);
            this.txtPCode.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Product Code";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(188, 160);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(217, 56);
            this.txtDescription.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Description";
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(612, 122);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(217, 29);
            this.txtPrice.TabIndex = 13;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(448, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Price";
            // 
            // txtQty
            // 
            this.txtQty.Enabled = false;
            this.txtQty.Location = new System.Drawing.Point(612, 157);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(103, 29);
            this.txtQty.TabIndex = 15;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(448, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Qty/ Discount";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(613, 193);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(216, 29);
            this.txtTotal.TabIndex = 17;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.TextChanged += new System.EventHandler(this.TextBox7_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(449, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Total";
            this.label8.Click += new System.EventHandler(this.Label8_Click);
            // 
            // txtVoid
            // 
            this.txtVoid.Enabled = false;
            this.txtVoid.Location = new System.Drawing.Point(188, 281);
            this.txtVoid.Name = "txtVoid";
            this.txtVoid.Size = new System.Drawing.Size(217, 29);
            this.txtVoid.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Void By";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label10.Location = new System.Drawing.Point(24, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "SOLD ITEM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label11.Location = new System.Drawing.Point(24, 243);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "CANCEL ITEMS(S)";
            // 
            // txtCancel
            // 
            this.txtCancel.Enabled = false;
            this.txtCancel.Location = new System.Drawing.Point(188, 316);
            this.txtCancel.Name = "txtCancel";
            this.txtCancel.Size = new System.Drawing.Size(217, 29);
            this.txtCancel.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(24, 322);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 20);
            this.label12.TabIndex = 22;
            this.label12.Text = "Cancelled By";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(612, 316);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(217, 61);
            this.txtReason.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(448, 319);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "Reason(s)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(24, 354);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(162, 20);
            this.label14.TabIndex = 26;
            this.label14.Text = "Add To Inventory?";
            this.label14.Click += new System.EventHandler(this.Label14_Click);
            // 
            // cboAction
            // 
            this.cboAction.FormattingEnabled = true;
            this.cboAction.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cboAction.Location = new System.Drawing.Point(188, 351);
            this.cboAction.Name = "cboAction";
            this.cboAction.Size = new System.Drawing.Size(217, 29);
            this.cboAction.TabIndex = 27;
            this.cboAction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboAction_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(683, 383);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 37);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Cancel Order";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtCancelQty
            // 
            this.txtCancelQty.Location = new System.Drawing.Point(612, 281);
            this.txtCancelQty.Name = "txtCancelQty";
            this.txtCancelQty.Size = new System.Drawing.Size(217, 29);
            this.txtCancelQty.TabIndex = 30;
            this.txtCancelQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(448, 284);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 20);
            this.label15.TabIndex = 29;
            this.label15.Text = "Cancel Qty";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Location = new System.Drawing.Point(726, 157);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(103, 29);
            this.txtDiscount.TabIndex = 31;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmCancelDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(847, 436);
            this.ControlBox = false;
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtCancelQty);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboAction);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCancel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtVoid);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTransNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCancelDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCancelDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.TextBox txtTransNo;
        public System.Windows.Forms.TextBox txtPCode;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtPrice;
        public System.Windows.Forms.TextBox txtQty;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtCancelQty;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtDiscount;
        public System.Windows.Forms.TextBox txtCancel;
        public System.Windows.Forms.TextBox txtVoid;
        public System.Windows.Forms.ComboBox cboAction;
        public System.Windows.Forms.TextBox txtReason;
    }
}