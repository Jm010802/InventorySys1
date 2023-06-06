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
    public partial class frmSearchProductStockin : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        String stitle = "Simple POS System";
        frmStockIn slist;
        public frmSearchProductStockin(frmStockIn flist)
        {
            InitializeComponent();
            slist = flist;
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void LoadProduct()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("Select pcode, pdesc, qty from tblproduct where pdesc like '%" + txtSearch.Text + "%' order by pdesc", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                if (slist.txtRefNo.Text == string.Empty) { MessageBox.Show("Please enter reference no", stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning); slist.txtRefNo.Focus(); return; }
                if (slist.txtBy.Text == string.Empty) { MessageBox.Show("Please enter stock in by", stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning); slist.txtBy.Focus(); return; }
                if (MessageBox.Show("Add this item?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblstockin (refno, pcode, sdate, stockinby, supplierid)values(@refno, @pcode, @sdate, @stockinby, @supplierid)", cn);
                    cm.Parameters.AddWithValue("@refno", slist.txtRefNo.Text);
                    cm.Parameters.AddWithValue("@pcode", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cm.Parameters.AddWithValue("@sdate", slist.dt1.Value);
                    cm.Parameters.AddWithValue("@stockinby", slist.txtBy.Text);
                    cm.Parameters.AddWithValue("@supplierid", slist.lblSupplierID.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show("Successfully added!", stitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    slist.LoadStockIn();
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
