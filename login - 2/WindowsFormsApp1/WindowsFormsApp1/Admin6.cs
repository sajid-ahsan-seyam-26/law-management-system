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
    public partial class Admin6 : Form
    {
        int id;
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";
        public Admin6(int i)
        {
            id = i;
            InitializeComponent();
            string query = "SELECT Id, Name, Phone_Number, Age FROM Admin";
            FillDataGridView(query);
        }
        private void FillDataGridView(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }
            }

        }
        private void Admin6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT Id, Name, Phone_Number, Age FROM Admin
                             WHERE Id LIKE @searchTerm 
                             OR Name LIKE @searchTerm 
                             OR Phone_Number LIKE @searchTerm 
                             OR Age LIKE @searchTerm";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchTerm", "%" + searchValue + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No matching rows found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin3 f3 = new Admin3(id);
            f3.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin4 f4 = new Admin4(id);
            f4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin5 f5 = new Admin5(id);
            f5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT Id AS ID, Name, Phone_Number AS PhoneNumber, Age FROM Admin ORDER BY Name ASC";
            FillDataGridView(query);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "SELECT Id AS ID, Name, Phone_Number AS PhoneNumber, Age FROM Admin ORDER BY Age ASC";
            FillDataGridView(query);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin7 f7 = new Admin7(id);
            f7.Show();
        }
    }
}
