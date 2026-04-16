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
    public partial class LawConnect1 : Form
    {
        int selectedId;
        public LawConnect1()
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 400;
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

            string query = "SELECT COUNT(*) FROM Client WHERE Cl_id = @Cl_id AND C_password COLLATE SQL_Latin1_General_CP1_CS_AS = @C_password";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Cl_id", userId);
                        command.Parameters.AddWithValue("@C_password", password);

                        connection.Open();

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            this.Hide();
                            LawConnect3 f3 = new LawConnect3(selectedId,int.Parse(userId));
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
            this.Hide();
            LawConnect2 f2 = new LawConnect2();
            f2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome f4 = new Welcome();
            f4.Show();
        }

        private void LawConnect1_Load(object sender, EventArgs e)
        {

        }
    }
}
