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
    public partial class frmDashboard : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        DBConnection dbcon = new DBConnection();
        public frmDashboard()
        {
            InitializeComponent();
            cn = new SqlConnection();
            cn.ConnectionString = dbcon.MyConnection();
            LoadChart();
        }

        private void FrmDashboard_Resize(object sender, EventArgs e)
        {
            panel1.Left = (this.Width - panel1.Width) / 2;
        }

        public void LoadChart()
        {
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select Year(sdate) as year, isnull(sum(total),0.0) as total from tblcart where status like 'Sold' group by Year(sdate)", cn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Sales");
            chart1.DataSource = ds.Tables["Sales"];
            Series series1 = chart1.Series["Series1"];
            series1.ChartType = SeriesChartType.Pie;

            series1.Name = "SALES";

            var chart = chart1;
            chart.Series[series1.Name].XValueMember = "year";
            chart.Series[series1.Name].YValueMembers = "total";
            chart.Series[0].IsValueShownAsLabel = true;
            chart.Series[0].Font = new Font("Consolas", 12, FontStyle.Regular);
            chart.Series[0].LabelFormat = "#,##0.00";


            cn.Close();
        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
