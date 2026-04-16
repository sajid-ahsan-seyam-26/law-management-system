using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LawConnect4 : Form
    {
        int id;
        int selectedId;
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";

        public LawConnect4(int i,int j)
        {

            selectedId = i;
            id = j;
            InitializeComponent();
            this.Width = 900;
            this.Height = 400;
            LoadDetails();
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
                        label5.Text = reader["Cl_id"].ToString();
                        label6.Text = reader["C_name"].ToString();
                        label7.Text = reader["C_age"].ToString();
                        label8.Text = reader["C_num"].ToString();
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
            
        }

        private void button2_Click(object sender, EventArgs e)
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
                string query = "DELETE FROM Client WHERE Cl_id = @Cl_id";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Cl_id", id);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Profile deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close(); 
                            }
                            else
                            {
                                MessageBox.Show("No profile was found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
            }
            this.Close();
            LawConnect1 f1 = new LawConnect1();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
 
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect1 f1 = new LawConnect1();
            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect5 f5 = new LawConnect5(selectedId, id);
            f5.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect3 f3 = new LawConnect3(selectedId,id);
            f3.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect6 f6 = new LawConnect6(selectedId,id);
            f6.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            LawConnect9s f9 = new LawConnect9s(selectedId, id);
            f9.Show();
        }
    }
}
