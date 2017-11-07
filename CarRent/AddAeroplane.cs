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
    public partial class AddAeroplane : Form
    {
        
        public AddAeroplane()
        {
            InitializeComponent();
            SqlConnection sqlConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = carrent; Integrated Security = True");
            sqlConnection.Open();
            String query1 = "select * from aeroplaneadd ;";
            SqlCommand cmd = new SqlCommand(query1, sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            fillcombo();
            fillcombo2();
        }
        public void fillcombo()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = carrent; Integrated Security = True");
            sqlConnection.Open();
            try
            {



                String query3 = "select add_city from addcity ;";
                SqlCommand cmd = new SqlCommand(query3, sqlConnection);
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())

                {
                    string city = dataReader.GetString(0);
                    comboBox1.Items.Add(city);
                    comboBox2.Items.Add(city);
                }
                dataReader.Close();

                /*String query4 = "select company from addcompany ;";
                SqlCommand cmd2 = new SqlCommand(query4, sqlConnection);
                SqlDataReader dataReader2 = cmd2.ExecuteReader();
                while (dataReader2.Read())

                {
                    string company = dataReader2.GetString(0);
                    comboBox3.Items.Add(company);
                    
                }



                
                dataReader2.Close();*/
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        public void fillcombo2()
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
                    comboBox3.Items.Add(company);

                }



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Addcar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carrentDataSet.aeroplaneadd' table. You can move, or remove it, as needed.
            //this.aeroplaneaddTableAdapter.Fill(this.carrentDataSet.aeroplaneadd);
            // TODO: This line of code loads data into the 'carrentDataSet1.add_aeroplane' table. You can move, or remove it, as needed.
            //this.add_aeroplaneTableAdapter.Fill(this.carrentDataSet1.add_aeroplane);
            // TODO: This line of code loads data into the 'carrentDataSet.addcar' table. You can move, or remove it, as needed.
            //this.addcarTableAdapter.Fill(this.carrentDataSet.addcar);

        }

        public void resetall()
        {
            textBox1.Text = "";
            comboBox3.SelectedItem = null;
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
             
            textBox5.Text = "";
        }
        public int checkingtextbox()
        {
            if (textBox1.Text == "" || textBox5.Text == "")
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
            try
            {
                if (checkingtextbox()==1)
                {
                    MessageBox.Show("Some Information are missing");
                }
                else
                {
                    String query2 = "insert into aeroplaneadd values ( '" + textBox1.Text + "','" + comboBox3.SelectedItem + "','" + comboBox1.SelectedItem + "','" + comboBox2.SelectedItem + "','" + textBox5.Text + "');";
                    SqlCommand cmd2 = new SqlCommand(query2, sqlConnection);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Inserted Successfully");
                    resetall();
                    sqlConnection.Close();
                    String query1 = "select * from aeroplaneadd ;";
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
                    String query3 = "delete from aeroplaneadd where air_id = '" + textBox1.Text + "'";
                    SqlCommand cmd3 = new SqlCommand(query3, sqlConnection);
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully");
                    sqlConnection.Close();
                    resetall();
                    String query1 = "select * from aeroplaneadd ;";
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox1.Text = row.Cells[0].Value.ToString();
                
                int a = comboBox1.Items.IndexOf(row.Cells[2].Value.ToString());
                int b = comboBox2.Items.IndexOf(row.Cells[3].Value.ToString());
                int c = comboBox3.Items.IndexOf(row.Cells[1].Value.ToString());
                comboBox1.SelectedIndex = a ;
                comboBox2.SelectedIndex = b ;
                comboBox3.SelectedIndex = c ;


                textBox5.Text = row.Cells[4].Value.ToString();



            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
         
}

    

