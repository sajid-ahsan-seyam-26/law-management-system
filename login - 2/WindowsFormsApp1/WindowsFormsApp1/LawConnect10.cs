using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LawConnect10 : Form
    {
        int id;
        int selectedId;
        public LawConnect10(int i,int j)
        {
            selectedId = i;
            id = j;
            InitializeComponent();

            string[] payment_type = new string[2];
            payment_type[0] = "Bank Payment";
            payment_type[1] = "Mobile Banking";

            type_box.DataSource = payment_type;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void type_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (type_box == null)
            {
                MessageBox.Show("No methods selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method
            }

           else if (type_box.SelectedIndex == 0) 
            {
                LawConnectBank f1 = new LawConnectBank(selectedId,id);
                f1.Show();
               
            }
            else if (type_box.SelectedIndex == 1) 
            {
                LawConnectOnline f2 = new LawConnectOnline(selectedId,id);
                f2.Show();
             
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //this.Hide();
            LawConnect3 f3 = new LawConnect3(selectedId,id);
            f3.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //this.Hide();
            LawConnect4 f4 = new LawConnect4(selectedId,id);
            f4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lawconnect9 f9 = new Lawconnect9(selectedId, id);
            f9.Show();
        }

        private void LawConnect10_Load(object sender, EventArgs e)
        {

        }
    }
}
