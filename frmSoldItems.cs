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

    public partial class frmSoldItems : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        //frmPOS fp;
        public string suser;
        public frmSoldItems()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            dt1.Value = DateTime.Now;
            dt2.Value = DateTime.Now;
            LoadRecord();
            LoadCashier();
            this.KeyPreview = true;
            //fp = frm;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmSoldItems_Load(object sender, EventArgs e)
        {

        }

        public void LoadRecord()
        { 
            int i = 0;
            double _total = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            if (cboCashier.Text == "All Cashier")
            {
                cm = new SqlCommand("select c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, total from tblcart as c inner join tblproduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between '" + dt1.Value + "' and '" + dt2.Value + "'", cn);
            }else
            {
                cm = new SqlCommand("select c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, total from tblcart as c inner join tblproduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between '" + dt1.Value + "' and '" + dt2.Value + "' and cashier like '" + cboCashier.Text + "'", cn);
            }
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                _total += double.Parse(dr["total"].ToString());
                dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["transno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), dr["total"].ToString());
            }
            dr.Close();
            cn.Close();
            lblTotal.Text = _total.ToString("#,##0.00");
        }

        private void Dt1_ValueChanged(object sender, EventArgs e)
        {
            LoadRecord();
        }

        private void Dt2_ValueChanged(object sender, EventArgs e)
        {
            LoadRecord();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            frmReportSold frm = new frmReportSold(this);
            frm.LoadReport();
            frm.ShowDialog();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colName == "colCancel")
            {
                frmCancelDetails f = new frmCancelDetails(this);
                f.txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                f.txtTransNo.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                f.txtPCode.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                f.txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                f.txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                f.txtQty.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                f.txtDiscount.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                f.txtTotal.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                f.txtCancel.Text = suser;
                f.ShowDialog();
            }
        }

        private void CboCashier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public void LoadCashier()
        {
            cboCashier.Items.Clear();
            cboCashier.Items.Add("All Cashier");
            cn.Open();
            cm = new SqlCommand("select * from tbluser where role like 'Cashier'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboCashier.Items.Add(dr["username"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void CboCashier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRecord();
        }

        private void FrmSoldItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
