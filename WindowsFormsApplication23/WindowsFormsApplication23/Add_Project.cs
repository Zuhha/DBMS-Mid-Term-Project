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
    public partial class Add_Project : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";

        public Add_Project()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            if (txttittle.Text == "" || txtdesc.Text == "")
            {
                MessageBox.Show("Enter All Fields");
            }
            else if (st.Allchar(txttittle.Text) == false)
            {
                MessageBox.Show("Enter a valid Title");
            }
            else if (st.Allchar(txtdesc.Text) == false)
            {
                MessageBox.Show("Enter a valid Description");
            }
            else if (st.Allchar(txttittle.Text) == true && st.Allchar(txtdesc.Text) == true)
            {
                SqlConnection con = new SqlConnection(conURL);
                con.Open();
                string k = "Select Count(Id) from Project where Title ='" + txttittle.Text + "' ";

                SqlCommand cg = new SqlCommand(k, con);
                int yo = (int)cg.ExecuteScalar();
                bool ry = true;
                if (yo >= 1)
                {
                    ry = false;
                }
                if (ry == false)
                {
                    MessageBox.Show("Project with this tittle is already a part of our record :)");
                }
                else if (ry == true)
                {
                    string cmd = "Insert into Project(Description, Title) values ('" + txtdesc.Text + "','" + txttittle.Text + "')";
                    SqlCommand g = new SqlCommand(cmd, con);
                    g.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Project has been added");
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
