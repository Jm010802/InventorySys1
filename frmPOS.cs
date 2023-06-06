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
using Tulpep.NotificationWindow;
namespace WindowsFormsApp2
{
    public partial class frmPOS : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        string stitle = "Simple POS System";
        String id;
        String price;
        int qty;
        frmSecurity f;
        public frmPOS(frmSecurity frm)
        {
            InitializeComponent();
            lblDate.Text = DateTime.Now.ToLongDateString();
            cn = new SqlConnection(dbcon.MyConnection());
            this.KeyPreview = true;
            f = frm;
            NotifyCriticalItems();
        }

        public void NotifyCriticalItems()
        {
            string critical = "";
            cn.Open();
            cm = new SqlCommand("Select count(*) from vwCriticalItems", cn);
            string count = cm.ExecuteScalar().ToString();
            cn.Close();

            int i = 0;
            cn.Open();
            cm = new SqlCommand("Select * from vwCriticalItems", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                critical += i + ". " + dr["pdesc"].ToString() + Environment.NewLine;
            }
            dr.Close();
            cn.Close();

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.warning_sign_9760;
            popup.TitleText = count + " CRITICAL ITEM(S)";
            popup.ContentText = critical;
            popup.Popup();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void LblName_Click(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmPOS_Load(object sender, EventArgs e)
        {

        }

        private void Button18_Click(object sender, EventArgs e)
        {

        }

        private void Button15_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void Button16_Click(object sender, EventArgs e)
        {

        }

        private void Button17_Click(object sender, EventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {

        }

        private void Button12_Click(object sender, EventArgs e)
        {

        }

        private void Button13_Click(object sender, EventArgs e)
        {

        }

        private void Button14_Click(object sender, EventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {

        }

        private void Button21_Click(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click_1(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void GetTransNo()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                string transno;
                int count;
                cn.Open();
                cm = new SqlCommand("select top 1 transno from tblcart where transno like '" + sdate + "%' order by id desc", cn);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    transno = dr[0].ToString();
                    count = int.Parse(transno.Substring(8, 4));
                    lblTransno.Text = sdate + (count + 1);
                } else
                {
                    transno = sdate + "1001";
                    lblTransno.Text = transno;
                }
                dr.Close();
                cn.Close();

            }catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void BtnNew_Click(object sender, EventArgs e) //New Transaction
        {
            if (dataGridView1.Rows.Count > 0)
            {
                return;
            }
            GetTransNo();
            txtSearch.Enabled = true;
            txtSearch.Focus();
        }

        private void TxtSearch_Click(object sender, EventArgs e)
        {
           
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    string _pcode;
                    double _price;
                    int _qty;
                    cn.Open();
                    cm = new SqlCommand("select * from tblproduct where barcode like '" + txtSearch.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        qty = int.Parse(dr["qty"].ToString());
                        _pcode = dr["pcode"].ToString();
                        _price = double.Parse(dr["price"].ToString());
                        _qty = int.Parse(txtQty.Text);
                        dr.Close();
                        cn.Close();

                        AddToCart(_pcode, _price, _qty);
                    }
                    else
                    {
                        dr.Close();
                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddToCart(String _pcode, double _price, int _qty)
        {
            string id = "";
            bool found = false;
            int cart_qty = 0;
            cn.Open();
            cm = new SqlCommand("select * from tblcart where transno = @transno and pcode = @pcode", cn);
            cm.Parameters.AddWithValue("@transno", lblTransno.Text);
            cm.Parameters.AddWithValue("@pcode", _pcode);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                found = true;
                id = dr["id"].ToString();
                cart_qty = int.Parse(dr["qty"].ToString());
            }
            else
            {
                found = false;
            }
            dr.Close();
            cn.Close();

            if (found == true)
            {
                if (qty < (int.Parse(txtQty.Text) + cart_qty))
                {
                    MessageBox.Show("Unable to proceed. Remaining quantity on hand is " + qty, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cn.Open();
                cm = new SqlCommand("update tblcart set qty = (qty + " + _qty + ") where id = '" + id + "'", cn);
                cm.ExecuteNonQuery();
                cn.Close();

                txtSearch.SelectionStart = 0;
                txtSearch.SelectionLength = txtSearch.Text.Length;
                LoadCart();
                //this.Dispose();
            }
            else
            {
                if (qty < int.Parse(txtQty.Text))
                {
                    MessageBox.Show("Unable to proceed. Remaining quantity on hand is " + qty, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cn.Open();
                cm = new SqlCommand("insert into tblcart (transno, pcode, price, qty, sdate, cashier)values(@transno, @pcode, @price, @qty, @sdate, @cashier)", cn);
                cm.Parameters.AddWithValue("@transno", lblTransno.Text);
                cm.Parameters.AddWithValue("@pcode", _pcode);
                cm.Parameters.AddWithValue("@price", _price);
                cm.Parameters.AddWithValue("@qty", _qty);
                cm.Parameters.AddWithValue("@sdate", DateTime.Now);
                cm.Parameters.AddWithValue("@cashier", lblUser.Text);
                cm.ExecuteNonQuery();
                cn.Close();

                txtSearch.SelectionStart = 0;
                txtSearch.SelectionLength = txtSearch.Text.Length;
                LoadCart();
               // this.Dispose();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Remove this item?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from tblcart where id like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Item has successfully removed", stitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCart();
                }
            }
            else if (colName == "colAdd")
            {
                int i = 0;
                cn.Open();
                cm = new SqlCommand("select sum(qty) as qty from tblproduct where pcode like '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "' group by pcode", cn);
                i = int.Parse(cm.ExecuteScalar().ToString());
                cn.Close();

                if (int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()) < i)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblcart set qty = qty + " + int.Parse(txtQty.Text) + " where transno like '" + lblTransno.Text + "' and pcode like '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    LoadCart();
                }
                else
                {
                    MessageBox.Show("Remaining quantity on hand is " + i + " !", "OUT OF STOCK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (colName == "colRemove")
            {
                int i = 0;
                cn.Open();
                cm = new SqlCommand("select sum(qty) as qty from tblcart where pcode like '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and transno like '" + lblTransno.Text + "' group by transno, pcode", cn);
                i = int.Parse(cm.ExecuteScalar().ToString());
                cn.Close();

                if (i > 1)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblcart set qty = qty - " + int.Parse(txtQty.Text) + " where transno like '" + lblTransno.Text + "' and pcode like '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    LoadCart();
                }
                else
                {
                    MessageBox.Show("Remaining quantity on cart is " + i + " !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
        
        public void LoadCart()
        {
            try
            {
                Boolean hasrecord = false;
                dataGridView1.Rows.Clear();
                int i = 0;
                double total = 0;
                double discount = 0;
                cn.Open();
                cm = new SqlCommand("select c.id, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total from tblcart as c inner join tblproduct as p on c.pcode = p.pcode where transno like '" + lblTransno.Text + "' and status like 'Pending'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    total += Double.Parse(dr["total"].ToString());
                    discount += Double.Parse(dr["disc"].ToString());
                    dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), Double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
                    hasrecord = true;
                }
                dr.Close();
                cn.Close();
                lblTotal.Text = total.ToString("#,##0.00");
                lblDiscount.Text = discount.ToString("#,##0.00");
                GetCartTotal();
                if (hasrecord == true)
                {
                    btnSettle.Enabled = true;
                    btnDiscount.Enabled = true;
                    btnCancel.Enabled = true;
                } else
                {
                    btnSettle.Enabled = false;
                    btnDiscount.Enabled = false;
                    btnCancel.Enabled = false;
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cn.Close();
            }
        }

        private void Label6_Click_1(object sender, EventArgs e)
        {

        }

        public void GetCartTotal()
        {
            double discount = Double.Parse(lblDiscount.Text);
            double sales = double.Parse(lblTotal.Text);
            double vat = sales * dbcon.GetVal();
            double vatable = sales - vat;
            lblVat.Text = vat.ToString("#,##0.00");
            lblVatable.Text = vatable.ToString("#,##0.00");
            lblDisplayTotal.Text = sales.ToString("#,##0.00");
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (lblTransno.Text == "00000000000000")
            {
                return;
            }
            frmLookUp frm = new frmLookUp(this);
            frm.LoadRecords();
            frm.ShowDialog();
        }

        private void BtnDiscount_Click(object sender, EventArgs e)
        {
            frmDiscount frm = new frmDiscount(this);
            frm.lblD.Text = id;
            frm.txtPrice.Text = price;
            frm.ShowDialog();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            id = dataGridView1[1, i].Value.ToString();
            price = dataGridView1[7, i].Value.ToString();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:sstt");
            lblDate1.Text = DateTime.Now.ToLongDateString();
        }

        private void Label4_Click_1(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void LblDiscount_Click(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void LblVat_Click(object sender, EventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void LblVatable_Click(object sender, EventArgs e)
        {

        }

        private void BtnSettle_Click(object sender, EventArgs e)
        {
            frmSettle frm = new frmSettle(this);
            frm.txtSale.Text = lblDisplayTotal.Text;
            frm.ShowDialog();
        }
        
        private void BtnSale_Click(object sender, EventArgs e)
        {
            frmSoldItems frm = new frmSoldItems();
            frm.dt1.Enabled = false;
            frm.dt2.Enabled = false;
            frm.suser = lblUser.Text;
            frm.cboCashier.Enabled = false;
            frm.cboCashier.Text = lblUser.Text;
            frm.ShowDialog();
        }

        private void Button7_Click(object sender, EventArgs e) //Logout Button
        {
            if(dataGridView1.Rows.Count > 0)
            {
                MessageBox.Show("Unable to logout. Please cancel the transaction.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("LOGOUT APPLICATION?", "LOGOUT",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                frmSecurity frm = new frmSecurity();
                frm.ShowDialog();
            }
        }

        private void FrmPOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BtnNew_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2)
            {
                BtnSearch_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                BtnDiscount_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                BtnSettle_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                BtnCancel_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                BtnSale_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F7)
            {
                BtnChangePass_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                txtSearch.SelectionStart = 0;
                txtSearch.SelectionLength = txtSearch.Text.Length;
            }
            else if (e.KeyCode == Keys.F10)
            {
                Button7_Click(sender, e);
            }
            

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Remove all items from cart?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                cn.Open();
                cm = new SqlCommand("delete from tblcart where transno like '" + lblTransno.Text + "'", cn);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("All items has been successfully remove!", "REMOVE ITEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCart();
            }
        }

        private void BtnChangePass_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(this);
            frm.ShowDialog();
        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LblUser_Click(object sender, EventArgs e)
        {

        }
    }
}
