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
    public partial class LawConnect12 : Form
    {
        int id;
        int selectedId;
        public LawConnect12(int i, int j)
        {
            selectedId = i;
            id = j;
            InitializeComponent();

            string[] rating = new string[5];
            rating[0] = "1";
            rating[1] = "2";
            rating[2] = "3";
            rating[3] = "4";
            rating[4] = "5";

            comboBox1.DataSource = rating;
        }

        private void LawConnect12_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedRating = comboBox1.SelectedItem.ToString();
                MessageBox.Show($"Rating given: {selectedRating} star{(selectedRating != "1" ? "s" : "")}");

                int ratingValue = int.Parse(selectedRating);

                try
                {
                    // Connection string to the database
                    string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Update the rating directly
                        string updateQuery = "UPDATE _Lawyer SET L_rating = @L_rating WHERE L_id = @L_id";
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@L_rating", ratingValue);
                            command.Parameters.AddWithValue("@L_id", selectedId);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Rating updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Failed to update rating. Lawyer not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }

                this.Close();
               
            }
            else
            {
                MessageBox.Show("Please select a rating before submitting.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
