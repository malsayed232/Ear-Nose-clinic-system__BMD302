using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
namespace ear_and_nose_clinic
{

    public partial class Form1 : Form
    {
        string connecstionString = @"Data Source=DESKTOP-PUMEQD8\SQLEXPRESS;Initial Catalog=Clinic_system_4;Integrated Security=True";
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PUMEQD8\SQLEXPRESS;Initial Catalog=Clinic_system_3;Integrated Security=True");
        //SqlCommand cmd = new SqlCommand();

        public static string username;
        public static string user_password;
        public static string role;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connecstionString))
            {
                username = textBox1.Text;
                user_password = textBox2.Text;
                con.Open();
                SqlCommand com = new SqlCommand("checkLogin", con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.AddWithValue("@username", username);
                com.Parameters.AddWithValue("@password", user_password);

                com.Parameters.Add("@role", SqlDbType.VarChar, 100);
                com.Parameters["@role"].Direction = ParameterDirection.Output;
                com.Parameters.Add("@status", SqlDbType.Int);
                com.Parameters["@status"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                int returnStatus = (int)com.Parameters["@status"].Value;


                if (returnStatus == 1)
                {
                    if (comboBox1.Text == "Doctor")
                    {
                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide();
                    }
                    else 
                    {
                        Form7 obj = new Form7();
                        obj.Show();
                        this.Hide();
                    }


                }
                else
                {
                    MessageBox.Show("Either username or password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                // String username, user_password;
               // username = textBox1.Text;
                //user_password = textBox2.Text;

                //try
                //{/
                    //String querry = "SELECT * FROM Login1 WHERE UserName = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "'";
                    //SqlDataAdapter sda = new SqlDataAdapter(querry, con);
                    //DataTable dtable = new DataTable();
                    //sda.Fill(dtable);
                    //if (dtable.Rows.Count > 0)
                    //{
                        //username = textBox1.Text;
                        //user_password = textBox2.Text;
                       // Form2 form2 = new Form2();
                        //form2.Show();
                        //this.Hide();
                   // }
                    //else
                    //{
                        //MessageBox.Show("Invalid Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //textBox1.Clear();
                        //textBox2.Clear();



                       // textBox1.Focus();
                    //}
                //}
                //catch
                //{
                    //MessageBox.Show("Error");
                //}
                //finally
                //{
                    //con.Close();
                //}
            }
     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
