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
using System.Windows.Forms.DataVisualization.Charting;
namespace WindowsFormsApp2
{
    public partial class frmRecords : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        public frmRecords()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadRecord()
        {
            int i = 0;
            cn.Open();
            dataGridView1.Rows.Clear();
            if (cboTopSelect.Text == "SORT BY QTY")
            {
                cm = new SqlCommand("select top 10 pcode, pdesc, isnull(sum(qty),0) as qty, isnull(sum(total),0) as total from vwSoldItems where sdate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and status like 'Sold' group by pcode, pdesc order by qty desc", cn);
            }
            else if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
                cm = new SqlCommand("select top 10 pcode, pdesc, isnull(sum(qty),0) as qty, isnull(sum(total),0) as total from vwSoldItems where sdate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and status like 'Sold' group by pcode, pdesc order by total desc", cn);
            }
            
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["qty"].ToString(), double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
            }
            dr.Close();
            cn.Close();
        }

        public void CancelledOrders()
        {
            int i = 0;
            dataGridView5.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from vwcancelledorder where sdate between '" + dateTimePicker5.Value.ToString() + "' and '" + dateTimePicker6.Value.ToString() + "'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView5.Rows.Add(i, dr["transno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["total"].ToString(), dr["sdate"].ToString(), dr["voidby"].ToString(), dr["cancelledby"].ToString(), dr["reason"].ToString(), dr["action"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e) //Load Data (SOLD ITEMS)
        {
            
        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadInventory()
        {
            int i = 0;
            dataGridView4.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select p.pcode, p.barcode, p.pdesc, b.brand, c.category, p.price, p.qty, p.reorder from tblProduct as p inner join tblbrand as b on p.bid=b.id inner join tblcategory as c on p.cid=c.id", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView4.Rows.Add(i, dr["pcode"].ToString(), dr["barcode"].ToString(), dr["pdesc"].ToString(), dr["brand"].ToString(), dr["category"].ToString(), dr["price"].ToString(), dr["reorder"].ToString(), dr["qty"].ToString());

            }
            dr.Close();
            cn.Close();
        }
        
        public void LoadCriticalItems()
        {
            try
            {
                dataGridView3.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("select * from vwCriticalItems", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dataGridView3.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());

                }
                dr.Close();
                cn.Close();
            }catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport frm = new frmInventoryReport();
            frm.LoadReport();
            frm.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }

        public void LoadStockInHistory()
        {
            int i = 0;
            dataGridView6.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from vwStockin where cast (sdate as date) between'" + dateTimePicker7.Value.ToShortDateString() + "' and '" + dateTimePicker8.Value.ToShortDateString() + "' and status like 'Done'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView6.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToShortDateString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void TabPage6_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport f = new frmInventoryReport();
            if (cboTopSelect.Text == "SORT BY QTY")
            {
                f.LoadTopSelling("select top 10 pcode, pdesc, isnull(sum(qty),0) as qty, isnull(sum(total),0) as total from vwSoldItems where sdate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and status like 'Sold' group by pcode, pdesc order by qty desc", "From : " + dateTimePicker1.Value.ToString() + " To : " + dateTimePicker2.Value.ToString(),"TOP 10 SELLING ITEMS SORT BY QTY");
            }
            else if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
                f.LoadTopSelling("select top 10 pcode, pdesc, isnull(sum(qty),0) as qty, isnull(sum(total),0) as total from vwSoldItems where sdate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and status like 'Sold' group by pcode, pdesc order by total desc", "From : " + dateTimePicker1.Value.ToString() + " To : " + dateTimePicker2.Value.ToString(), "TOP 10 SELLING ITEMS SORT BY TOTAL AMOUNT");
            }


           
           
            f.ShowDialog();
        }

        private void LinkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport f = new frmInventoryReport();
            f.LoadSoldItems("select c.pcode, p.pdesc, c.price, sum(c.qty) as qty, sum(c.disc) as disc, sum(c.total) as total from tblcart as c inner join tblProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between '" + dateTimePicker4.Value.ToString() + "' and '" + dateTimePicker3.Value.ToString() + "' group by c.pcode, p.pdesc, c.price", "From : " + dateTimePicker4.Value.ToString() + " To : " + dateTimePicker3.Value.ToString());
            f.ShowDialog();
        }

        private void DataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LinkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cboTopSelect.Text == String.Empty)
            {
                MessageBox.Show("Please select from the dropdown list.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadRecord();
            LoadChartTopSelling();
        }

        public void LoadChartTopSelling()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            cn.Open();
            if (cboTopSelect.Text == "SORT BY QTY")
            {
                 da = new SqlDataAdapter("select top 10 pcode, isnull(sum(qty),0) as qty from vwSoldItems where sdate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and status like 'Sold' group by pcode order by qty desc", cn);
            }
            else if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
                 da = new SqlDataAdapter("select top 10 pcode, isnull(sum(total),0) as total from vwSoldItems where sdate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and status like 'Sold' group by pcode order by total desc", cn);
            }
            DataSet ds = new DataSet();
            da.Fill(ds, "TOPSELLING");
            chart1.DataSource = ds.Tables["TOPSELLING"];
            Series series = chart1.Series[0];
            series.ChartType = SeriesChartType.Pie;

            series.Name = "TOP SELLING";
            var chart = chart1;
            chart.Series[0].XValueMember = "pcode";
            if (cboTopSelect.Text == "SORT BY QTY")
            {
                chart.Series[0].YValueMembers = "qty";
            }
            if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
                chart.Series[0].YValueMembers = "total";
            }
            chart.Series[0].IsValueShownAsLabel = true;
            if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
                chart.Series[0].LabelFormat = "{#,##0.00}";
            }
            if (cboTopSelect.Text == "SORT BY QTY")
            {
                chart.Series[0].LabelFormat = "{#,##0}";
            }
            if (cboTopSelect.Text == "SORT BY QTY")
            {
                chart.Series[0].Font = new Font("Consolas", 8f, FontStyle.Regular);
            }
            if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
                chart.Series[0].Font = new Font("Consolas", 8f, FontStyle.Regular);
            }
            if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
                chart1.Series[0]["PieLabelStyle"] = "Outside";
                chart1.Series[0].BorderWidth = 1;
                chart1.Series[0].BorderColor = Color.FromArgb(0, 0, 0);
            }
            cn.Close();
        }

        private void CboTopSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void LinkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                dataGridView2.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("select c.pcode, p.pdesc, c.price, sum(c.qty) as qty, sum(c.disc) as disc, sum(c.total) as total from tblcart as c inner join tblProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between '" + dateTimePicker4.Value.ToString() + "' and '" + dateTimePicker3.Value.ToString() + "' group by c.pcode, p.pdesc, c.price", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dataGridView2.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), Double.Parse(dr["price"].ToString()).ToString("#,##0.00"), dr["qty"].ToString(), dr["disc"].ToString(), Double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
                }
                dr.Close();
                cn.Close();

                cn.Open();
                cm = new SqlCommand("select isnull(sum(total), 0) from tblcart where status like 'Sold' and sdate between '" + dateTimePicker4.Value.ToString() + "' and '" + dateTimePicker3.Value.ToString() + "'", cn);
                lblTotal.Text = Double.Parse(cm.ExecuteScalar().ToString()).ToString("#,##0.00");
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LblTotal_Click(object sender, EventArgs e)
        {

        }

        private void LinkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChart f = new frmChart();
            f.lblTitle.Text = "SOLD ITEMS [" + dateTimePicker4.Value.ToShortDateString() + " - " + dateTimePicker3.Value.ToShortDateString() + "]";
            f.LoadChartSold("select p.pdesc, sum(c.total) as total from tblcart as c inner join tblProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between '" + dateTimePicker4.Value.ToString() + "' and '" + dateTimePicker3.Value.ToString() + "' group by p.pdesc order by total desc");
            f.ShowDialog();
        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport frm = new frmInventoryReport();
            string param = "Date Covered: " + dateTimePicker7.Value.ToShortDateString() + " - " + dateTimePicker8.Value.ToShortDateString();
            frm.LoadStockInReport("select * from vwStockin where cast (sdate as date) between'" + dateTimePicker7.Value.ToShortDateString() + "' and '" + dateTimePicker8.Value.ToShortDateString() + "' and status like 'Done'", param);
            frm.ShowDialog();
        }

        private void LinkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadStockInHistory();
        }

        private void LinkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CancelledOrders();
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport frm = new frmInventoryReport();
            string param = "Date Covered: " + dateTimePicker5.Value.ToString() + " - " + dateTimePicker6.Value.ToString();
            frm.LoadCancelledOrder("select * from vwcancelledorder where sdate between '" + dateTimePicker5.Value.ToString() + "' and '" + dateTimePicker6.Value.ToString() + "'", param);
            frm.ShowDialog();
        }

        private void DataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LinkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
