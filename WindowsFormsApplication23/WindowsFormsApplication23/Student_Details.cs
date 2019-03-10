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
    public partial class Student_Details : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public Student_Details()
        {
            InitializeComponent();
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void Student_Details_Load(object sender, EventArgs e)
        {
            string cmd = "Select * from Person join Student on Student.Id = Person.Id";
            SqlConnection con = new SqlConnection(conURL);
            SqlDataAdapter ad = new SqlDataAdapter(cmd,con);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            dataGridView1.DataSource = dt;
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { SqlConnection q = new SqlConnection(conURL);
                q.Open();
                string em = "Select Id from Lookup where Value = '" + comboBox1.Text + "' ";
                SqlCommand t = new SqlCommand(em, q);
                int y = (int)t.ExecuteScalar();
                string o = dataGridView1.CurrentRow.Cells["Id"].FormattedValue.ToString();
                int u = Convert.ToInt32(o);
                string s = "Update Person SET FirstName = '" + textBox1.Text + "', LastName = '" + textBox2.Text + "',Contact = '" + textBox3.Text + "',Email = '" + textBox4.Text + "',DateOfBirth = '" + dateTimePicker1.Value + "',Gender = '" + y + "'  where Id = '" + u + "' ";
                SqlCommand g = new SqlCommand(s, q);
                g.ExecuteNonQuery();
                string st = "Update Student SET RegistrationNo = '" + textBox7.Text + "' where Id = '" + u + "' ";
                SqlCommand UO = new SqlCommand(st, q);
                UO.ExecuteNonQuery();
                q.Close();
                }
            catch(Exception et)
            {

                throw (et);
            }
            }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
