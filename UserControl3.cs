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
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }
       public string textBox1value
        {
            get { return (textBox1.Text); }
        }
        public string textBox2value
        {
            get { return (textBox2.Text); }
        }
        public string textBox3value
        {
            get { return (textBox3.Text); }
        }
        public string textBox4value
        {
            get { return (textBox4.Text); }
        }
        public string textBox5value
        {
            get { return (textBox5.Text); }
        }
        public void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserControl3_Load(object sender, EventArgs e)
        {

        }
    }
}
