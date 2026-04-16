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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class LawConnectBank : Form
    {
        int id;
        int selectedId;
        public LawConnectBank(int i,int j)
        {
            selectedId = i;
            id = j;
            InitializeComponent();

            string[] card_name = new string[4];
            card_name[0] = "DBBL";
            card_name[1] = "City Bank";
            card_name[2] = "Islami Bank";
            card_name[3] = "First Security Bank";

            type_box.DataSource = card_name;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LawConnectBank_Load(object sender, EventArgs e)
        {

        }

        private void type_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (type_box.SelectedItem == null)
            {
                MessageBox.Show("No payment method selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string clId = textBox3.Text.Trim();
            string card = textBox1.Text.Trim();
            string pin = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(clId) ||string.IsNullOrWhiteSpace(card) || string.IsNullOrWhiteSpace(pin))
            {
                MessageBox.Show("Please enter both ID and PIN.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(clId, out int parsedClId))
            {
                MessageBox.Show("ID must be a valid numeric value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(pin, out int parsedPin) || pin.Length != 4)
            {
                MessageBox.Show("PIN must be exactly 4 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(card, out int parsedCard) )
            {
                MessageBox.Show("Card must be exactly 16 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";
            string query = "SELECT COUNT(*) FROM Client WHERE Cl_id = @Cl_id AND Pin COLLATE SQL_Latin1_General_CP1_CS_AS = @Pin";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cl_id", parsedClId);
                    command.Parameters.AddWithValue("@Pin", pin);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        DialogResult result = MessageBox.Show(
                            "Confirm payment?",
                            "Confirm Action",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            MessageBox.Show("Payment completed successfully.", "Payment Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();

                            LawConnect3 f3 = new LawConnect3(selectedId, id);
                            f3.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Cl_id or PIN.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}