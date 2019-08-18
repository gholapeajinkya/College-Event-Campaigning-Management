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
namespace Tanmay1
{
    public partial class FinanceForm : Form
    {
        String ev;
        public FinanceForm(String x)
        {
            InitializeComponent();
            ev = x;
            SqlConnection con1 = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=demodb;Integrated Security=True;Pooling=False");
            con1.Open();
            SqlCommand cnt = con1.CreateCommand();
            cnt.CommandText = "SELECT Sum(Fees)FROM Entries";
            var obj = cnt.ExecuteScalar();
            int result = obj != null ? (int)obj : 0;
            Console.WriteLine("Leena" + result);


            SqlConnection con2 = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=demodb;Integrated Security=True;Pooling=False");
            con2.Open();
            SqlCommand cnt2 = con2.CreateCommand();
            cnt2.CommandText = "SELECT Sum(Amount)FROM SponsorInfo where EventName= @a1";
            cnt2.Parameters.AddWithValue("@a1", ev);
            var obj2 = cnt2.ExecuteScalar();
            //int result2 = obj2 != null ? (int)obj2 : 0;
            int result2 = 0;
          
                if (!(obj2 is DBNull))
                    result2 = Convert.ToInt32(obj2);
         
           

            Console.WriteLine(result2);
            label3.Text =result2+"";
            label6.Text = result + "";
            int result3 = (int)result2 + result;
            label8.Text = result3 + "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           String sname =  textBox1.Text;
           int amt = Int32.Parse(textBox2.Text);
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=demodb;Integrated Security=True;Pooling=False");
            s.Open();
            Console.WriteLine("Works");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into SponsorInfo values('" + sname + "'," + amt + ",'" + ev + "')";
            cmd.Connection = s;
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
                MessageBox.Show("Record Inserted");
            else
                MessageBox.Show("Not Inserted");

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new CoreMemberForm("");
            f.Show();
        }
    }
}
