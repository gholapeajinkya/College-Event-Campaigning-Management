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
    
    public partial class LoginForm : Form
    {
        public String eventName;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=demodb;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from MemberInfo where Email=@a1 and Password=@a2";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@a1", textBox1.Text);
            cmd.Parameters.AddWithValue("@a2", textBox2.Text);
            SqlDataReader sdr = cmd.ExecuteReader();
            Boolean flag = false;
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    MessageBox.Show("Login Successful" + sdr.GetString(1));
                    flag = true;
                }
            }
            else
                MessageBox.Show("Either username or Password is Wrong");
           
            sdr.Close();
            if (flag)
            {
                sdr = cmd.ExecuteReader();
                sdr.Read();
                eventName = sdr.GetString(5);
                // if core
                if (String.Compare(sdr.GetString(4), "Core") == 0)
                {
                    this.Hide();
                    var myForm = new CoreMemberForm(eventName);
                    myForm.Show();
                }
                // if not core
                else
                {
                    this.Hide();
                    var myForm = new NonCoreForm(eventName);
                    myForm.Show();
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new Form1();
            f.Show();
        }
    }
}
