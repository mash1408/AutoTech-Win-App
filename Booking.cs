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
    public partial class Booking : Form
    {
        public String userId;
        public String conn;
        public Booking(String s,String c)
        {
            InitializeComponent();
            userId= s;
            conn = c;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Focus();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Please Enter a issue and press enter.","Error",MessageBoxButtons.OK);
                textBox1.Focus();
            }
        }
  
        private void Button2_Click(object sender, EventArgs e)
        {

            
            MessageBoxE m = new MessageBoxE(comboBox1.SelectedItem.ToString(),comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(),userId,conn);
          this.Close();
            m.ShowDialog();
        }

        private void Booking_Load(object sender, EventArgs e)
        {

        }
    }
}
