using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ear_and_nose_clinic
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void loginPageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myclinicDataSet.Apps' table. You can move, or remove it, as needed.
            this.appsTableAdapter.Fill(this.myclinicDataSet.Apps);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["db"].ToString();
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                sqlcon.Open();
                //select query
                SqlDataAdapter sqldataadapter = new SqlDataAdapter("select * from DOCTOR", sqlcon);
                DataTable datatable = new DataTable();
                sqldataadapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
