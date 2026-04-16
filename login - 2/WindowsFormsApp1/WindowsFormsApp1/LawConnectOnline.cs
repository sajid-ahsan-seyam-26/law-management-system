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
    public partial class LawConnectOnline : Form
    {
        int id;
        int selectedId;
        public LawConnectOnline (int i,int j)
        {
            selectedId = i;
            id=j;
            InitializeComponent();

            string[] names = new string[4];
            names[0] = "bKash";
            names[1] = "Nagad";
            names[2] = "Rocket";
            names[3] = "UPay";

            type_box.DataSource = names;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (type_box.SelectedItem == null)
            {
                MessageBox.Show("No payment method selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cNum = textBox1.Text.Trim();
            string pin = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(cNum) || string.IsNullOrWhiteSpace(pin))
            {
                MessageBox.Show("Please enter both Phone number and PIN.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(cNum, out long parsedCNum))
            {
                MessageBox.Show("Phone number must be valid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(pin, out int parsedPin) || pin.Length != 4)
            {
                MessageBox.Show("PIN must be exactly 4 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";
            string query = "SELECT COUNT(*) FROM Client WHERE C_num = @C_num AND Pin COLLATE SQL_Latin1_General_CP1_CS_AS = @Pin";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@C_num", cNum);
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

                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Number or PIN.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LawConnectOnline_Load(object sender, EventArgs e)
        {

        }
    }
}
    

    

