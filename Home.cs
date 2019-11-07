using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Home : Form
    { String conn = null;
        public Home()
        {
            InitializeComponent();
            sidepanel.Height = Login.Height;
            sidepanel.Top = Login.Top;
            panel3.Height = Login.Height;
            panel3.Top = Login.Top;

            c1.BringToFront();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            sidepanel.Height = Login.Height;
            sidepanel.Top = Login.Top;
            panel3.Height = Login.Height;
            panel3.Top = Login.Top;
            c1.BringToFront();
            Login f = new Login(conn);
            f.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            sidepanel.Height = button2.Height;
            sidepanel.Top = button2.Top;
            panel3.Height = button2.Height;
            panel3.Top = button2.Top;
            Registration f = new Registration(conn);
            f.ShowDialog();
           

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            sidepanel.Height = button1.Height;
            sidepanel.Top = button1.Top;
            panel3.Height = button1.Height;
            panel3.Top = button1.Top;
            DashBoard d = new DashBoard();
            d.Show();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       

      

        private void Button3_Click_2(object sender, EventArgs e)
        {
            sidepanel.Height = button3.Height;
            sidepanel.Top = button3.Top;
            panel3.Height = button3.Height;
            panel3.Top = button3.Top;
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            string sFileName = null;
            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                sFileName = choofdlog.FileName;

            }
            conn = sFileName;
            MessageBox.Show(conn);
        }
    }
}
