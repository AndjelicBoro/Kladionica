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
    public partial class Pocetna : Form
    {


        public Pocetna()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
        }
        void Clear()
        {
            txtUsername.Text = txtPassword.Text = "";
        }

        private void btnLogIn_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=BOROA;Initial Catalog=MaturskiRad;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from user1 where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
                count += 1;
            if (count == 1)
            {
                MessageBox.Show("Ok");
                Home formHome = new Home();
                formHome.Show();
                this.Hide();
            }
            else if (count > 0)
            {
                MessageBox.Show("Duplicate username and password");
            }
            else
            {
                MessageBox.Show("Username or password not correct");
            }
            txtUsername.Clear();
            txtPassword.Clear();
            con.Close();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            formRegister reg = new formRegister();
            reg.ShowDialog();
           /* if (txtUsername.Text == "" || txtPassword.Text == "")
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
                MessageBox.Show("Registration successfull");
                Clear();
            }*/
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text != "")
            {
                txtUsername.Text = txtUsername.Text;
            }
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text != "")
            {
                txtPassword.Text = txtPassword.Text;
            }
            if (txtPassword.Text == "Pas#Sw0rd.#2!")
            {
                txtPassword.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        /*************************************************/
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        /*************************************************/
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lblBet_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnLogIn_MouseEnter(object sender, EventArgs e)
        {
            
        }
    }
}
