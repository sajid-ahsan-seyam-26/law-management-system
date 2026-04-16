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
    public partial class Admin5 : Form
    {
        int id;
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";
        public Admin5(int i)
        {
            id = i;
            InitializeComponent();
            string query = "SELECT Cl_id AS ID,C_name AS Name,C_num AS Phone_number,C_age AS Age FROM Client";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT Cl_id AS ID,C_name AS Name,C_num AS Phone_number,C_age AS Age FROM Client
                     WHERE Cl_id LIKE @searchTerm 
                        OR C_name LIKE @searchTerm 
                        OR C_num LIKE @searchTerm 
                        OR C_age LIKE @searchTerm";


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

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT Cl_id AS ID,C_name AS Name,C_num AS Phone_number,C_age AS Age FROM Client ORDER BY C_name ASC";

            FillDataGridView(query);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string query = "SELECT Cl_id AS ID,C_name AS Name,C_num AS Phone_number,C_age AS Age FROM Client ORDER BY C_age DESC";
            FillDataGridView(query);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin6 f6 = new Admin6(id);
            f6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin7 f7 = new Admin7(id);
            f7.Show();
        }
    }
}
