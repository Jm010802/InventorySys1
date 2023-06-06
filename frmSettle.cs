using System;
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
    public partial class frmSettle : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        frmPOS fpos;
        public frmSettle(frmPOS fp)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            fpos = fp;
            this.KeyPreview = true;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TxtCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double sale = double.Parse(txtSale.Text);
                double cash = double.Parse(txtCash.Text);
                double change = cash - sale;
                txtChange.Text = change.ToString("#,##0.00");
            }catch(Exception ex)
            {
                txtChange.Text = "0.00";
            }
        }

        private void TxtSale_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtChange_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn8.Text;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn9.Text;
        }

        private void BtnSave_Click(object sender, EventArgs e) //settle payment (btn7)
        {
            txtCash.Text += btn7.Text;
        }

        private void Button10_Click(object sender, EventArgs e) //settle payment (btnc)
        {
            txtCash.Clear();
            txtCash.Focus();
        }

        private void Button11_Click(object sender, EventArgs e) //settle payment (btn0)
        {
            txtCash.Text += btn0.Text;
        }

        private void Button12_Click(object sender, EventArgs e) //settle payment (btn6)
        {
            txtCash.Text += btn6.Text; 
        }

        private void Button13_Click(object sender, EventArgs e) //settle payment (btn5)
        {
            txtCash.Text += btn5.Text;
        }

        private void Button14_Click(object sender, EventArgs e) //settle payment (btn4)
        {
            txtCash.Text += btn4.Text;
        }

        private void Button18_Click(object sender, EventArgs e) //settle payment (btn1)
        {
            txtCash.Text += btn1.Text;
        }

        private void Button17_Click(object sender, EventArgs e) //settle payment (btn2)
        {
            txtCash.Text += btn2.Text;
        }

        private void Button21_Click(object sender, EventArgs e) //settle payment (btnEnter)
        {
            try
            {
                if ((double.Parse(txtChange.Text) < 0) || (txtCash.Text == string.Empty))
                {
                    MessageBox.Show("Insufficient amount. Please enter the correct amount!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    for (int i = 0; i < fpos.dataGridView1.Rows.Count; i++)
                    {
                        cn.Open();
                        cm = new SqlCommand("update tblproduct set qty = qty -" + int.Parse(fpos.dataGridView1.Rows[i].Cells[5].Value.ToString()) + " where pcode = '" + fpos.dataGridView1.Rows[i].Cells[2].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new SqlCommand("update tblcart set status = 'Sold' where id = '" + fpos.dataGridView1.Rows[i].Cells[1].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                    }
                    frmReceipt frm = new frmReceipt(fpos);
                    frm.LoadReport(txtCash.Text, txtChange.Text);
                    frm.ShowDialog();

                    MessageBox.Show("Payment has been successfully saved!", "PAYMENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fpos.GetTransNo();
                    fpos.LoadCart();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insufficient amount. Please enter the correct amount!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button16_Click(object sender, EventArgs e) //settle payment (btn3)
        {
            txtCash.Text += btn3.Text;
        }

        private void Button15_Click(object sender, EventArgs e) //settle payment (btn00)
        {
            txtCash.Text += btn00.Text;
        }

        private void FrmSettle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Button21_Click(sender, e); //btn Enter
            }
        }
    }
}
