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

namespace WindowsFormsApp14
{
    public partial class AccountDetails : MetroFramework.Forms.MetroForm
    {
        String U=null;
       
        SqlDataAdapter s;
        DataTable d;
        String Use;
       
        public AccountDetails(string userid,String conn)
        {
            InitializeComponent();
            Use = userid;
            U = conn;
            
            dataGridView1.Hide();

        }

       
        private void Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + U + ";Integrated Security=True;Connect Timeout=30");
          
            c.Open();
            s = new SqlDataAdapter("SELECT *" + "FROM Login"+" WHERE Id="+Use,c);

             d = new DataTable();
            s.Fill(d);
            dataGridView1.DataSource = d;
            c.Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+U+";Integrated Security=True;Connect Timeout=30");
            c.Open();
            s = new SqlDataAdapter(@"SELECT *" + "FROM Login WHERE Id="+Use, c);
            SqlCommandBuilder sda = new SqlCommandBuilder(s);
            s.Update(d);
           
            dataGridView1.DataSource = d;
            MessageBox.Show("Updated");
            c.Close();
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + U + ";Integrated Security=True;Connect Timeout=30");
            c.Open();
            SqlCommand s = new SqlCommand("DELETE" + " FROM Login" + " WHERE Id="+Use, c);
            s.ExecuteNonQuery();
            MessageBox.Show("Deleted");
        }

        private void AccountDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
