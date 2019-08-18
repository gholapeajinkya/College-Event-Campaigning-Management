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
    public partial class EventHead : Form
    {
        String mainEvent;
        
        public EventHead(String mainEvent,String event1,String event2)
        {
            InitializeComponent();
            comboBox1.Items.Add("First Year");
            comboBox1.Items.Add("Second Year");
            comboBox1.Items.Add("Third Year");
            comboBox1.Items.Add("Last Year");
            comboBox1.Items.Add("Faculty");
            this.mainEvent = mainEvent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myForm = new Form1();
            myForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                String name = textBox1.Text;
                String year = comboBox1.Text;
                String email = textBox2.Text;
                String password = "default";
                String status = "Core";

               // Data Source =.\sqlexpress; Initial Catalog = demodb; Integrated Security = True; Pooling = False

                SqlConnection s = new SqlConnection(@"Data Source=DESKTOP-1L22IPV\SQLEXPRESS;Initial Catalog=demodb;Integrated Security=True;Pooling=False");

                s.Open();
                Console.WriteLine("Works");
                SqlCommand cmd = new SqlCommand();
                Console.WriteLine("email" + email + "    name" + name + "         year" + year + "        password" + password + "    status" + status + "           mainevent" + mainEvent);
                cmd.CommandText = "insert into MemberInfo values('" + email + "','" + name + "','" + year + "','" + password + "','" + status + "','" + mainEvent + "','"+1+"')";
                cmd.Connection = s;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Record Inserted");
                else
                    MessageBox.Show("Not Inserted");


                /*SqlConnection con = new SqlConnection(@"Data Source = DESKTOP - 5QO7K0D\SQLEXPRESS; Initial Catalog = tanmaydb; Integrated Security = True; Pooling = False");
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into MemberInfo values('" + email + "','" + name + "','" + year + "','" + password + "','" + status + "','" + mainEvent + "')";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Record Inserted");
                else
                    MessageBox.Show("Not Inserted");*/
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); Console.WriteLine(ex.Message); }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new Form2();
            f.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
