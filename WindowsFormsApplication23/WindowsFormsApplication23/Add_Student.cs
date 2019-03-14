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

        }

        private void button1_Click(object sender, EventArgs e)
        {

           
                Student st = new Student();
               
                if(st.Allchar(txtfirstname.Text) == false)
                {
                    MessageBox.Show("Enter Valid First Name");
                }
               else if (st.Allchar(txtlastname .Text) == false)
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

            if (st.Email(txtemail.Text) == true && st.Allchar(txtfirstname.Text) == true && st.Allchar(txtlastname.Text)== true && st.Alldigits(txtcontact.Text)== true && txtcontact.Text.Length == 11)
                {

                    
                    try
                    {
                    string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
                    SqlConnection con = new SqlConnection(conURL);
                    con.Open();

                    string k = "Select Count(Id) from Person where FirstName ='" + txtfirstname.Text + "' and LastName = '" + txtlastname.Text + "' and Contact = '" + txtcontact.Text + "'";
                    SqlCommand cg = new SqlCommand(k, con);
                    int yo = (int)cg.ExecuteScalar();
                    bool ry = true;
                    if(yo >= 1)
                    {
                         ry = false;
                    }
                    string kl = "Select Count(Id) from Student where RegistrationNo ='" + txtregno.Text + "'";
                    SqlCommand cgo = new SqlCommand(kl, con);
                    int yoo = (int)cgo.ExecuteScalar();
                    bool v = true;
                    if(yoo >= 1)
                    {
                         v = false;
                    }
                    if(ry == false)
                    {
                        MessageBox.Show("This Person has already been added in Record");
                    }
                    else if (v == false)
                    {
                        MessageBox.Show("This RegistrationNo is already in Record") ;
                    }

                    else if(ry == true && v == true)
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


                        string stmt = "Select max(Id) from Person ";
                        SqlCommand b = new SqlCommand(stmt, con);
                        int y = (int)b.ExecuteScalar();

                        string Query = "Insert into Student(Id, RegistrationNo) values ('" + y + "','" + txtregno.Text + "')";
                        SqlCommand o = new SqlCommand(Query, con);
                        o.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Person has been added");
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
            AllAdvisors frm = new AllAdvisors();
            frm.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Add_Advisor ad = new Add_Advisor();
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
    }
}

