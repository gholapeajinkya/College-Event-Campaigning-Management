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
    public partial class ParticipantsShowForm : Form
    {
        String ev;
        public ParticipantsShowForm(String ev)
        {
            InitializeComponent();
            this.ev = ev;
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=demodb;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Entries where EventName=@a1";
            cmd.Parameters.AddWithValue("@a1", ev);
            cmd.Connection = con;
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;

            dataGridView1.DataSource = bs;
            sda.Update(dt);
            con.Close();

           
            

           SqlConnection con1 = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=demodb;Integrated Security=True;Pooling=False");
            con1.Open();
            SqlCommand cnt = con1.CreateCommand();
            cnt.CommandText = "SELECT Sum(Fees)FROM Entries";
            var obj = cnt.ExecuteScalar();
            int result = obj != null ? (int)obj : 0;
            Console.WriteLine(result);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new CoreMemberForm("");
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
