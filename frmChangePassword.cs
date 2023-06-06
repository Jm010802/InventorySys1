﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp2
{
    public partial class frmChangePassword : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        DBConnection dbcon = new DBConnection();
        frmPOS f;
        
        public frmChangePassword(frmPOS frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            f = frm;
            this.KeyPreview = true;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string _oldpass = dbcon.GetPassword(f.lblUser.Text);
                if (_oldpass != txtOld.Text)
                {
                    MessageBox.Show("Old password did not matched!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else if (txtNew.Text != txtConfirm.Text)
                {
                    MessageBox.Show("Confirm new password did not matched!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else
                {
                    if (MessageBox.Show("CHANGE PASSWORD?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("Update tbluser set password =@password where username = @username", cn);
                        cm.Parameters.AddWithValue("@password", txtNew.Text);
                        cm.Parameters.AddWithValue("@username", f.lblUser.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Password has been successfully saved!", "SAVE CHANGES", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
            }
        }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtPass_Click(object sender, EventArgs e)
        {

        }

        private void FrmChangePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
