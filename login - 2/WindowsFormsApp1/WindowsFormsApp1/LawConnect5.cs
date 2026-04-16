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
    public partial class LawConnect5 : Form
    {
        int id;
        int selectedId;
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";

        public LawConnect5(int i,int j)
        {
            selectedId = i;
            id = j;
            InitializeComponent();
            this.Width = 900;
            this.Height = 400;
            LoadDetails();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect4 f4 = new LawConnect4(selectedId,id);
            f4.Show();
        }
        private void LoadDetails()
        {
            string query = "SELECT Cl_id, C_name, C_age, C_num FROM Client WHERE Cl_id = @Cl_id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cl_id", id);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                       
                        textBox2.Text = reader["C_name"].ToString();
                        textBox3.Text = reader["C_age"].ToString();
                        textBox4.Text = reader["C_num"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No details found for the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string newName = textBox2.Text.Trim();
            string newAge = textBox3.Text.Trim();
            string newNum = textBox4.Text.Trim();

            if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newAge) || string.IsNullOrWhiteSpace(newNum))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Client SET C_name = @C_name, C_age = @C_age, C_num = @C_num WHERE Cl_id = @Cl_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cl_id", id);
                    command.Parameters.AddWithValue("@C_name", newName);
                    command.Parameters.AddWithValue("@C_age", newAge);
                    command.Parameters.AddWithValue("@C_num", newNum);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close(); 
                    }
                    else
                    {
                        MessageBox.Show("No record was updated. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            LawConnect4 f4 = new LawConnect4(selectedId,id);
            f4.Show();
        }

        private void LawConnect5_Load(object sender, EventArgs e)
        {

        }
    }
}
