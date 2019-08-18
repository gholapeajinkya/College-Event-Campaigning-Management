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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            comboBox1.Items.Add("Information Technology");
            comboBox1.Items.Add("Computer Science");
            comboBox1.Items.Add("Mechanical");
            comboBox1.Items.Add("Civil");
            comboBox1.Items.Add("Biotech");
            comboBox1.Items.Add("Production");
            comboBox1.Items.Add("Electronics");
            comboBox1.Items.Add("Electrical");
            comboBox1.Items.Add("Environment");
            comboBox1.Items.Add("Mixed Discipline");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
      
            String mainEvent=textBox1.Text;
            String event1=textBox2.Text;
            String event2=textBox3.Text;
            String event3 = textBox4.Text;
            String dept = comboBox1.Text;
            if (event1.Length == 0)
            {
                MessageBox.Show("Main event name and atleast one sub event name is required!! You can always have same event name and subevent name");
            }
            else if (mainEvent.Length == 0)
            {
                MessageBox.Show("Main event name and atleast one sub event name is required!! You can always have same event name and subevent name");
            }
            else if (dept.Length == 0)
            {
                MessageBox.Show("Please select department");
            }
            else {

                SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=demodb;Integrated Security=True;Pooling=False");
                //Data Source = DESKTOP - 1L22IPV\SQLEXPRESS; Initial Catalog = demodb; Integrated Security = True; Pooling = False
                con.Open();
                Console.WriteLine("Works");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into EventsData values('" + mainEvent + "','" + event1 + "','" + event2 + "','" + event3 + "','" + dept + "')";
                cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Record Inserted");
                else
                    MessageBox.Show("Not Inserted");

                this.Hide();
                var myForm = new EventHead(mainEvent, event1, event2);
                myForm.Show();
            }
        }

        private void label5_Click(object sender, EventArgs e)
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
