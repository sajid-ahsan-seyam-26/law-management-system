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
    public partial class Lawyer6 : Form
    {
        int id;
        int selectedId;
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";
        public Lawyer6(int i,int j)
        {
            id = i;
            selectedId = j;
            InitializeComponent();
            LoadDetails();
        }

        private void LoadDetails()
        {
            string query = "SELECT L_id, L_name, L_num, L_rating, L_fee, L_type FROM _Lawyer WHERE L_id = @L_id"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@L_id", id); 
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                         label5.Text = reader["L_id"].ToString();
                        label6.Text = reader["L_name"].ToString();
                        label7.Text = reader["L_num"].ToString();
                        label9.Text = reader["L_fee"].ToString();
                        label11.Text = reader["L_type"].ToString();

                        if (reader["L_rating"] == DBNull.Value || string.IsNullOrEmpty(reader["L_rating"].ToString()))
                        {
                            label8.Text = "No rating yet";
                        }
                        else
                        {
                            label8.Text = reader["L_rating"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No details found for the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); // Close the form if no data is found
                    }
                }
            }
        }




        private void Lawyer6_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Lawyer1 f1 = new Lawyer1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Lawyer5 f5 = new Lawyer5(id, selectedId);
            f5.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            Lawyer4 f4 = new Lawyer4(id, selectedId);
            f4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Confirm deletion
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this profile?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM _Lawyer WHERE L_id = @L_id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@L_id", id);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close(); // Close the form after successful deletion
                        }
                        else
                        {
                            MessageBox.Show("No profile was found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Lawyer7 f7 = new Lawyer7(id, selectedId);
            f7.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Lawyer8 f2 = new Lawyer8(id, selectedId);
            f2.Show();
        }
    }
}
