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

namespace CarRent
{
    public partial class Form1 : Form
    {
        String user, pass;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            user = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pass = textBox2.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = carrent; Integrated Security = True");
            sqlConnection.Open();
            String query1 = "select username , password from login where username = '"+user+"'and password = '"+pass+"'";
            try
            {
                SqlCommand cmd = new SqlCommand(query1,sqlConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login success ");
                    Mainmenu mainmenu= new Mainmenu();
                    this.Hide();
                    mainmenu.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed please check your username and password");
                }
                sqlConnection.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newuser form2 = new newuser();
            form2.Show();
            this.Hide();

        }

        
    }
}
