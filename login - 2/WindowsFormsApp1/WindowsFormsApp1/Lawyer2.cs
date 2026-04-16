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
    public partial class Lawyer2 : Form
    {
        public Lawyer2()
        {
            InitializeComponent();
            string[] type = new string[4];
            type[0] = "Crime Lawyer";
            type[1] = "Property Lawyer";
            type[2] = "Corporate Lawyer";
            type[3] = "Tax Lawyer";

            comboBox1.DataSource = type;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";

            string id = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string phone_number = textBox3.Text.Trim();
            string fee = textBox4.Text.Trim();
            string password = textBox5.Text.Trim();
            string type = comboBox1.SelectedItem?.ToString(); 

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(fee) || string.IsNullOrWhiteSpace(phone_number) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(fee, out int parsedFee))
            {
                MessageBox.Show("Fee must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(id, out int userIdInt))
            {
                MessageBox.Show("ID should be a numeric value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkQuery = "SELECT COUNT(*) FROM _Lawyer WHERE L_id = @L_id";

                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@L_id", id);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("The ID already exists. Please choose a different ID.", "Duplicate ID Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string query = "INSERT INTO _Lawyer (L_id, L_name, L_num, L_fee, L_Password, L_type) VALUES (@L_id, @L_name, @L_num, @L_fee, @L_Password, @L_type)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@L_id", id);
                    command.Parameters.AddWithValue("@L_name", name);
                    command.Parameters.AddWithValue("@L_num", phone_number);
                    command.Parameters.AddWithValue("@L_fee", parsedFee);
                    command.Parameters.AddWithValue("@L_Password", password);
                    command.Parameters.AddWithValue("@L_type", type);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Lawyer1 f1 = new Lawyer1();
                        f1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lawyer1 f1 = new Lawyer1();
            f1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
