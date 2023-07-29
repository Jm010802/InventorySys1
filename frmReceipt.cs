using Microsoft.Reporting.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApp2
{
    public partial class frmReceipt : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        string store = "Hi-Power Badminton Court";
        string address = "BBL Compound, Canlalay, Biñan, Laguna";
        frmPOS f;
        public frmReceipt(frmPOS frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            f = frm;
            this.KeyPreview = true;
        }

        private void FrmReceipt_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void DtSoldBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        public void LoadReport(string pcash, string pchange)
        {
            ReportDataSource rptDataSource;
            try
            {
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report2.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                da.SelectCommand = new SqlCommand("select c.id, c.transno, c.pcode, c.price, c.qty, c.disc, c.total, c.sdate, c.status, p.pdesc from tblCart as c inner join tblProduct as p on p.pcode = c.pcode where transno like '" + f.lblTransno.Text + "'", cn);
                da.Fill(ds.Tables["dtSold"]);
                cn.Close();

                ReportParameter pVatable = new ReportParameter("pVatable", f.lblVatable.Text);
                ReportParameter pVat = new ReportParameter("pVat", f.lblVat.Text);
                ReportParameter pDiscount = new ReportParameter("pDiscount", f.lblDiscount.Text);
                ReportParameter pTotal = new ReportParameter("pTotal", f.lblTotal.Text);
                ReportParameter pCash = new ReportParameter("pCash", pcash);
                ReportParameter pChange = new ReportParameter("pChange", pchange);
                ReportParameter pStore = new ReportParameter("pStore", store);
                ReportParameter pAddress = new ReportParameter("pAddress", address);
                ReportParameter pTransaction = new ReportParameter("pTransaction", "Invoice #: " + f.lblTransno.Text);
                ReportParameter pCashier = new ReportParameter("pCashier", f.lblUser.Text);

                reportViewer1.LocalReport.SetParameters(pVatable);
                reportViewer1.LocalReport.SetParameters(pVat);
                reportViewer1.LocalReport.SetParameters(pDiscount);
                reportViewer1.LocalReport.SetParameters(pTotal);
                reportViewer1.LocalReport.SetParameters(pCash);
                reportViewer1.LocalReport.SetParameters(pChange);
                reportViewer1.LocalReport.SetParameters(pStore);
                reportViewer1.LocalReport.SetParameters(pAddress);
                reportViewer1.LocalReport.SetParameters(pTransaction);
                reportViewer1.LocalReport.SetParameters(pCashier);

                reportViewer1.LocalReport.SetParameters(pVatable);

                rptDataSource = new ReportDataSource("DataSet1", ds.Tables["dtSold"]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSource);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 90;
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void ReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void FrmReceipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
