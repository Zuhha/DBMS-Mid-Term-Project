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
    public partial class Add_Advisor : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";

        public Add_Advisor()
        {
            InitializeComponent();
            SqlConnection c = new SqlConnection(conURL);
            c.Open();
            string cmd = "Select Value from Lookup where Category = 'DESIGNATION' Order by Value";
            SqlCommand q = new SqlCommand(cmd, c);
            SqlDataReader rdr = q.ExecuteReader();

            while (rdr.Read())
            {
                string h = rdr[0].ToString();
                comboBox1.Items.Add(h);
            }
            c.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();

            if (st.Alldigits(txtsalary.Text) == false)
            {
                MessageBox.Show("Enter Valid Salary");
            }
            else if (st.Alldigits(txtid.Text) == false)
            {
                MessageBox.Show("Enter Valid ID(of type int)");
            }
            else if(st.Alldigits(txtsalary.Text) == true  && st.Alldigits(txtid.Text) == true)
            {
                SqlConnection c = new SqlConnection(conURL);
                c.Open();
                string k = "Select Count(Id) from Advisor where Id  ='" +Convert.ToInt32( txtid.Text) + "' ";
                SqlCommand cg = new SqlCommand(k, c);
                int yo = (int)cg.ExecuteScalar();
                bool ry = true;
                if (yo >= 1)
                {
                    ry = false;
                }
                if (ry == false)
                {
                    MessageBox.Show("This ID has already been added in Record");
                }
                else if(ry == true)
                {
                    try
                    {
                        string cmd = "Select Id from Lookup where Value = '" + comboBox1.Text + "'";
                        SqlCommand q = new SqlCommand(cmd, c);
                        int y = (int)q.ExecuteScalar();
                        string x = "Insert into Advisor(Id, Designation, Salary) values ('" + txtid.Text + "','" + y + "','" + txtsalary.Text + "')";
                        SqlCommand u = new SqlCommand(x, c);
                        u.ExecuteNonQuery();
                        c.Close();


                        MessageBox.Show("Inserted");
                    }
                    catch(Exception ec)
                    {
                        throw (ec);
                    }

                }
            }




           
            

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Group_Details frm = new Group_Details();
            frm.Show();
            this.Hide();
        }
    }
}
