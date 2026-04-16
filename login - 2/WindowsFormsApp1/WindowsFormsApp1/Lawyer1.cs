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
    public partial class Lawyer1 : Form
    {
        int selectedId;
        public Lawyer1()
        {
            InitializeComponent();
        }

        private void Lawyer1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome f4 = new Welcome();
            f4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userId = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both Id and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(userId, out int userIdInt))
            {
                MessageBox.Show("Please enter a valid numeric Id.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";

            string query = "SELECT COUNT(*) FROM _Lawyer WHERE L_id = @L_id AND L_password COLLATE SQL_Latin1_General_CP1_CS_AS = @L_password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@L_id", userId);
                    command.Parameters.AddWithValue("@L_password", password);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        this.Hide();
                        Lawyer4 f3 = new Lawyer4(int.Parse(userId), selectedId);
                        f3.Show();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Id or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Lawyer2 f2 = new Lawyer2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                  this.Close();
            LawyerForgot f3 = new LawyerForgot();
            f3.Show();
        }
    }
}
