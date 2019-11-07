using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }
       public string textBox1value
        {
            get { return textBox1.Text;}
        }
        public string combo
        {
            get { return (comboBox1.Text); }
        }
        public string textBox2value
        {
            get { return textBox2.Text; }
        }
        public string textBox3value
        {
            get { return textBox3.Text; }
        }
        public string textBox4value
        {
            get { return textBox4.Text; }
        }
        private void UserControl2_Load(object sender, EventArgs e)
        {
           
            
        }
    }
}
