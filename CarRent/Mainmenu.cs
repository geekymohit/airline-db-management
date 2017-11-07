using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRent
{
    public partial class Mainmenu : Form
    {
        public Mainmenu()
        {
            InitializeComponent();
           
        }

        private void Mainmenu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAeroplane addcar= new AddAeroplane();
            this.Hide();
            addcar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Addairport addairport = new Addairport();
            this.Hide();
            addairport.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addmember addmember = new addmember();
            this.Hide();
            addmember.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddCompany addCompany = new AddCompany();
            this.Hide();
            addCompany.Show();
        }
    }
}
