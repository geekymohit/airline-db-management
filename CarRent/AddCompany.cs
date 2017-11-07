using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRent
{
    public partial class AddCompany : Form
    {
        public AddCompany()
        {
            InitializeComponent();
            SqlConnection sqlConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = carrent; Integrated Security = True");
            sqlConnection.Open();
            String query1 = "select * from addcompany ;";
            SqlCommand cmd = new SqlCommand(query1, sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();

        }
        public void resetall()
        {
            textBox1.Text = "";

        }
        public int checkingtextbox()
        {
            if (textBox1.Text == "")
            {
                return 1;
            }
            else
                return 0;
        }

        private void AddCompany_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carrentDataSet4.addcompany' table. You can move, or remove it, as needed.
            this.addcompanyTableAdapter.Fill(this.carrentDataSet4.addcompany);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = carrent; Integrated Security = True");
            sqlConnection.Open();
            try
            {
                if (checkingtextbox() == 1)
                {
                    MessageBox.Show("Some Information are missing");
                }
                else
                {
                    String query2 = "insert into addcompany values ('" + textBox1.Text + "');";
                    SqlCommand cmd2 = new SqlCommand(query2, sqlConnection);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Inserted Successfully");
                    resetall();
                    sqlConnection.Close();
                    String query1 = "select * from addcompany ;";
                    SqlCommand cmd = new SqlCommand(query1, sqlConnection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = carrent; Integrated Security = True");
            sqlConnection.Open();


            try
            {
                if (checkingtextbox() == 1)
                {
                    MessageBox.Show("Some Information are missing");
                }
                else
                {
                    String query3 = "delete from addcompany where company = '" + textBox1.Text + "'";
                    SqlCommand cmd3 = new SqlCommand(query3, sqlConnection);
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully");
                    sqlConnection.Close();
                    resetall();
                    String query1 = "select * from addcompany ;";
                    SqlCommand cmd = new SqlCommand(query1, sqlConnection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            resetall();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mainmenu mainmenu = new Mainmenu();
            this.Hide();
            mainmenu.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox1.Text = row.Cells[0].Value.ToString();
            }
        }
    }
}
