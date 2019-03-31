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
       
        Student st = new Student();

        public AllAdvisors()
        {
            InitializeComponent();
            
        }
        

        private void AllAdvisors_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            panel2.Visible = false;
            
             string s = "Select a.Id, p.Gender as g, p.FirstName,p.LastName,p.Contact,p.Email,a.Salary,a.Designation,p.DateOfBirth from Advisor as a join Person as p on p.Id = a.Id ";
          
            dbConnection.getInstance().fill(s, dataGridView1);

            Advisor ad = new Advisor();
            ad.fillgender(dataGridView1);

            string f = "Select Value from Lookup where Category = 'DESIGNATION'";
            ad.load(f,comboBox1);
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                panel2.Visible = true;
                tableLayoutPanel1.Visible = true;
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
                dbConnection.getInstance().exectuteQuery(s);
                dbConnection.getInstance().exectuteQuery(hu);

                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                MessageBox.Show("Removed Successfully");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
             if(comboBox1.Text == "")
            {
                lblerror.Text = "Select Designation";
                lblerror.Show();
            }
            if(lblsalary.Text == "" && lbllastname.Text == "" && lblerror.Text == "" && lblFirstname.Text == "" && lblemail.Text == "" && lbldob.Text == "" && lblcontact.Text == "" && lblgender.Text == "")
                try
                {
                    string k = "Select Count(Id) from  Person where FirstName ='" + txtfirstname.Text + "' and LastName = '" + txtlastname.Text + "' and Contact = '" + txtcontact.Text + "'and Id != '" + Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value) + "'";
                    Advisor ad = new Advisor();
                    bool ry = ad.uniqueperson(txtfirstname.Text, txtlastname.Text, txtcontact.Text, k);
                   if (ry == false)
                    {
                        lblerror.Text ="This Person has already been added in Record";
                        lblerror.Visible = true;
                    }
                    else if(ry == true)
                    {
                          int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                         int y = dbConnection.getInstance().getScalerData("Select Id from Lookup where Value = '" + comboBox1.Text + "'");
                        int yy = dbConnection.getInstance().getScalerData("Select Id from Lookup where Value = '" + comboBox2.Text + "'");
                       dbConnection.getInstance().exectuteQuery("Update Advisor SET Designation = '" + y + "', Salary = '" + txtsalary.Text + "'  where Id = '" + id + "' ");
                       dbConnection.getInstance().exectuteQuery("Update Person SET FirstName = '" + txtfirstname.Text + "', LastName = '" + txtlastname.Text + "',Contact = '" + txtcontact.Text + "',Email = '" + txtemail.Text + "',DateOfBirth = '" + dateTimePicker1.Value + "',Gender = '" + yy + "'  where Id = '" + id + "' ");
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

        private void txtFirstName_KeyUp_1(object sender, KeyEventArgs e)
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

        private void txtLastName_KeyUp_1(object sender, KeyEventArgs e)
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

        private void txtcontact_KeyUp_1(object sender, KeyEventArgs e)
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
            if (st.Emails(txtemail.Text) == false)
            {
                lblemail.Text = "Characters Only!!!";
                lblerror.Text = "";
            }
            else
            {
                lblemail.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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
                lblerror.Visible = true;
            }
            else
            {
                lblerror.Text = "";
            }
        }

        private void txtsalary_KeyUp_1(object sender, KeyEventArgs e)
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

        private void txtfirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtemail_KeyUp(object sender, KeyEventArgs e)
        {
            lblerror.Text = "";
            if (st.Emails(txtemail.Text) == false)
            {
                lblemail.Text = "Characters Only!!!";
                lblerror.Text = "";
            }
            else
            {
                lblemail.Text = "";
            }
        }

        private void txtcontact_KeyUp(object sender, KeyEventArgs e)
        {

        }

     
    }
}
