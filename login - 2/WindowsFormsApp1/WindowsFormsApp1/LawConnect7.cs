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
    public partial class LawConnect7 : Form
    {
        int selectedId;
        int id;
        string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";

        public LawConnect7(int i,int j)
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
            string query = "SELECT L_id, L_name, L_num, L_rating,L_fee,L_type FROM _Lawyer WHERE L_id = @L_id"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@L_id", selectedId); 
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        label5.Text = reader["L_id"].ToString();
                        label6.Text = reader["L_name"].ToString();
                        label7.Text = reader["L_num"].ToString();
                        label8.Text = reader["L_rating"].ToString();
                        label9.Text = reader["L_fee"].ToString();
                        label11.Text = reader["L_type"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No details found for the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); 
                    }
                }
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect3 f3 = new LawConnect3(selectedId, id);
            f3.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect4 f4 = new LawConnect4(selectedId,id);
            f4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            LawConnect6 f6 = new LawConnect6(selectedId,id);
            f6.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Lawconnect9 f9 = new Lawconnect9(selectedId,id);
            f9.Show();
        }

        private void LawConnect7_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LawConnect12 f12 = new LawConnect12(id, selectedId);
            f12.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //this.Hide();
            LawConnect9s f9 = new LawConnect9s(selectedId, id);
            f9.Show();
        }
    }
}
