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
    public partial class LawyerForgot : Form
    {
        public LawyerForgot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";

            string id = textBox1.Text.Trim();  //trim is used to remove unnecessary space/blank space
            string name = textBox2.Text.Trim();
            string password = textBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) ||string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE _Lawyer SET L_password = @L_password WHERE L_id = @L_id AND L_name = @L_name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@L_id", id);
                    command.Parameters.AddWithValue("@L_name", name);
                    command.Parameters.AddWithValue("@L_password", password);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Lawyer1 f1 = new Lawyer1();
                        f1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to change password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void LawyerForgot_Load(object sender, EventArgs e)
        {

        }
    }
}
