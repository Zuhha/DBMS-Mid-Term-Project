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
                txtfirstName.Text = dataGridView1.CurrentRow.Cells["FirstName"].Value.ToString();
                txtLastName.Text = dataGridView1.CurrentRow.Cells["LastName"].Value.ToString();
                txtregno.Text = dataGridView1.CurrentRow.Cells["RegistrationNo"].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                txtContact.Text = dataGridView1.CurrentRow.Cells["Contact"].Value.ToString();
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
                MessageBox.Show("Deleted");
            }

           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            if (txtfirstName.Text == "" || txtLastName.Text == "" || txtContact.Text == "" || txtEmail.Text == "" || cmbgender.Text == "")
            {
                MessageBox.Show("All Fields Are Required");
            }

            else if (st.Allchar(txtfirstName.Text) == false)
            {
                MessageBox.Show("Enter Valid First Name");
            }
            else if (st.Allchar(txtLastName.Text) == false)
            {
                MessageBox.Show("Enter Valid Last Name");
            }
            else if (st.Alldigits(txtContact.Text) == false || txtContact.Text.Length != 11)
            {
                MessageBox.Show("Enter Valid Contact No.");
            }
            else if (st.Email(txtEmail.Text) == false)
            {
                MessageBox.Show("Enter a valid Email");
            }

           else if (st.Email(txtEmail.Text) == true && st.Allchar(txtfirstName.Text) == true && st.Allchar(txtLastName.Text) == true && st.Alldigits(txtContact.Text) == true && txtContact.Text.Length == 11)
            {
                SqlConnection con = new SqlConnection(conURL);
                con.Open();

                string k = "Select Count(Id) from Person where FirstName ='" + txtfirstName.Text + "' and LastName = '" + txtLastName.Text + "' and Contact = '" + txtContact.Text + "'";
                SqlCommand cg = new SqlCommand(k, con);
                int yo = (int)cg.ExecuteScalar();
                bool ry = true;
                if (yo > 1)
                {
                    ry = false;
                }
                string kl = "Select Count(Id) from Student where RegistrationNo ='" + txtregno.Text + "'";
                SqlCommand cgo = new SqlCommand(kl, con);
                int yoo = (int)cgo.ExecuteScalar();
                bool v = true;
                if (yoo > 1)
                {
                    v = false;
                }
                if (ry == false)
                {
                    MessageBox.Show("This Person has already been added in Record");
                }
                else if (v == false)
                {
                    MessageBox.Show("This RegistrationNo is already in Record");
                }

                else if (ry == true && v == true)
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
                        string stU = "Update Student SET RegistrationNo = '" + txtregno.Text + "' where Id = '" + u + "' ";
                        SqlCommand UO = new SqlCommand(stU, q);
                        UO.ExecuteNonQuery();
                        q.Close();
                        MessageBox.Show("Updated");
                        panel2.Visible = false;
                        panel1.Visible = true;
                    }
                    catch (Exception et)
                    {

                        throw (et);
                    }

                }

            }
              
            }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Person_Details frm = new Person_Details();
            this.Hide();
            frm.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Add_Project frm = new Add_Project();
            this.Hide();
            frm.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Add_Advisor frm = new Add_Advisor();
            this.Hide();
            frm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AllProjects frm = new AllProjects();
            this.Hide();
            frm.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Student_Details frm = new Student_Details();
            this.Hide();
            frm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AllAdvisors frm = new AllAdvisors();
            this.Hide();
            frm.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Assign_Project_To_Advisor frm = new Assign_Project_To_Advisor();
            this.Hide();
            frm.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProjectandAdvisorDetails frm = new ProjectandAdvisorDetails();
            this.Hide();
            frm.Show();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AllEvaluations frm = new AllEvaluations();
            this.Hide();
            frm.Show();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateGroup frm = new CreateGroup();
            this.Hide();
            frm.Show();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Evaluation frm = new Evaluation();
            this.Hide();
            frm.Show();
        }
    }
}
