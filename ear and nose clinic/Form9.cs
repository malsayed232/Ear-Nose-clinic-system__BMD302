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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ear_and_nose_clinic
{
    public partial class Form9 : Form
    {
        string ConnecstionString = @"Data Source=DESKTOP-PUMEQD8\SQLEXPRESS;Initial Catalog=Clinic_system_4;Integrated Security=True";
        public static string time = "";
        public static string doctor;
        public static string patient;
        string nationalid = "";
        string assignPatient;
        string assignDoctor;
        public static string date;
        public Form9()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void course_Click(object sender, EventArgs e)
        {

        }

      



        private void doctor_Click(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            doctor = comboBox5.Text;
            patient = comboBox4.Text;
            time = comboBox3.Text;
            date = monthCalendar1.SelectionRange.Start.ToShortDateString();
            if (time == "")
            {
                MessageBox.Show("Please Choose a time for reservation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //string conStr = ConfigurationManager.ConnectionStrings["db"].ToString();
                //using (SqlConnection con = new SqlConnection(conStr))

                using (SqlConnection con = new SqlConnection(ConnecstionString))
                {


                    con.Open();
                    SqlCommand com = new SqlCommand("addNewAppointment", con);
                    com.CommandType = CommandType.StoredProcedure;


                    com.Parameters.AddWithValue("@nationalID", nationalid);
                    com.Parameters.AddWithValue("@username", Form1.username);
                    com.Parameters.AddWithValue("@appointmentDate", monthCalendar1.SelectionRange.Start.ToShortDateString());
                    com.Parameters.AddWithValue("@appointmentTime", time);
                    com.Parameters.AddWithValue("@doctorID", assignDoctor);
                    //com.Parameters.AddWithValue("@title", titletxt);
                    com.Parameters.Add("@bool", SqlDbType.Int);
                    com.Parameters["@bool"].Direction = ParameterDirection.Output;

                    com.ExecuteNonQuery();
                    int returnBool = (int)com.Parameters["@bool"].Value;
                    //Console.WriteLine(dateTimePicker1.Value.ToString("hh:mm"));
                    if (returnBool == 1)
                    {
                        MessageBox.Show("This time is Reserved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("A new appointment is added", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }
                
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Form7 obj = new Form7();
            obj.Show();
            this.Hide();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void toolStripComboBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            assignDoctor = comboBox5.SelectedValue.ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           assignPatient = comboBox4.SelectedValue.ToString();
           
        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {

        }
    }
}
