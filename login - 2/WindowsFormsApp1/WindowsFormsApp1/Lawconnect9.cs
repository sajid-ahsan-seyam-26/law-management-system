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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Lawconnect9 : Form
    {
        int id;
        int selectedId;

        public Lawconnect9(int i, int j)
        {
            selectedId = i;
            id = j;
            InitializeComponent();
        }

        private void Lawconnect9_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect7 f7 = new LawConnect7(selectedId,id);
            f7.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reason = richTextBox1.Text;

            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show("You must add a reason for consultation", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = "Pending";
            DateTime selectedDate = dateTimePicker1.Value;

            string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkClientQuery = "SELECT COUNT(*) FROM Client WHERE Cl_id = @Cl_id";
                using (SqlCommand checkCommand = new SqlCommand(checkClientQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Cl_id", id);
                    int clientExists = (int)checkCommand.ExecuteScalar();

                    if (clientExists == 0)
                    {
                        MessageBox.Show("Client ID does not exist. Please check the client ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string getMaxAIdQuery = "SELECT ISNULL(MAX(A_id), 0) FROM Schedule";
                int newAId;
                using (SqlCommand maxCommand = new SqlCommand(getMaxAIdQuery, connection))
                {
                    newAId = Convert.ToInt32(maxCommand.ExecuteScalar()) + 1;
                }

                string query = "INSERT INTO Schedule (A_id, Cl_id, L_id, Status, Date) VALUES (@A_id, @Cl_id, @L_id, @Status, @Date)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@A_id", newAId);
                    command.Parameters.AddWithValue("@Cl_id", id);
                    command.Parameters.AddWithValue("@L_id", selectedId);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Date", selectedDate);

                    try
                    {
                        command.ExecuteNonQuery();

                        MessageBox.Show($"Appointment scheduled successfully! Appointment ID: {newAId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            this.Close();
            LawConnect9s f4 = new LawConnect9s(selectedId, id);
            f4.Show();
        }
        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect3 f3 = new LawConnect3(selectedId,id);
            f3.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {

           
            this.Hide();
            LawConnect4 f4 = new LawConnect4(selectedId,id);
            f4.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //this.Hide();
            LawConnect9s f9 = new LawConnect9s(selectedId, id);
            f9.Show();
        }
    }
}
