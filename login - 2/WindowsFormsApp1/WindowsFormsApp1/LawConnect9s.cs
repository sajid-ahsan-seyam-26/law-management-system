using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LawConnect9s : Form
    {
        int selectedId;
        int id;
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";

        public LawConnect9s(int i,int j)
        {
            selectedId = i;
            id = j;
            InitializeComponent();
            string query = "SELECT A_id AS Appointment_ID,Cl_id AS Client_ID,Date, Status FROM Schedule";
            FillDataGridView(query);

        }
        
        private void LawConnect9s_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // this.Hide();
            LawConnect3 f3 = new LawConnect3(selectedId, id);
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedClId = (int)dataGridView1.SelectedRows[0].Cells["Client_ID"].Value;

                if (selectedClId != id)
                {
                    MessageBox.Show("Not your appointment.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (selectedClId == id)
                {
                    try
                    {
                        string status = dataGridView1.SelectedRows[0].Cells["Status"].Value.ToString();
                        Console.WriteLine($"Status: {status}"); // Debugging status

                        // Status handling logic
                        if (status == "Pending")
                        {
                            MessageBox.Show("Not approved yet.", "Status: Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (status == "Accepted")
                        {
                            MessageBox.Show("You may proceed to payment.", "Status: Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            LawConnect10 f10 = new LawConnect10(selectedId, id);
                            f10.Show();
                        }
                        else if (status == "Rejected")
                        {
                            MessageBox.Show("Request has been rejected.", "Status: Rejected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Unknown status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
