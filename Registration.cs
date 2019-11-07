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
using System.Data.Sql;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Web;
using System.Net;
namespace WindowsFormsApp14
{
    public partial class Registration : Form
    { String conn = null;
        public Registration(String c)
        {
            InitializeComponent( );
            toppanel.Height = button2.Height;
            userControl21.BringToFront();
            panel3.Width = 0;
            conn = c;
            panel3.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }


        private void Button1_Click(object sender, EventArgs e)
        {
            userControl31.BringToFront();
            toppanel.Height = button3.Height;
            toppanel.Top = button3.Top;



        }

        public void Toppanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            toppanel.Height = button3.Height;
            toppanel.Top = button3.Top;

           
            

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            toppanel.Height = button2.Height;
            toppanel.Top = button2.Top;
            userControl21.BringToFront();
        }

        private void UserControl31_Load(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+conn+";Integrated Security=True;Connect Timeout=30");
            c.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Login (Id,Password,email,mobile,registration,chassis,engine,brand,class,age,name,gender) VALUES(@Id,@Password,@email,@mobile,@registration,@chassis,@engine,@brand,@class,@age,@name,@gender)", c);
            cmd.Parameters.Add("@Password", userControl21.textBox2value);
            cmd.Parameters.Add("@mobile", userControl21.textBox2value);
            cmd.Parameters.Add("@Id", userControl21.textBox3value);
            cmd.Parameters.Add("@email", userControl31.textBox2value);
            cmd.Parameters.Add("@age", userControl21.textBox4value);
            cmd.Parameters.Add("@gender", userControl21.combo);
            cmd.Parameters.Add("@name", userControl21.textBox1value);
          
            cmd.Parameters.Add("@registration", userControl31.textBox2value);
            cmd.Parameters.Add("@chassis", userControl31.textBox4value);
            cmd.Parameters.Add("@engine", userControl31.textBox5value);
            cmd.Parameters.Add("@brand", userControl31.textBox3value);
            cmd.Parameters.Add("@class", userControl31.textBox1value);
            try
            {
                cmd.ExecuteNonQuery();
                panel3.Show();
                timer1.Start();
                
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            panel3.Width += 25;
            if(panel3.Width>=296)
            {
                timer1.Stop();
                MessageBox.Show("SAVED");
                this.Close();
            }
        }
    }
}
