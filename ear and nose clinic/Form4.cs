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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Configuration;

namespace ear_and_nose_clinic
{
    public partial class Form4 : Form
    {
        string connecstionString = @"Data Source=DESKTOP-PUMEQD8\SQLEXPRESS;Initial Catalog=Clinic_system_4;Integrated Security=True";
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PUMEQD8\SQLEXPRESS;Initial Catalog=Clinic_system_3;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public static string username;
        public static string password;
        public static string confirm_password;
        //public static string role;
        //int roleCode = -1;
        public static bool newUser = false;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string conStr = ConfigurationManager.ConnectionStrings["db"].ToString();
            //using (SqlConnection con = new SqlConnection(conStr))
            using (SqlConnection con = new SqlConnection(connecstionString))
            {
                username = tbUsername.Text;
                password = textBox2.Text;
                confirm_password = textBox3.Text;
                String role = comboBox1.Text;
                //if (roleCode == 1)
                //{
                //    role = "Doctor";
                //}
                //else if (roleCode == 2)
                //{
               //     role = "Nurse";
                //}

                if (tbUsername.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Please enter all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (textBox2.Text == textBox3.Text)
                {
                    con.Open();
                    String register = "INSERT INTO UserAccount(username,password,role) VALUES (@username,@password,@role); ";
                    SqlCommand cmd = new SqlCommand(register, con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    // cmd.Parameters.AddWithValue("@confirm_password", confirm_password);
                    cmd.Parameters.AddWithValue("@role", role);
                    MessageBox.Show("The new user sucessfully added", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newUser = true;
                    
                    Form1 obj = new Form1();
                    obj.Show();
                    this.Hide();
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Password and confirm password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


               // try
               //{

                //else
                //{


                // }
                //}
                //if (!Form1.Instance.pnlFormLoader.Controls.ContainsKey("ucReserve"))
                //{
                //Form1.Instance.lblTitle.Text = "Reserve";
                //ucReserve nu = new ucReserve();
                //nu.Dock = DockStyle.Fill;
                //Form1.Instance.pnlFormLoader.Controls.Add(nu);
                //}
                //Form1.Instance.pnlFormLoader.Controls["ucReserve"].BringToFront();
                //Form1.Instance.pnlFormLoader.Visible = true;


                //catch
                //{
                    //MessageBox.Show("This user already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //if (String.IsNullOrEmpty(nationalID) || nationalID.Length < 14)
                    //if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(confirm_password) || String.IsNullOrEmpty(role))
                    //{
                        //MessageBox.Show("National ID either empty or invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //else
                    //{
                    //MessageBox.Show("This user already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //}
                //}
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reserveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
