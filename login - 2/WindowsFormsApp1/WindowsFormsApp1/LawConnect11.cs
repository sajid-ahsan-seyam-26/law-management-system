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
    public partial class LawConnect11 : Form
    {
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";
        int id;
        public LawConnect11(int i)
        {
            id = i;
            InitializeComponent();
           
        }

        private void LawConnect11_Load(object sender, EventArgs e)
        {

        }
        private int GetSelectedRating()
        {
            if (radioButton6.Checked)
            {
                return 1;
            }
            else if (radioButton8.Checked) { return 2; }
            else if (radioButton7.Checked) { return 3; }
            else if (radioButton10.Checked) { return 4; }
            else if (radioButton11.Checked) { return 5; }
            else { return 0; } // Default if no radio button is selected
        }

        private void UpdateLawyerRating(int id, int newRating)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Retrieve current average rating and count
                string query = "SELECT L_rating FROM _Lawyer WHERE L_id = @L_id";
                SqlCommand selectCommand = new SqlCommand(query, connection);
                selectCommand.Parameters.AddWithValue("@L_id", id);

                SqlDataReader reader = selectCommand.ExecuteReader();
                double currentRating = 0;
                int ratingCount = 0;

                if (reader.Read())
                {
                    currentRating = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader[0]);
                    ratingCount = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                }
                reader.Close();

                // Calculate the new average rating
                double newAverageRating = ((currentRating * ratingCount) + newRating) / (ratingCount + 1);

                // Update the database with the new average and count
                string updateQuery = "UPDATE _Lawyer SET L_rating = @L_rating WHERE L_id = @L_id";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@L_rating", newAverageRating);
                updateCommand.Parameters.AddWithValue("@L_id", id);

                updateCommand.ExecuteNonQuery();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int selectedRating = GetSelectedRating();

            if (selectedRating == 0)
            {
                MessageBox.Show("Please select a rating before submitting.");
                return;
            }

            UpdateLawyerRating(id, selectedRating);
            MessageBox.Show("Rating submitted successfully!");
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LawConnect11_Load_1(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

       
    }
}
