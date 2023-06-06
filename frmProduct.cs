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
    public partial class frmProduct : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        frmProductList Flist;
        String stitle = "Simple POS System";
        public frmProduct(frmProductList frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            Flist = frm;
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void LoadCategory()
        {
            cboCategory.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select category from tblcategory", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboCategory.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();
        }
        public void LoadBrand()
        {
            cboBrand.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select brand from tblbrand", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboBrand.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are you sure you want to save this product?", "Save Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string bid = "";
                    string cid = "";
                    cn.Open();
                    cm = new SqlCommand("Select id from tblBrand where brand like '" + cboBrand.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        bid = dr[0].ToString();
                    }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("Select id from tblCategory where category like '" + cboCategory.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        cid = dr[0].ToString();
                    }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tblProduct (pcode, barcode, pdesc, bid, cid, price, reorder) VALUES(@pcode, @barcode, @pdesc, @bid, @cid, @price, @reorder)", cn);
                    cm.Parameters.AddWithValue("@pcode", txtPcode.Text);
                    cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    cm.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                    cm.Parameters.AddWithValue("@bid", bid);
                    cm.Parameters.AddWithValue("@cid", cid);
                    cm.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                    cm.Parameters.AddWithValue("@reorder", int.Parse(txtReorder.Text));
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product has been successfully saved.");
                    Clear();
                    Flist.LoadRecords();
                }
            }catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }
        

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this product?", "Save Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   
                    cn.Open();
                    cm = new SqlCommand("UPDATE tblProduct set barcode=@barcode, pdesc=@pdesc, price=@price, reorder = @reorder where pcode like @pcode", cn);
                    cm.Parameters.AddWithValue("@pcode", txtPcode.Text);
                    cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    cm.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                    cm.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                    cm.Parameters.AddWithValue("@reorder", int.Parse(txtReorder.Text));
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product has been successfully updated.");
                    Clear();
                    Flist.LoadRecords();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public void Clear()
        {
            txtReorder.Clear();
            txtPrice.Clear();
            txtPdesc.Clear();
            txtPcode.Clear();
            txtBarcode.Clear();
            cboBrand.Text = "";
            cboCategory.Text = "";
            txtPcode.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                //accept . character
            }
            else if (e.KeyChar == 8)
            {
                //accept backspace
            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57)) //ASCII code 48-57 between 0-9
                e.Handled = true;
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                //accept . character
            }
            else if (e.KeyChar == 8)
            {
                //accept backspace
            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57)) //ASCII code 48-57 between 0-9
                e.Handled = true;
        }

        private void CboBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
