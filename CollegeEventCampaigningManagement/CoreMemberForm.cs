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
    
    public partial class CoreMemberForm : Form
    {
        String ev;
        public CoreMemberForm(String ev)
        {
            InitializeComponent();
            this.ev = ev;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myForm = new AddMemberForm(ev);
            myForm.Show();
        }

        private void StatsShow_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myForm = new StatsShowForm();
            myForm.Show();
        }

        private void ParticipantsShow_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myForm = new ParticipantsShowForm(ev);
            myForm.Show();


        }

        private void MoveToCampaign_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myForm = new NonCoreForm(ev);
            myForm.Show();
        }

        private void ViewMembers_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myForm = new ViewMembersForm(ev);
            myForm.Show();
        }

        private void FinanceShow_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myForm = new FinanceForm(ev);
            myForm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new LoginForm();
            f.Show();
        }
    }
}
