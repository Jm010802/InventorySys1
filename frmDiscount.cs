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
    public partial class frmDiscount : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        String stitle = "Simple POS System";
        frmPOS f;
        public frmDiscount(frmPOS frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            f = frm;
            this.KeyPreview = true;
        }

        private void FrmDiscount_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TxtPercent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double discount = Double.Parse(txtPrice.Text) * Double.Parse(txtPercent.Text);
                txtAmount.Text = discount.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                txtAmount.Text = "0.00";    
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Add discount? Click yes to confirm.", stitle, MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblcart set disc = @disc, disc_percent = @disc_percent  where id = @id", cn);
                    cm.Parameters.AddWithValue("@disc", Double.Parse(txtAmount.Text));
                    cm.Parameters.AddWithValue("@disc_percent", Double.Parse(txtPercent.Text));
                    cm.Parameters.AddWithValue("@id", int.Parse(lblD.Text));
                    cm.ExecuteNonQuery();
                    cn.Close();
                    f.LoadCart();
                    this.Dispose();
                }
            }catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
