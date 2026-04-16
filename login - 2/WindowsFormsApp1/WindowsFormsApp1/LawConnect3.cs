using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WindowsFormsApp1
{
    public partial class LawConnect3 : Form
    {
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";
        int selectedId;
        int id;
        public LawConnect3(int i,int j)
        {
            selectedId = i;
            id = j;
            InitializeComponent();
            this.Width = 900;
            this.Height = 400;

            LoadDetails();


        }

        private void LoadDetails()
        {
            string query = "SELECT C_name FROM Client WHERE Cl_id = @Cl_id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cl_id", id);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        label2.Text = reader["C_name"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("No details found for the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }




        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect4 f4 = new LawConnect4(selectedId,id);
            f4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect5 f5 = new LawConnect5(selectedId,id);
            f5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect6 f6 = new LawConnect6(selectedId,id);
            f6.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect1 f1 = new LawConnect1();
            f1.Show();
        }

        private void type_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         System.Diagnostics.Process.Start("https://judiciary.gov.bd/en/form-foujdari");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LawConnect3_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            LawConnect9s f9 = new LawConnect9s(selectedId,id );
            f9.Show();
        }
    }
}
