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
        Student st = new Student();
        public Student_Details()
        {
            InitializeComponent();
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void Student_Details_Load(object sender, EventArgs e)
        {
            string cmd = "Select Person.Id, Student.RegistrationNo,Person.FirstName,Person.LastName,Person.Contact,Person.Email,Person.Gender as g,Person.DateOfBirth from Person join Student on Student.Id = Person.Id";
            SqlConnection con = new SqlConnection(conURL);
            SqlDataAdapter ad = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            dataGridView1.DataSource = dt;
            int rows = Convert.ToInt32(dataGridView1.RowCount.ToString());
            for (int i = 0; i < rows; i++)
            {
                int s = Convert.ToInt32(dataGridView1.Rows[i].Cells["g"].Value);

                if (s == 1)
                {
                    dataGridView1.Rows[i].Cells["Gender"].Value = "Male";

                }
                if (s == 2)
                {
                    dataGridView1.Rows[i].Cells["Gender"].Value = "Female";
                }
            }

            dataGridView1.Columns["g"].Visible = false;



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                txtfirstname.Text = dataGridView1.CurrentRow.Cells["FirstName"].Value.ToString();
                txtlastname.Text = dataGridView1.CurrentRow.Cells["LastName"].Value.ToString();
                txtregno.Text = dataGridView1.CurrentRow.Cells["RegistrationNo"].Value.ToString();
                txtemail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                txtcontact.Text = dataGridView1.CurrentRow.Cells["Contact"].Value.ToString();
            }

            else if (e.ColumnIndex == 1)
            {
                string o = dataGridView1.CurrentRow.Cells["Id"].FormattedValue.ToString();
                int u = Convert.ToInt32(o);
                string s = "Delete from Student where Id = '" + u + "'";
                string st = "Delete from Person Where Id = '" + u + "'";
                string hu = "Delete from GroupStudent where StudentId = '" + u + "'";
                string r = "Delete from ((Select * from Student join Person On Student.Id = '" + u + "')join GroupStudent on StudentId = '" + u + "')";
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
            if (lbllastname.Text == "" && lblFirstname.Text == "" && lblcontact.Text == "" && lblemail.Text == "" && lblerror.Text == "" && lblregdesig.Text == "")
            {
                SqlConnection con = new SqlConnection(conURL);
                con.Open();

                string k = "Select Count(Id) from  Person where FirstName ='" + txtfirstname.Text + "' and LastName = '" + txtlastname.Text + "' and Contact = '" + txtcontact.Text + "'and Id != '" + Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value) + "'";
                SqlCommand cg = new SqlCommand(k, con);
                int yo = (int)cg.ExecuteScalar();
                bool ry = true;
                if (yo >= 1)
                {
                    ry = false;
                }
                string kl = "Select Count(Id) from Student where RegistrationNo ='" + txtregno.Text + "' and Id != '"+Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value)+"'";
                SqlCommand cgo = new SqlCommand(kl, con);
                int yoo = (int)cgo.ExecuteScalar();
                bool v = true;
                if (yoo >= 1)
                {
                    v = false;
                }
                if (ry == false)
                {
                    lblerror.Text = "This Person has already been added in Record";
                   // MessageBox.Show("This Person has already been added in Record");
                }
                else if (v == false)
                {
                    lblerror.Text = "This RegistrationNo is already in Record";
                    //MessageBox.Show("This RegistrationNo is already in Record");
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
                        string s = "Update Person SET FirstName = '" + txtfirstname.Text + "', LastName = '" + txtlastname.Text + "',Contact = '" + txtcontact.Text + "',Email = '" + txtemail.Text + "',DateOfBirth = '" + dtpdob.Value + "',Gender = '" + y + "'  where Id = '" + u + "' ";
                        SqlCommand g = new SqlCommand(s, q);
                        g.ExecuteNonQuery();
                        string stU = "Update Student SET RegistrationNo = '" + txtregno.Text + "' where Id = '" + u + "' ";
                        SqlCommand UO = new SqlCommand(stU, q);
                        UO.ExecuteNonQuery();
                        q.Close();
                        MessageBox.Show("Updated");
                        panel2.Visible = false;
                        this.Hide();
                        Student_Details frm = new Student_Details();
                        frm.Show();

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
            GroupDetails frm = new GroupDetails();
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

        private void txtfirstName_KeyUp(object sender, KeyEventArgs e)
        {
            lblerror.Text = "";
            if (st.Allchar(txtfirstname.Text) == false)
            {
                lblFirstname.Text = "Characters Only!!!";

            }
            else
            {
                lblFirstname.Text = "";
            }
        }

        private void txtLastName_KeyUp(object sender, KeyEventArgs e)
        {
            lblerror.Text = "";
            if (st.Allchar(txtlastname.Text) == false)
            {
                lbllastname.Text = "Characters Only!!!";

            }
            else
            {
                lbllastname.Text = "";
            }
        }

        private void txtContact_KeyUp(object sender, KeyEventArgs e)
        {
            lblerror.Text = "";
            if (st.Alldigits(txtcontact.Text) == false)
            {
                lblcontact.Text = "Digits Only!!!";

            }

            else
            {
                lblcontact.Text = "";
            }
        }

        private void txtEmail_KeyUp(object sender, KeyEventArgs e)
        {
            lblerror.Text = "";
            if (st.Email(txtemail.Text) == false)
            {
                lblemail.Text = "Characters Only!!!";
                lblerror.Text = "";
            }
            else
            {
                lblemail.Text = "";
            }
        }

        private void txtregno_KeyUp(object sender, KeyEventArgs e)
        {
            lblerror.Text = "";
            if ( st.REGNO(txtregno.Text) == true) 
            {
                lblregdesig.Text = "";
                lblregdesig.Visible = true;
            }
            else if (st.REGNO(txtregno.Text) != true)
            {
                lblregdesig.Text = "Enter Correct Registration Number of format YYYY-DD-NNN";
                lblregdesig.Visible = true;
            }
        }

        private void txtregno_TextChanged(object sender, EventArgs e)
        {
            if(cmbgender.Text != "")
            {
                lblgender.Text = "";
            }
            else
            {
                lblgender.Text = "Please Select Gender";
                lblgender.Visible = true;
            }
        }

        private void cmbgender_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblgender.Visible = false;
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
