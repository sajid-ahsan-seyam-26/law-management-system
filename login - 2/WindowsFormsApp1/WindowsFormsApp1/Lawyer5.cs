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
    public partial class Lawyer5 : Form
    {
        int id;
        int selectedId;
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";

        public Lawyer5(int i,int j)
        {
            id = i;
            selectedId = j;
            InitializeComponent();
            this.Width = 900;
            this.Height = 400;

            
            string query = "SELECT L_id AS ID,L_name AS Name,L_num AS Phone_number,L_rating AS Rating,L_fee AS Fee, L_type AS Lawyer_type FROM _Lawyer";
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
        private void Lawyer5_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            Lawyer4 f2 = new Lawyer4(id, selectedId);
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT L_id AS ID,L_name AS Name,L_num AS Phone_number,L_rating AS Rating,L_fee AS Fee,L_type AS Lawyer_type FROM _Lawyer 
                     WHERE L_id LIKE @searchTerm 
                        OR L_name LIKE @searchTerm 
                        OR L_num LIKE @searchTerm 
                        OR L_rating LIKE @searchTerm
                        OR L_fee LIKE @searchTerm
                        OR L_type LIKE @searchTerm";


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
            string query = "SELECT L_id AS ID, L_name AS Name, L_num AS Phone_number, L_rating AS Rating,L_fee AS Fee, L_type AS Lawyer_type FROM _Lawyer ORDER BY L_name ASC";

            FillDataGridView(query);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "SELECT L_id AS ID, L_name AS Name, L_num AS Phone_number, L_rating AS Rating, L_fee AS Fee, L_type AS Lawyer_type FROM _Lawyer ORDER BY L_rating DESC";
            FillDataGridView(query);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "SELECT L_id AS ID, L_name AS Name, L_num AS Phone_number, L_rating AS Rating, L_fee AS Fee, L_type AS Lawyer_type FROM _Lawyer ORDER BY L_fee ASC";
            FillDataGridView(query);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
            Lawyer6 f1 = new Lawyer6(id, selectedId);
            f1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Lawyer8 f2 = new Lawyer8(id, selectedId);
            f2.Show();
        }
    }
}
