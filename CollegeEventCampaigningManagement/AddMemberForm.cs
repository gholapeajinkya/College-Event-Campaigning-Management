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
    public partial class AddMemberForm : Form
    {
        int core;
        String ev;
        public AddMemberForm(String x)
        {
            InitializeComponent();
            comboBox1.Items.Add("First Year");
            comboBox1.Items.Add("Second Year");
            comboBox1.Items.Add("Third Year");
            comboBox1.Items.Add("Last Year");
            comboBox1.Items.Add("Faculty");
            ev = x;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (checkBox1.Checked)
                {
                    core = 1;
                }
                else
                {
                    core = 0;
                }
                String name = textBox1.Text;
                String year = comboBox1.Text;
                String email = textBox2.Text;
                String password = "default";
                String status = "Core";
                if (core == 0)
                {
                    status = "Volunteer";
                }
               


                SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=demodb;Integrated Security=True;Pooling=False");
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into MemberInfo values('" + email + "','" + name + "','" + year + "','" + password + "','" + status + "','"+ ev +"')";
                cmd.Connection = con;

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Record Inserted");
                else
                    MessageBox.Show("Not Inserted");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new CoreMemberForm("");
            f.Show();
        }
    }
}
