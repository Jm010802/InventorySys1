using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class frmCancelDetails : Form
    {
        frmSoldItems f;
        public frmCancelDetails(frmSoldItems frm)
        {
            InitializeComponent();
            f = frm;
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmCancelDetails_Load(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CboAction_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if((cboAction.Text!=String.Empty) && (txtQty.Text != String.Empty) && (txtReason.Text != String.Empty))
                {
                    if(int.Parse(txtQty.Text) >= int.Parse(txtCancelQty.Text))
                    {
                        frmVoid f = new frmVoid(this);
                        f.ShowDialog();
                    }   
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void RefreshList()
        {
            f.LoadRecord();

        }
    }
}
