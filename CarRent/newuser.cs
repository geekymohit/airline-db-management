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
    public partial class newuser : Form
    {
        public newuser()
        {
            InitializeComponent();
        }

        private void newuser_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        public int checkingtextbox()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" )
            {
                return 1;
            }
            else
                return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = carrent; Integrated Security = True");
            sqlConnection.Open();
            String query1 = "select username from login where username = '" + textBox2.Text + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(query1, sqlConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (checkingtextbox() == 1)
                {
                    MessageBox.Show("Some information are missing");
                }
                else if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Already user exist with this username");
                    
                   
                }
                else
                {
                    
                    String query2 = "insert into login values ( '" + textBox2.Text + "','" + textBox3.Text+"');";
                    SqlCommand cmd2 = new SqlCommand(query2, sqlConnection);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Registered Successfully");
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
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }
    }
}
