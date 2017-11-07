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
    public partial class addmember : Form
    {
        public addmember()
        {
            InitializeComponent();
            SqlConnection sqlConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = carrent; Integrated Security = True");
            sqlConnection.Open();
            String query1 = "select * from addmember ;";
            SqlCommand cmd = new SqlCommand(query1, sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            fillcombo();
        }
        public void resetall()
        {
            textBox1.Text = "";
            comboBox1.SelectedItem = null;
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }
        public int checkingtextbox()
        {
            if (textBox1.Text == "" ||  textBox3.Text == "" || textBox4.Text=="" || textBox5.Text == "")
            {
                return 1;
            }
            else if (textBox3.Text.Length  <  10 ||  textBox3.Text.StartsWith("0") || textBox3.Text.Length > 10)
            {
                return 2; 
            }
            else
                return 0;
        }
        public void fillcombo()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = carrent; Integrated Security = True");
            sqlConnection.Open();
            try
            {



               
                String query4 = "select company from addcompany ;";
                SqlCommand cmd2 = new SqlCommand(query4, sqlConnection);
                SqlDataReader dataReader3 = cmd2.ExecuteReader();
                while (dataReader3.Read())

                {
                    string company = dataReader3.GetString(0);
                    comboBox1.Items.Add(company);

                }



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void addmember_Load(object sender, EventArgs e)
        {
           
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
                else if (checkingtextbox() == 2)
                {
                    MessageBox.Show("Mobile number either starts from 0 OR mobile number is not correct");
                }
                else
                {
                    String query2 = "insert into addmember values ( '" + textBox1.Text + "','" + comboBox1.SelectedItem + "','" + textBox3.Text + "','" + textBox4.Text + "','" + int.Parse(textBox5.Text) + "');";
                    SqlCommand cmd2 = new SqlCommand(query2, sqlConnection);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Inserted Successfully");
                    resetall();
                    sqlConnection.Close();
                    String query1 = "select * from addmember ;";
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
                    String query3 = "delete from addmember where name = '" + textBox1.Text + "'";
                    SqlCommand cmd3 = new SqlCommand(query3, sqlConnection);
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully");
                    sqlConnection.Close();
                    resetall();
                    String query1 = "select * from addmember ;";
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
            Mainmenu mainMenu2 = new Mainmenu();
            mainMenu2.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox1.Text = row.Cells[0].Value.ToString();
                int a = comboBox1.Items.IndexOf(row.Cells[1].Value.ToString());
                comboBox1.SelectedIndex = a;
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();

            }
        }
    }
}
