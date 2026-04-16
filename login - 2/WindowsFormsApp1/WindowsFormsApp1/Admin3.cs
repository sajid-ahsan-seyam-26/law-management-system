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

namespace WindowsFormsApp1
{
    public partial class Admin3 : Form
    {
        int id;
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";

        public Admin3(int i)
        {
            id = i;
            InitializeComponent();
            LoadDetails();


        }

        private void LoadDetails()
        {
            string adminQuery = "SELECT Name FROM Admin WHERE Id = @Id";
            string clientCountQuery = "SELECT COUNT(*) FROM Client";  
            string lawyerCountQuery = "SELECT COUNT(*) FROM _Lawyer"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand adminCommand = new SqlCommand(adminQuery, connection))
                {
                    adminCommand.Parameters.AddWithValue("@Id", id);
                    connection.Open();

               
                    SqlDataReader reader = adminCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        label2.Text = reader["Name"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No details found for the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                        return;
                    }
                    reader.Close();
                }
                using (SqlCommand clientCommand = new SqlCommand(clientCountQuery, connection))
                {
                    int clientCount = (int)clientCommand.ExecuteScalar();
                    label5.Text = clientCount.ToString(); 
                }

                using (SqlCommand lawyerCommand = new SqlCommand(lawyerCountQuery, connection))
                {
                    int lawyerCount = (int)lawyerCommand.ExecuteScalar();
                    label7.Text = lawyerCount.ToString();
                }
            }
        }

        private void Admin3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin1 f2 = new Admin1();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin4 f4 = new Admin4(id);
            f4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin5 f5 = new Admin5(id);
            f5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin6 f6 = new Admin6(id);
            f6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin7 f7 = new Admin7(id);
            f7.Show();
        }
    }
}
