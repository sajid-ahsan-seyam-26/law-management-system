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
    public partial class Lawyer4 : Form
    {
        int id;
        int selectedId;
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";
        public Lawyer4(int i, int j)
        {
            id = i;
            selectedId = j;
            InitializeComponent();

            LoadDetails();


        }

        private void LoadDetails()
        {
            string query = "SELECT L_name FROM _Lawyer WHERE L_id = @L_id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@L_id", id);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        label2.Text = reader["L_name"].ToString();

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
            this.Close();
            Lawyer1 f1 = new Lawyer1();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Lawyer5 f2 = new Lawyer5(id, selectedId);
            f2.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://judiciary.gov.bd/en/form-foujdari");

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.goodreads.com/shelf/show/law-related");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Lawyer6 f1 = new Lawyer6(id, selectedId);
            f1.Show();
        }

        private void Lawyer4_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lawyer8 f7 = new Lawyer8(id, selectedId);
            f7.Show();
        }
    }
}
