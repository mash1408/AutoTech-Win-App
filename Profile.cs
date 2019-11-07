using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApp14
{
    public partial class Profile : Form
    {
        public String userId;
         String conn =null;
        public Profile(String s,String c)
        {
            InitializeComponent();
            label2.Text = "UserId" + s;
             userId = s;
            conn = c;
            
        }
       
        
        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Booking b = new Booking(userId,conn);
            b.ShowDialog();
            
            
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            
            AccountDetails a = new AccountDetails(userId,conn);
            a.ShowDialog();
                 
        }
        string path = Environment.CurrentDirectory + "/" + "ab.txt";
        private void Button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                MessageBox.Show("Merchanics Available :" + "14");
            }
            else
            {
                StreamReader s = new StreamReader(path);
                s.ReadLine();
                MessageBox.Show("Mechanics Available: " + s.ToString());
            }
        }
    }
}
