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
    public partial class frmSecurity : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public string _pass, _username = "";
        public bool _isactive = false;
        public frmSecurity()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void FrmSecurity_Load(object sender, EventArgs e)
        {

        }

        private void MetroTextBox2_Click(object sender, EventArgs e) //txtPassword
        {

        }

        private void Button1_Click(object sender, EventArgs e) //btnCancel
        {
            if (MessageBox.Show("EXIT APPLICATION?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string  _role = "", _name = "";
            try
            {
                bool found = false;
                cn.Open();
                cm = new SqlCommand("Select * from tblUser where username = @username and password = @password", cn);
                cm.Parameters.AddWithValue("@username", txtUser.Text);
                cm.Parameters.AddWithValue("@password", txtPass.Text);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    found = true;
                    _username = dr["username"].ToString();
                    _role = dr["role"].ToString();
                    _name = dr["name"].ToString();
                    _pass = dr["password"].ToString();
                    _isactive = bool.Parse(dr["isactive"].ToString());
                }
                else
                {
                    found = false;
                }
                dr.Close();
                cn.Close();

                if (found == true)
                {
                    if (_isactive == false)
                    {
                        MessageBox.Show("Account is inactive. Unable to login", "INACTIVE ACCOUNT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (_role == "Cashier")
                    {
                        MessageBox.Show("WELCOME " + _name + "!", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPass.Clear();
                        txtUser.Clear();
                        this.Hide();
                        frmPOS frm = new frmPOS(this);
                        frm.lblUser.Text = _username;
                        frm.lblName.Text = _name + " | " + _role;
                        frm.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("WELCOME " + _name + "!", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPass.Clear();
                        txtUser.Clear();
                        this.Hide();
                        Form1 frm = new Form1();
                        frm.lblName.Text = _name;
                        frm.lblRole.Text = _role;
                        frm.lblUser.Text = _username;
                        frm._pass = _pass;
                        frm._user = _username;
                        frm.MyDashboard();
                        frm.ShowDialog();   
                    }
                }else
                {
                    MessageBox.Show("INVALID USERNAME OR PASSWORD!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
