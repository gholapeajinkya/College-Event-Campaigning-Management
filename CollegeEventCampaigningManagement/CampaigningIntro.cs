using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanmay1
{
    public partial class CampaigningIntro : Form
    {
        String ev;
        public CampaigningIntro(String x)
        {
            InitializeComponent();
            ev = x;
        }

        private void CampaigningIntro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myForm = new NewEntryForm(ev);
            myForm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
