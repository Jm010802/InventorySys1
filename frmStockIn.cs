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
    public partial class frmStockIn : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        String stitle = "Simple POS System";
        public frmStockIn()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadSupplier();
        }
       

        private void FrmStockIn_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void LoadStockIn()
        {
            int i=0;
            dataGridView2.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from vwStockin where refno like '" + txtRefNo.Text + "' and status like 'Pending'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr["supplier"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void TxtBy_TextChanged(object sender, EventArgs e) //Stock In By (TextBox)
        {

        }

        private void Dt1_ValueChanged(object sender, EventArgs e) //Stock In Date (DateTimePicker)
        {

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtRefNo_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadStockInHistory()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from vwStockin where cast (sdate as date) between'" + date1.Value.ToShortDateString() + "' and '" + date2.Value.ToShortDateString() + "' and status like 'Done'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToShortDateString(), dr[6].ToString(), dr["supplier"].ToString());
            }
            dr.Close();
            cn.Close();
        }
        public void Clear()
        {
            txtAddress.Clear();
            txtPerson.Clear();
            cboSupplier.Text = "";
            txtBy.Clear();
            txtRefNo.Clear();
            dt1.Value = DateTime.Now;
        }
        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView2.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Remove this item?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from tblstockin where id = '" + dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show("Item has been successfully removed.", stitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStockIn();
                }
            }
        }

        private void TxtSearch_Click(object sender, EventArgs e)
        {

        }

        private void TxtRefNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSearchProductStockin frm = new frmSearchProductStockin(this);
            frm.LoadProduct();
            frm.ShowDialog();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to save this records?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            //update tblproduct qty
                            cn.Open();
                            cm = new SqlCommand("update tblproduct set qty = qty + " + int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString()) + " where pcode like '" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();

                            //update tblstockin qty
                            cn.Open();
                            cm = new SqlCommand("update tblstockin set qty = qty + " + int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString()) + ", status = 'Done' where id like '" + dataGridView2.Rows[i].Cells[1].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();
                        }
                        Clear();
                        LoadStockIn();
                    }
                }
            }catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Delete1")
            {
                if (MessageBox.Show("Remove this item?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from tblstockin where id = '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    LoadStockIn();
                    
                    

                    MessageBox.Show("Item has been successfully removed.", stitle, MessageBoxButtons.OK, MessageBoxIcon.Information);                
                }
            }
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            LoadStockInHistory();
        }

        public void LoadSupplier()
        {
            cboSupplier.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select * from tblsupplier", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboSupplier.Items.Add(dr["supplier"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void CboSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void CboSupplier_TextChanged(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("select * from tblsupplier where supplier like '" + cboSupplier.Text + "'", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                lblSupplierID.Text = dr["id"].ToString();   
                txtPerson.Text = dr["contactperson"].ToString();
                txtAddress.Text = dr["address"].ToString();
            }
            dr.Close();
            cn.Close();
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Random rnd = new Random();
            txtRefNo.Clear();
            txtRefNo.Text += rnd.Next();
        }

        private void CboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
