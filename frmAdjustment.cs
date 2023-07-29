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
    public partial class frmAdjustment : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        Form1 f;
        int _qty = 0;
        public frmAdjustment(Form1 f)
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

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        public void ReferenceNo()
        {
            Random rnd = new Random();
            txtRef.Text = rnd.Next().ToString();
        }

        public void LoadRecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("Select p.pcode, p.barcode, p.pdesc, b.brand, c.category, p.price, p.qty from tblProduct as p inner join tblBrand as b on b.id = p.bid inner join tblCategory as c on c.id = p.cid where p.pdesc like '%" + txtSearch.Text + "%' order by p.pdesc", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void TxtSearch_Click(object sender, EventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void CboCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                txtPcode.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDesc.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                _qty = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //validation for empty textbox

                if(int.Parse(txtQty.Text) > _qty)
                {
                    MessageBox.Show("STOCK ON HAND QUANTITY SHOULD BE GREATER THAN FROM ADJUSTMENT QTY.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //update stock
                if(cboCommand.Text == "REMOVE FROM INVENTORY")
                {
                    SqlStatement ("update tblproduct set qty = (qty - " + int.Parse(txtQty.Text) + ") where pcode like '" + txtPcode.Text + "'");
                }else if(cboCommand.Text == "ADD TO INVENTORY")
                {
                    SqlStatement("update tblproduct set qty = (qty + " + int.Parse(txtQty.Text) + ") where pcode like '" + txtPcode.Text + "'");
                }

                SqlStatement("insert into tbladjustment(referenceno, pcode, qty, action, remarks, sdate, [user])values('" + txtRef.Text + "','" + txtPcode.Text + "','" + int.Parse(txtQty.Text) + "','" + cboCommand.Text + "','" + txtRemarks.Text + "','" + DateTime.Now.ToShortDateString() + "','" + txtUser.Text + "')");

                MessageBox.Show("STOCK HAS BEEN SUCCESSFULLY ADJUSTED.", "PROCESS COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecords();
                Clear();
            } catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Clear()
        {
            txtDesc.Clear();
            txtPcode.Clear();
            txtQty.Clear();
            txtRef.Clear();
            txtRemarks.Clear();
            cboCommand.Text = "";
            ReferenceNo();
        }

        public void SqlStatement(string _sql)
        {
            cn.Open();
            cm = new SqlCommand(_sql, cn);
            cm.ExecuteNonQuery();
            cn.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
