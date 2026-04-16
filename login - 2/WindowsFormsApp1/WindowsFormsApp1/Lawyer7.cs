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
    
    public partial class Lawyer7 : Form
    {
        int id;
        int selectedId;
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";
        public Lawyer7(int i,int j)
        {
                id= i;
            selectedId = j;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newName = textBox2.Text.Trim();
            string newAge = textBox3.Text.Trim();
            string newNum = textBox4.Text.Trim();

            if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newAge) || string.IsNullOrWhiteSpace(newNum))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE _Lawyer SET L_name = @L_name, L_fee = @L_fee, L_num = @L_num WHERE L_id = @L_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@L_id", id);
                    command.Parameters.AddWithValue("@L_name", newName);
                    command.Parameters.AddWithValue("@L_fee", newAge);
                    command.Parameters.AddWithValue("@L_num", newNum);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close(); 
                    }
                    else
                    {
                        MessageBox.Show("No record was updated. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            Lawyer4 f4 = new Lawyer4(id, selectedId);
            f4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Lawyer6 f1 = new Lawyer6(id, selectedId);
            f1.Show();
        }

        private void Lawyer7_Load(object sender, EventArgs e)
        {

        }
    }
}
