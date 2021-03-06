﻿using System;
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
        
        Student st = new Student();
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
            lblregdesig.Visible = false;
            lblsalary.Visible = false;
            lblerror.Visible = false;
            btninsert.Visible = false;
            txtregno.Visible = false;
            txtsalary.Visible = false;
            comboBox2.Visible = false;
            label9.Visible = false;
            label8.Visible = false;
            label11.Visible = false;
            Person p = new Person();
            p.load("Select Value from Lookup where Category = 'DESIGNATION' Order by Value", comboBox2);
            label11.Visible = false;
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            if(comboBox2.Text == "" && comboBox3.Text == "ADVISOR")
            {
                lblerror.Text = "Select Designation Please";
                lblerror.Visible = true;
            }
            else if(comboBox2.Text != "" && comboBox3.Text == "ADVISOR" || comboBox2.Text == "" && comboBox3.Text == "STUDENT")
            {
                lblerror.Text = "";
            }
           
           if(lbllastname.Text == "" && lblFirstname.Text == "" && lblcontact.Text == ""&&  lblemail.Text == "" && lblerror.Text == "" && lbldob.Text == "")
            { 


                try
                {

                    string s = "Select Count(Id) from Person where FirstName = '" + txtfirstname.Text + "' and LastName = '" + txtlastname.Text + "' and Contact = '" + txtcontact.Text + "'";
                    bool ry = st.uniqueperson(txtfirstname.Text, txtlastname.Text,txtcontact.Text,s);
                    string ios = "Select Count(Id) from Student where RegistrationNo ='" + txtregno.Text + "'";
                    bool v = st.uniqueregno(txtregno.Text,ios) ;
               
                    int y = st.maxid();

                    if (ry == false)
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "This Person has already been added in Record";
                        
                    }



                    else if (v == false)
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "This RegistrationNo is already in Record";
                       
                    }

                    else if (ry == true && v == true)
                    {
                        st.Addperson(txtfirstname.Text, txtlastname.Text, txtcontact.Text, txtemail.Text, cmbgender.Text, dateTimePicker1.Value);



                        if (comboBox3.Text == "STUDENT"&& txtregno.Text.Length == 11 && st.REGNO(txtregno.Text) == true)
                        {
                            txtregno.Visible = true;
                            st.addstindb(txtregno.Text);
                            st.AddStudent(txtfirstname.Text, txtlastname.Text, txtcontact.Text, txtemail.Text, cmbgender.Text, dateTimePicker1.Value,txtregno.Text);
                            MessageBox.Show("Student has been added");

                        }
                        else if (comboBox3.Text == "ADVISOR" && st.Alldigits(txtsalary.Text) == true)
                        {
                            txtsalary.Visible = true;

                            Advisor ad = new Advisor();
                            ad.AddAdvisor(comboBox2.Text, Convert.ToInt32(txtsalary.Text));
                            ad.Addadvisorindb();
                           
                            MessageBox.Show("Advisor has been added");


                        }
                    


                       

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
           else
            {
                lblerror.Text="Enter Correct Data";
                lblerror.Visible = true;
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
            txtregno.Text = "";
            txtsalary.Text = "";
            comboBox2.Text = "";
            if(cmbgender.Text == "")
            {
                lblgender.Text = "Select Gender Please";
                lblgender.Visible = true;
            }
            else if(cmbgender.Text != "")
            {
                lblgender.Text = "";
                lblgender.Visible = true;
            }
            if (comboBox3.Text == "STUDENT")
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

        private void txtfirstname_KeyUp(object sender, KeyEventArgs e)
        {
            Person P = new Person();
            
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

        private void txtlastname_KeyUp(object sender, KeyEventArgs e)
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

        private void txtcontact_KeyUp(object sender, KeyEventArgs e)
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

        private void txtemail_KeyUp(object sender, KeyEventArgs e)
        {
            lblerror.Text = "";
            if (st.Emails(txtemail.Text) == false)
            {
                lblemail.Text = "Enter Correct email!!!";
                lblerror.Text = "";
            }
            else
            {
                lblemail.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtregno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtregno_KeyUp(object sender, KeyEventArgs e)
        {
            lblerror.Text = "";
            if ((comboBox3.Text == "STUDENT" && st.REGNO(txtregno.Text) == true) || comboBox3.Text == "ADVISOR" && txtregno.Text == "")
            {
                lblregdesig.Text = "";
                lblregdesig.Visible = true;
            }
            else if(comboBox3.Text == "STUDENT" && st.REGNO(txtregno.Text) != true)
            {
                lblregdesig.Text = "Enter Correct Registration Number of format YYYY-DD-NNN";
                lblregdesig.Visible = true;
            }
        }

        private void txtsalary_KeyUp(object sender, KeyEventArgs e)
        {
            lblerror.Text = "";
            if (st.Alldigits(txtsalary.Text) == false)
            {
                lblsalary.Text = "Digits Only!!!";
                lblsalary.Visible = true;
            }
          
            else if(comboBox3.Text == "ADVISOR" && st.Alldigits(txtsalary.Text) != false || comboBox3.Text == "STUDENT" && txtsalary.Text == "")
            {
                lblsalary.Text = "";
                lblsalary.Visible = true;
            }
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            lblerror.Text = "";
            if (txtcontact.Text.Length != 11)
            {
                lblcontact.Text = "Enter Correct Contact Number";
            }
            else if(txtcontact.Text.Length == 11)
            {
                lblcontact.Text = "";
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lbldob.Text = "";
            lblerror.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblregdesig.Text = "";
            lblerror.Text = "";
        }

        private void txtsalary_TextChanged(object sender, EventArgs e)
        {
            lblsalary.Text = "";
            lblerror.Text = "";
        }

      

        

       

      

        private void txtfirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbgender_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbldob.Text = "";
            lblerror.Text = "";
            lblgender.Visible = false;
            if (dateTimePicker1.Value >= DateTime.Now)
            {
                lbldob.Text = "Enter correct Dob";
                lbldob.Visible = true;
            }
            else
            {
                lbldob.Text = "";
            }
            if (comboBox2.Text != "" && comboBox3.Text == "")
            {
                lblerror.Text = "Select User You wanna Add";
                lblerror.Visible = true;
            }
            else if (comboBox2.Text != "" && comboBox3.Text != "")
            {
                lblerror.Text = "";
                lblerror.Visible = true;
            }

        }

        private void linkLabel26_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           FYPReport rt = new FYPReport();
            this.Hide();
            rt.Show();
        }

        private void linkLabel27_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DetailStudent st = new DetailStudent();
            st.Show();
        }

        private void linkLabel28_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DetailsOfGroup st = new DetailsOfGroup();
            st.Show();
        }

        private void linkLabel29_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewReports frm = new ViewReports();
            frm.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}

