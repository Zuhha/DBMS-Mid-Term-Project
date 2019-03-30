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
    public partial class AllAdvisors : Form
    {
        string c = "Data Source = (local); Initial Catalog = ProjectA; Integrated Security = True";
        Student st = new Student();

        public AllAdvisors()
        {
            InitializeComponent();
        }

        private void AllAdvisors_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection(c);
            string s = "Select a.Id, p.Gender as g, p.FirstName,p.LastName,p.Contact,p.Email,a.Salary,a.Designation,p.DateOfBirth from Advisor as a join Person as p on p.Id = a.Id ";
            SqlDataAdapter ad = new SqlDataAdapter(s, con);
            DataTable st = new DataTable();
            ad.Fill(st);
            dataGridView1.DataSource = st;

            int rows = Convert.ToInt32(dataGridView1.RowCount.ToString());
            for (int i = 0; i < rows; i++)
            {
                int so = Convert.ToInt32(dataGridView1.Rows[i].Cells["g"].Value);

                if (so == 1)
                {
                    dataGridView1.Rows[i].Cells["Gender"].Value = "Male";

                }
                if (so == 2)
                {
                    dataGridView1.Rows[i].Cells["Gender"].Value = "Female";
                }
            }

            dataGridView1.Columns["g"].Visible = false;







            con.Open();
            string f = "Select Value from Lookup where Category = 'DESIGNATION'";
            SqlCommand g = new SqlCommand(f, con);
            SqlDataReader rdr = g.ExecuteReader();
            while (rdr.Read())
            {
                string c = rdr["Value"].ToString();
                comboBox1.Items.Add(c);
            }
            rdr.Close();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                panel2.Visible = true;
                panel1.Visible = false;
               
                txtsalary.Text = dataGridView1.CurrentRow.Cells["Salary"].Value.ToString();
                txtlastname.Text = dataGridView1.CurrentRow.Cells["LastName"].Value.ToString();
                txtfirstname.Text = dataGridView1.CurrentRow.Cells["FirstName"].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells["Gender"].Value.ToString();
                txtcontact.Text = dataGridView1.CurrentRow.Cells["Contact"].Value.ToString();
                txtemail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells["Designation"].Value.ToString();



            }
            else if (e.ColumnIndex == 1)
            {
                int u = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                string s = "Delete from ProjectAdvisor where AdvisorId = '" + u + "'";

                string hu = "Delete from Advisor where Id = '" + u + "'";

                SqlConnection op = new SqlConnection(c);
                op.Open();
                SqlCommand cmd = new SqlCommand(s, op);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(hu, op);
                cmd2.ExecuteNonQuery();
                op.Close();
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                MessageBox.Show("Removed Successfully");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           /* if (txtfirstname.Text == "" || txtlastname.Text == "" || txtcontact.Text == "" || txtemail.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("All Fields Are Required");
            }

            else if (st.Allchar(txtfirstname.Text) == false)
            {
                MessageBox.Show("Enter Valid First Name");
            }
            else if (st.Allchar(txtlastname.Text) == false)
            {
                MessageBox.Show("Enter Valid Last Name");
            }
            else if (st.Alldigits(txtcontact.Text) == false || txtcontact.Text.Length != 11)
            {
                MessageBox.Show("Enter Valid Contact No.");
            }
            else if (st.Email(txtemail.Text) == false)
            {
                MessageBox.Show("Enter a valid Email");
            }


            else if (st.Alldigits(txtsalary.Text) == false)
            {
                MessageBox.Show("Enter Valid Salary");
            }

            else if (st.Email(txtemail.Text) == true && st.Allchar(txtfirstname.Text) == true && st.Allchar(txtlastname.Text) == true && st.Alldigits(txtcontact.Text) == true && txtcontact.Text.Length == 11 && st.Alldigits(txtsalary.Text))
            {*/
            if(lblsalary.Text == "" && lbllastname.Text == "" && lblerror.Text == "" && lblFirstname.Text == "" && lblemail.Text == "" && lbldob.Text == "" && lblcontact.Text == "" && lblgender.Text == "")
                try
                {
                    SqlConnection co = new SqlConnection(c);
                    co.Open();

                    string k = "Select Count(Id) from  Person where FirstName ='" + txtfirstname.Text + "' and LastName = '" + txtlastname.Text + "' and Contact = '" + txtcontact.Text + "'and Id != '" + Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value) + "'";
                    SqlCommand cg = new SqlCommand(k, co);
                    int yo = (int)cg.ExecuteScalar();
                    bool ry = true;
                    if (yo >= 1)
                    {
                        ry = false;
                    }
                    if (ry == false)
                    {
                        lblerror.Text ="This Person has already been added in Record";
                        lblerror.Visible = true;
                    }
                    else if(ry == true)
                    {
                        int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                        string r = "Select Id from Lookup where Value = '" + comboBox1.Text + "'";
                        SqlCommand v = new SqlCommand(r, co);
                        int y = (int)v.ExecuteScalar();

                        string ro = "Select Id from Lookup where Value = '" + comboBox2.Text + "'";
                        SqlCommand vo = new SqlCommand(ro, co);
                        int yy = (int)vo.ExecuteScalar();


                        string s = "Update Advisor SET Designation = '" + y + "', Salary = '" + txtsalary.Text + "'  where Id = '" + id + "' ";


                        SqlCommand q = new SqlCommand(s, co);
                        q.ExecuteNonQuery();


                        string ss = "Update Person SET FirstName = '" + txtfirstname.Text + "', LastName = '" + txtlastname.Text + "',Contact = '" + txtcontact.Text + "',Email = '" + txtemail.Text + "',DateOfBirth = '" + dateTimePicker1.Value + "',Gender = '" + yy + "'  where Id = '" + id + "' ";
                        SqlCommand g = new SqlCommand(ss, co);
                        g.ExecuteNonQuery();


                        co.Close();
                        MessageBox.Show("Updated");
                        this.Hide();
                        AllAdvisors frm = new AllAdvisors();
                        frm.Show();
                    }


                    
                }

                catch (Exception et)
                {
                    throw (et);
                }
            }

       // }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Person_Details frm = new Person_Details();
            this.Hide();
            frm.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblcontact_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_KeyUp(object sender, KeyEventArgs e)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblerror.Text = "";
            if (dateTimePicker1.Value > DateTime.Now)
            {
                lbldob.Text = "Enter correct Date Of Birth";
                
            }
            else
            {
                lbldob.Text = "";
            }
            if(comboBox2.Text == "")
            {
                lblgender.Text = "Enter Gender";
            }
            else
            {
                lblgender.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblerror.Text = "";
            if(comboBox2.Text == "")
            {
                lblgender.Text = "Enter Gender";
            }
            else
            {
                lblgender.Text = "";
            }
        }

        private void txtsalary_TextChanged(object sender, EventArgs e)
        {
            lblerror.Text = "";
            if(comboBox1.Text == "")
            {
                lblerror.Text = "Select Designation";
            }
            else
            {
                lblerror.Text = "";
            }
        }

        private void txtsalary_KeyUp(object sender, KeyEventArgs e)
        {
            if(st.Alldigits(txtsalary.Text) != true)
            {
                lblsalary.Text = "Digits Only";
            }
            else
            {
                lblsalary.Text = "";
            }
        }

        private void panel2_BackgroundImageLayoutChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            ViewReports frm = new ViewReports();
            this.Hide();
            frm.Show();
        }
    }
}
