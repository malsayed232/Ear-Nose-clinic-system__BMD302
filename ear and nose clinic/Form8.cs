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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ear_and_nose_clinic
{
    public partial class Form8 : Form
    {
        string ConnecstionString = @"Data Source=DESKTOP-PUMEQD8\SQLEXPRESS;Initial Catalog=Clinic_system_4;Integrated Security=True";
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        public static string nationalID;
        /// <summary>
        //int genderCode = -1;
        /// </summary>
        public static bool newPatient = false;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string conStr = ConfigurationManager.ConnectionStrings["db"].ToString();
            //using (SqlConnection con = new SqlConnection(conStr))

            
            using (SqlConnection con = new SqlConnection(ConnecstionString))
            {
                string name = pName.Text;
                //DateTime dob = Convert.ToDateTime(pDOB.Text);
                String dob = pDOB.Text;
                string phoneNumber = pPhone.Text;
                nationalID = pNationalID.Text;
                string age = pAge.Text;
                string height = pHeight.Text;
                string address = pAddress.Text;
                string gender = pGender.Text;
                //if (genderCode == 1)
                //{
                    //gender = "male";
                //}
                //else if (genderCode == 2)
                //{
                    //gender = "female";
               // }

                string history = pHistory.Text;
                string OtherINFO = pOtherINFO.Text;
                
                if (pNationalID.Text == "" && nationalID.Length < 14)
                {
                    MessageBox.Show("National ID either empty or invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //else if 
                //{
                    //MessageBox.Show("This patient already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}
                else
                {
                    con.Open();
                    String addNewPatient = "INSERT INTO patient(patientName, DOB, phoneNumber, NationalID, age, address, gender, height, PatientHistory,OtherINFO ) VALUES (@name, @dob, @phoneNumber, @nationalID, @age, @address, @gender, @height, @PatientHistory ,@OtherINFO);";
                    SqlCommand cmd = new SqlCommand(addNewPatient, con);
                    //cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@nationalID", nationalID);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@height", height);
                    cmd.Parameters.AddWithValue("@PatientHistory", history);
                    cmd.Parameters.AddWithValue("@OtherINFO", OtherINFO);

                    
                    MessageBox.Show("The patient sucessfully added", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newPatient = true;
                    cmd.ExecuteNonQuery();


                   

                }
                

                

            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Form7 obj = new Form7();
            obj.Show();
            this.Hide();
        }
    }
}
