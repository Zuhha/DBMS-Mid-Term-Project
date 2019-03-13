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
            if(e.ColumnIndex == 0)
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
           
            else if(e.ColumnIndex == 1)
            {
                string o = dataGridView1.CurrentRow.Cells["Id"].FormattedValue.ToString();
                int u = Convert.ToInt32(o);
                string s = "Delete from Student where Id = '" + u + "'";
                string st = "Delete from Person Where Id = '" + u + "'";
                string hu = "Delete from GroupStudent where StudentId = '" + u + "'";
                string r = "Delete from ((Select * from Student join Person On Student.Id = '"+u+"')join GroupStudent on StudentId = '"+u+"')";
                SqlConnection op = new SqlConnection(conURL);
                op.Open();
                SqlCommand cmd = new SqlCommand(hu, op);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand(s, op);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand(st, op);
                cmd2.ExecuteNonQuery();
                op.Close();
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
            }

           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection q = new SqlConnection(conURL);
                q.Open();
                string em = "Select Id from Lookup where Value = '" + cmbgender.Text + "' ";
                SqlCommand t = new SqlCommand(em, q);
                int y = (int)t.ExecuteScalar();
                string o = dataGridView1.CurrentRow.Cells["Id"].FormattedValue.ToString();
                int u = Convert.ToInt32(o);
                string s = "Update Person SET FirstName = '" + txtfirstName.Text + "', LastName = '" + txtLastName.Text + "',Contact = '" + txtContact.Text + "',Email = '" + txtEmail.Text + "',DateOfBirth = '" + dtpdob.Value + "',Gender = '" + y + "'  where Id = '" + u + "' ";
                SqlCommand g = new SqlCommand(s, q);
                g.ExecuteNonQuery();
                string st = "Update Student SET RegistrationNo = '" + txtregno.Text + "' where Id = '" + u + "' ";
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
