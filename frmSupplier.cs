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
    public partial class frmSupplier : Form
    {
        frmSupplierList f;
        SqlConnection cn;
        SqlCommand cm;
        DBConnection dbcon = new DBConnection();
        public frmSupplier(frmSupplierList f)
        {
            InitializeComponent();
            cn = new SqlConnection();
            cn.ConnectionString = dbcon.MyConnection();
            this.f = f;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("SAVE THIS RECORD? CLICK YES TO CONFIRM.", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tblSupplier(supplier, address, contactperson, telephone, email, fax)values(@supplier, @address, @contactperson, @telephone, @email, @fax)", cn);
                    cm.Parameters.AddWithValue("@supplier", txtSupplier.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@contactperson", txtContact.Text);
                    cm.Parameters.AddWithValue("@telephone", txtTelephone.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@fax", txtFax.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("RECORD HAS BEEN SUCCESSFULLY SAVED", "SAVE RECORD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.LoadRecords();
                }
            }catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Clear()
        {
            txtSupplier.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();
            txtFax.Clear();
            txtSupplier.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("UPDATE THIS RECORD? CLICK YES TO CONFIRM.", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE tblSupplier set supplier=@supplier, address=@address, contactperson=@contactperson, telephone=@telephone, email=@email, fax=@fax where id = @id", cn);
                    cm.Parameters.AddWithValue("@supplier", txtSupplier.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@contactperson", txtContact.Text);
                    cm.Parameters.AddWithValue("@telephone", txtTelephone.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@fax", txtFax.Text);
                    cm.Parameters.AddWithValue("@id", lblID.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("RECORD HAS BEEN SUCCESSFULLY UPDATED", "UPDATE RECORD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.LoadRecords();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
