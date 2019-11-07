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
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Threading;
using Microsoft.Build.Tasks;

namespace WindowsFormsApp14
{
    public partial class Login : Form
    {
        String u =null;
        int flag = 0;
        int move = 2;
        string s = null;
        [DllImport("wininet.dll")] private extern static bool InternetGetConnectedState(out int Description, int Reserved);
        
        public Login(String conn)
        {
            u = conn;
            InitializeComponent();
            metroProgressSpinner2.Hide();
        }
        struct DataParameter 
        {
            public int Process;
            public int Delay;

        }
        private DataParameter _inputparameter;

        private void Button1_Click(object sender, EventArgs e)
        {
            if(!backgroundWorker1.IsBusy)
            {
                _inputparameter.Delay = 100;
                _inputparameter.Process = 1200;
                backgroundWorker1.RunWorkerAsync(_inputparameter);
            }
            

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+u+";Integrated Security=True;Connect Timeout=30");
            c.Open();
            SqlCommand command = new SqlCommand("SELECT *" + "FROM Login", c);
            SqlDataReader reader = command.ExecuteReader();
            int Des;
            string password = "autotech3937", to = null;
            string body = "password reset\n huh forget it";
            string subject = null; string smtp = "smtp.gmail.com";
            string from = "autotechsystem781@gmail.com";
            if (InternetGetConnectedState(out Des, 0))
            {


                while (reader.Read())
                {
                    if (textBox1.Text == reader["Id"].ToString())
                    {
                        subject = reader["Password"].ToString();
                        to = reader["email"].ToString();
                    }

                }

                try
                {
                    MailMessage mail = new MailMessage(from, to, subject, body + subject);
                    SmtpClient client = new SmtpClient(smtp);
                    client.Port = 587;

                    client.Credentials = new System.Net.NetworkCredential(from, password);
                    client.EnableSsl = true;
                    client.Send(mail);

                    MessageBox.Show("Mail sent");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else { MessageBox.Show("No internet available"); }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                {
                    textBox2.UseSystemPasswordChar = false;
                }
            else
            {
                textBox2.UseSystemPasswordChar =true;
            }
                }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            metroProgressSpinner2.Show();
            metroProgressSpinner2.Spinning = true;
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {if (flag == 1)
            {
                MessageBox.Show("Completed");
                this.Hide();
                Profile p = new Profile(s,u);
                p.ShowDialog();
            }
          
               
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int process = ((DataParameter)e.Argument).Process;
            int delay=((DataParameter)e.Argument).Delay;
            int index = 1;
            try
            {
                for(int i=0;i<process;i++)
                {
                    if(!backgroundWorker1.CancellationPending)
                    {
                        flag =0;
                        
                        backgroundWorker1.ReportProgress(index++ * 100 / process, string.Format("Process data {0}", i));
                        Thread.Sleep(delay);
                        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + u + ";Integrated Security=True;Connect Timeout=30");

                        c.Open();
                        SqlCommand command = new SqlCommand("SELECT *" + "FROM Login", c);

                        try
                        {

                           
                            SqlDataReader reader = command.ExecuteReader();
                           
                            while (reader.Read())
                            {
                                if (textBox1.Text == reader["Id"].ToString())
                                {

                                    s = textBox1.Text;
                                    if (textBox2.Text == reader["Password"].ToString())
                                    {
                                        MessageBox.Show("Correct");


                                       

                                        flag = 1;
                                        backgroundWorker1.CancelAsync();
                                    }
                                    else
                                    {
                                        Console.Beep();
                                        MessageBox.Show("Wrong Password");
                                        textBox2.Text = "";
                                        flag = 0;
                                        
                                        backgroundWorker1.CancelAsync();
                                    }
                                }

                            }
                            if (flag == 0)
                            {
                                
                                MessageBox.Show("UserId Does not exist"); textBox1.Text = ""; textBox2.Text = ""; backgroundWorker1.CancelAsync();
                            }
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            backgroundWorker1.CancelAsync();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
            
                MessageBox.Show(ex.Message);
            }
        }
        
    }

    }

