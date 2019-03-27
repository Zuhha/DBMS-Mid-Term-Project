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
    public partial class Person_Details : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public Person_Details()
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
            btninsert.Visible = false;
            txtregno.Visible = false;
            txtsalary.Visible = false;
            comboBox2.Visible = false;
            label9.Visible = false;
            label8.Visible = false;
            label11.Visible = false;
            SqlConnection c = new SqlConnection(conURL);
            c.Open();
            string cmd = "Select Value from Lookup where Category = 'DESIGNATION' Order by Value";
            SqlCommand q = new SqlCommand(cmd, c);
            SqlDataReader rdr = q.ExecuteReader();

            while (rdr.Read())
            {
                string h = rdr[0].ToString();
                comboBox2.Items.Add(h);
            }
            c.Close();
            label11.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();

            if (comboBox3.Text == "Advisor" && (txtsalary.Text == "" || comboBox2.Text == "" || txtfirstname.Text == "" || txtlastname.Text == "" || txtcontact.Text == "" || txtemail.Text == "" || comboBox1.Text == "" || comboBox2.Text == ""))
            {
                MessageBox.Show("All Fields Are Required");
            }
            if (comboBox3.Text == "Student" && (txtregno.Text == "" || txtfirstname.Text == "" || txtlastname.Text == "" || txtcontact.Text == "" || txtemail.Text == "" || comboBox1.Text == ""))
            {
                MessageBox.Show("All Fields Are Required");
            }
            else if(txtregno.Text.Length != 11 && comboBox3.Text == "Student")
            {
                MessageBox.Show("Enter valid REgNo");
            }
            else if(st.REGNO(txtregno.Text) == false && comboBox3.Text == "Student")
            {
                MessageBox.Show("Enter a valid Registration Number (XXXX-YY-XXX)");
            }

            else if (st.Alldigits(txtsalary.Text) == false)
            {
                MessageBox.Show("Enter Valid Salary");
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



           

         /*   else if (st.Allchar(txtfirstname.Text) == false)
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

    */
            if (st.Email(txtemail.Text) == true && st.Allchar(txtfirstname.Text) == true && st.Allchar(txtlastname.Text) == true && st.Alldigits(txtcontact.Text) == true && txtcontact.Text.Length == 11 )
            {



                try
                {

                    SqlConnection con = new SqlConnection(conURL);
                    con.Open();

                    string k = "Select Count(Id) from Person where FirstName ='" + txtfirstname.Text + "' and LastName = '" + txtlastname.Text + "' and Contact = '" + txtcontact.Text + "'";
                    SqlCommand cg = new SqlCommand(k, con);
                    int yo = (int)cg.ExecuteScalar();
                    bool ry = true;
                    if (yo >= 1)
                    {
                        ry = false;
                    }




                    string kl = "Select Count(Id) from Student where RegistrationNo ='" + txtregno.Text + "'";
                    SqlCommand cgo = new SqlCommand(kl, con);
                    int yoo = (int)cgo.ExecuteScalar();
                    bool v = true;
                    if (yoo >= 1)
                    {
                        v = false;
                    }



                    string stmt = "Select max(Id) from Person ";
                    SqlCommand b = new SqlCommand(stmt, con);
                    int y = (int)b.ExecuteScalar();

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
                        string em = "Select Id from Lookup where Value = '" + comboBox1.Text + "'";
                        SqlCommand nd = new SqlCommand(em, con);
                        SqlDataReader r = nd.ExecuteReader();
                        int id = 0;
                        while (r.Read())
                        {
                            id = r.GetInt32(0);
                        }
                        r.Close();
                        string cmd = "INSERT INTO Person(FirstName, LastName, Contact, Email,DateOfBirth, Gender) values ('" + txtfirstname.Text + "','" + txtlastname.Text + "','" + txtcontact.Text + "','" + txtemail.Text + "','" + (dateTimePicker1.Value) + "','" + id + "')";
                        SqlCommand command = new SqlCommand(cmd, con);
                        command.ExecuteNonQuery();



                        if (comboBox3.Text == "Student"&& txtregno.Text.Length == 11 && st.REGNO(txtregno.Text) == true)
                        {
                            txtregno.Visible = true;
                            string Query = "Insert into Student(Id, RegistrationNo) values ('" + y + "','" + txtregno.Text + "')";
                            SqlCommand o = new SqlCommand(Query, con);
                            o.ExecuteNonQuery();
                            MessageBox.Show("Student has been added");

                        }
                        else if (comboBox3.Text == "Advisor" && st.Alldigits(txtsalary.Text) == true)
                        {
                            txtsalary.Visible = true;

                            string cmdn = "Select Id from Lookup where Value = '" + comboBox2.Text + "'";
                            SqlCommand qn = new SqlCommand(cmdn, con);
                            int yn = (int)qn.ExecuteScalar();
                            string x = "Insert into Advisor(Id,Designation, Salary) values ('" + y + "','" + yn + "','" + txtsalary.Text + "')";
                            SqlCommand u = new SqlCommand(x, con);
                            u.ExecuteNonQuery();
                            MessageBox.Show("Advisor has been added");


                        }
                        else if (comboBox3.Text == "Advisor" && st.Alldigits(txtsalary.Text) == false)
                        {
                            MessageBox.Show("Enter Correct Salary");
                        }


                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("Enter Correct Data");
                    }


                }
                catch (Exception et)
                {
                    throw (et);
                }
            }


            }

           










        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Hide();
            AllAdvisors frm = new AllAdvisors();
            frm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AllProjects frm = new AllProjects();
            frm.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Person_Details ad = new Person_Details();
            ad.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Add_Project ad = new Add_Project();
            ad.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Student_Details g = new Student_Details();
            g.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Assign_Project_To_Advisor ad = new Assign_Project_To_Advisor();
            ad.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProjectandAdvisorDetails d = new ProjectandAdvisorDetails();
            d.Show();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AllEvaluations r = new AllEvaluations();
            r.Show();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Show(); 
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateGroup g = new CreateGroup();
            this.Hide();
            g.Show();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Evaluation er = new Evaluation();
            this.Hide();
            er.Show();
        }

       

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Student")
            {
                txtregno.Visible = true;
                label11.Visible = true;
                btninsert.Visible = true;
                txtsalary.Visible = false;
                comboBox2.Visible = false;
                label9.Visible = false;
                label8.Visible = false;
                btninsert.Visible = true;
                btninsert.Text = "Add Student";

            }
            else
            {
                txtregno.Visible = false;
                label11.Visible = false;
              
                btninsert.Text = "Add Advisor";
                txtsalary.Visible = true;
                comboBox2.Visible = true;
                label9.Visible = true;
                label8.Visible = true;
                btninsert.Visible = true;
            }
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GroupDetails g = new GroupDetails();
            this.Hide();
            g.Show();
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditStatus ed = new EditStatus();
            this.Hide();
            ed.Show();
        }
    }
}

