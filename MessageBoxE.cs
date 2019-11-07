using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Net;
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
namespace WindowsFormsApp14
{
    public partial class MessageBoxE : Form
    {
        public String Typ;
        public String Srn;
        public String Cls;
        public String UserId;
        public String Conn;
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int Reserved);
        public MessageBoxE(String Type, String Class, String Srno, String Id,String c)
        {
            InitializeComponent();
            Typ = Type;
            Srn = Srno;
            Cls = Class;
            UserId = Id;
            Conn = c;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("test.pdf", FileMode.Create));
            doc.Open();
            Paragraph p = new Paragraph("Here is Your Invoice"+"\n\n\n\n");
            System.Drawing.Image pimage = System.Drawing.Image.FromFile("logo1.jpg");

            iTextSharp.text.Image iTextImage = iTextSharp.text.Image.GetInstance(pimage, System.Drawing.Imaging.ImageFormat.Png);
            iTextImage.Alignment = Element.ALIGN_CENTER;
            doc.Add(iTextImage);
            PdfPTable table = new PdfPTable(2);

            table.DefaultCell.Padding = 1;
            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            table.AddCell("Type");
            table.AddCell(Typ);
            table.AddCell("Class");
            table.AddCell(Cls);
            table.AddCell("Service NO.");
            table.AddCell(Srn);

            doc.Add(p);
            doc.Add(table);

            doc.Close();
           
            SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+Conn+";Integrated Security=True;Connect Timeout=30");
            c.Open();
            SqlCommand command = new SqlCommand("SELECT *" + "FROM Login", c);
            SqlDataReader reader = command.ExecuteReader();
            int Des;
            string password = "autotech3937", to = null;
            string body = "Here is your Invoice";
            string subject ="AutoTech-Invoice"; string smtp = "smtp.gmail.com";
            string from = "autotechsystem781@gmail.com";
            if (InternetGetConnectedState(out Des, 0))
            {


                while (reader.Read())
                {
                    if (UserId == reader["Id"].ToString())
                    {

                        to = reader["email"].ToString();
                    }

                }

                try
                {
                    MailMessage mail = new MailMessage(from, to, subject, body + subject);
                    SmtpClient client = new SmtpClient(smtp);
                    client.Port = 587;
                    mail.Attachments.Add(new Attachment("test.pdf"));
                    client.Credentials = new System.Net.NetworkCredential(from, password);
                    client.EnableSsl = true;
                    client.Send(mail);

                    MessageBox.Show("Mail sent");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MessageBoxE_Load(object sender, EventArgs e)
        {

        }
    }
}
