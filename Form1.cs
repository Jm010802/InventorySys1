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
using System.Windows.Forms.DataVisualization.Charting;
namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        public string _pass, _user;
        public Form1()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            NotifyCriticalItems();
            //cn.Open();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            MyDashboard();
        }

        private void BtnBrand_Click_1(object sender, EventArgs e)
        {
            frmBrandList frm = new frmBrandList();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void Button1_Click_1(object sender, EventArgs e) //btnDashBoard
        {
            MyDashboard();
        }

        public void MyDashboard()
        {
            frmDashboard f = new frmDashboard();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.lblDailySales.Text = dbcon.DailySales().ToString("#,##0.00");
            f.lblProduct.Text = dbcon.ProductLine().ToString("#,##0");
            f.lblStockOnHand.Text = dbcon.StockOnHand().ToString("#,##0");
            f.lblCritical.Text = dbcon.CriticalItems().ToString("#,##0");
            f.BringToFront();
            f.Show();
        }

        private void Button2_Click_1(object sender, EventArgs e) //btnProduct
        {
            frmProductList frm = new frmProductList();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.LoadRecords();
            frm.Show();
        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void BtnCategory_Click(object sender, EventArgs e)
        {
            frmCategoryList frm = new frmCategoryList();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.LoadCategory();
            frm.Show();
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnStockIn_Click(object sender, EventArgs e)
        {
            frmStockIn frm = new frmStockIn();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void BtnPOS_Click(object sender, EventArgs e)
        {
            //frmPOS frm = new frmPOS();
            //frm.ShowDialog();
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            frmUserAccount frm = new frmUserAccount(this);
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.txtUser1.Text = _user;
            frm.BringToFront();
            frm.Show();
        }

        private void BtnSalesHistory_Click(object sender, EventArgs e)
        {
            frmSoldItems frm = new frmSoldItems();
            frm.ShowDialog();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("LOGOUT APPLICATION?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                frmSecurity frm = new frmSecurity();
                frm.ShowDialog();
            }
        }

        private void Button7_Click(object sender, EventArgs e) //Records
        {
            frmRecords frm = new frmRecords();
            frm.TopLevel = false;

            frm.LoadCriticalItems();
            frm.LoadInventory();
            frm.CancelledOrders();
            frm.LoadStockInHistory();
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void Button9_Click(object sender, EventArgs e)//btnStoreSetting
        {
            frmStore f = new frmStore();
            f.LoadRecords();
            f.ShowDialog();
        }

        private void BtnSupplier_Click(object sender, EventArgs e)
        {
            frmSupplierList frm = new frmSupplierList();
            frm.TopLevel = false;
            frm.LoadRecords();
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void BtnAdjustment_Click(object sender, EventArgs e)
        {
            frmAdjustment f = new frmAdjustment(this);
            f.ReferenceNo();
            f.LoadRecords();
            f.txtUser.Text = lblUser.Text;
            f.ShowDialog();
        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void Panel3_Resize(object sender, EventArgs e)
        {

        }
    }
}
