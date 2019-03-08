using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection con = new SqlConnection(conURL);
            con.Open();
            string cmd = "INSERT INTO Person(FirstName, LastName, Contact, Email,DateOfBirth, Gender) values ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+(dateTimePicker1.Value)+"','"+textBox6.Text+"')";
            SqlCommand command = new SqlCommand(cmd, con);
            command.ExecuteNonQuery();


            string stmt = "Select max(Id) from Person ";
            SqlCommand b = new SqlCommand(stmt, con);
            int y = (int)b.ExecuteScalar();

            string Query = "Insert into Student(Id, RegistrationNo) values ('" + y + "','"+textBox7.Text+"')";
            SqlCommand o = new SqlCommand(Query, con);
            o.ExecuteNonQuery();
            con.Close();
           
           
            
           
            
           
           

        }
    }
}
