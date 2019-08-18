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
using IronPdf;


namespace Tanmay1
{
    public partial class NewEntryForm : Form
    {
        String ev;
        public NewEntryForm(String x)
        {
            InitializeComponent();
            ev = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name, eventName, college, email, phone;
            int fees;
            name = textBox1.Text;
            eventName = textBox3.Text;
            college = textBox2.Text;
            email= textBox4.Text;
            phone = textBox5.Text;
            fees = Int32.Parse(textBox6.Text);

            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=demodb;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Entries values('" + name + "','" + eventName + "','" + college + "','" + email + "','" + phone + "','" + fees + "','" + ev +  "')";
            Console.WriteLine("insert into Entries values('" + name + "','" + eventName + "','" + college + "','" + email + "','" + phone + "'," + fees + ",'" + ev + "')");
            cmd.Connection = con;

            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                var pdf = new IronPdf.HtmlToPdf();
                var p = pdf.RenderHtmlAsPdf("<html><head><meta http-equiv=Content-Type content='text/html; charset=windows-1252'><meta name=Generator content='Microsoft Word 15 (filtered)'><style></style></head><body lang=EN-US><div class=WordSection1><p class=MsoNormal align=center style='margin-bottom:0in;margin-bottom:.0001pt;text-align:center'><img width=115 height=115src='D:\\C#project\\images\\com.m.iste2018.jpg' align=right hspace=12><img width=104height=94 src='D:\\C#project\\images\\logo.png' align=left hspace=12><b>KOLHAPURINSTITUE OF TECHNOLOGY’S</b></p><p class=MsoNormal align=center style='margin-bottom:0in;margin-bottom:.0001pt;text-align:center'><b><span style='font-size:14.0pt;line-height:107%'>COLLEGEOF ENGINEERING (AUTONOMOUS), KOLHAPUR.</span></b></p><p class=MsoNormal align=center style='margin-bottom:0in;margin-bottom:.0001pt;text-align:center'><b>Civil, CSE, Eln, Prod, Mech, Env, Engg. Accredited by NBA</b></p><p class=MsoNormal align=center style='margin-bottom:0in;margin-bottom:.0001pt;text-align:center'><b>‘A’ Grade by NAAC with CGPA 3.12</b></p><p class=MsoNormal>&nbsp;</p><p class=MsoNormal>&nbsp;</p><p class=MsoNormal>Name: NAME</p><p class=MsoNormal>College: COLLEGE</p><p class=MsoNormal>Event: EVENT</p><p class=MsoNormal>Email Id: EMAILID</p><p class=MsoNormal>Phone No: PHONENO</p><p class=MsoNormal>Fees Paid: FEESPAID</p><p class=MsoNormal>&nbsp;</p></div><body></html>");
                p.SaveAs(email+".pdf");
                MessageBox.Show("Record Inserted & Mailed");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            else
                MessageBox.Show("Not Inserted");

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new CoreMemberForm("");
            f.Show();
        }
    }
}
