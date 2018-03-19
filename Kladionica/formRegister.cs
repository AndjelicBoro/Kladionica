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

namespace Kladionica
{
    public partial class formRegister : Form
    {
        /*************************************************/
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        /*************************************************/

        public formRegister()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (rbYes.Checked)
            {
                if (txtUsername.Text == "" || txtPassword.Text == "" || txtPassword.Text != textBox2.Text)
                {
                    MessageBox.Show("Uneti podaci nisu ispravni");
                }
                else
                {
                    using (SqlConnection con = new SqlConnection("Data Source=BOROA;Initial Catalog=MaturskiRad;Integrated Security=True"))
                    {
                        con.Open();


                    }
                    /*if (txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "" && txtPassword.Text == txtConfirmPassword.Text)
                    {
                        MessageBox.Show("Please fill mendatory fiels");
                    }
                    using (SqlConnection con = new SqlConnection("Data Source=BOROA;Initial Catalog=MaturskiRad;Integrated Security=True"))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("UserAdd", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registration successfull");*/

                }
            }
            else
            {
                MessageBox.Show("Zao nam je, aplikaciju za kladjenje mogu da koriste samo punoletne osobe.");
                Application.Exit();
            }
        }
    }
}
