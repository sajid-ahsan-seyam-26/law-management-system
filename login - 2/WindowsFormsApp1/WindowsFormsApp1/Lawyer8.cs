using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Lawyer8 : Form
    {
        int id;
        int selectedId;
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";
        public Lawyer8(int i, int j)
        {
            InitializeComponent();
        id = i;
          selectedId = j;
        }

        private void LoadCurrentStatus()
        {
            string query = @"
        SELECT TOP 1 Status 
        FROM Schedule 
        WHERE L_id = @L_id 
        ORDER BY A_id DESC"; // Assuming A_id is the Appointment ID or timestamp column for ordering

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@L_id", id); // Use id for L_id

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            label7.Text = reader["Status"].ToString(); 
                        }
                        else
                        {
                            MessageBox.Show("No appointments found for the given Lawyer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            label7.Text = "No status found."; 
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lawyer4 f4 = new Lawyer4(id, selectedId);
            f4.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label7.Text == "Pending")
            {
                UpdateStatus("Accepted");
                MessageBox.Show("Appointment Accepted", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The appointment is already processed.", "Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Hide();
            Lawyer4 f4 = new Lawyer4(id, selectedId);
            f4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label7.Text == "Pending")
            {
                UpdateStatus("Rejected");
                MessageBox.Show("Appointment Rejected", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The appointment is already processed.", "Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Hide();
            Lawyer4 f4 = new Lawyer4(id, selectedId);
            f4.Show();
        }

        private void UpdateStatus(string newStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Schedule SET Status = @Status WHERE L_id = @L_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", newStatus);
                    //command.Parameters.AddWithValue("@Cl_id", selectedId); // Ensure selectedId is used for Cl_id
                    command.Parameters.AddWithValue("@L_id", id); // Ensure id is used for L_id

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while updating status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Lawyer8_Load(object sender, EventArgs e)
        {
            LoadCurrentStatus();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
