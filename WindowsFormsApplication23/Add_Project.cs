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
        
        Student st = new Student();

        public Add_Project()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
               if(lbltitle.Text == "" && lbldesc.Text == "")
                {
                   
                    string cmd = "Insert into Project(Description, Title) values ('" + txtdesc.Text + "','" + txttittle.Text + "')";
                    dbConnection.getInstance().exectuteQuery(cmd);
                    MessageBox.Show("Project has been added");
                }
               else
            {
                lblerror.Text = "Enter Correct Information";
                lblerror.Visible = true;
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

        private void txttittle_KeyUp(object sender, KeyEventArgs e)
        {
            lbltitle.Visible = false;

           




            if (st.Allchar(txttittle.Text) == true)
            {
                
                string k = "Select Count(Id) from Project where Title ='" + txttittle.Text + "' ";

                Project p = new Project();
                bool ry = p.uniqueproject(k);
               
                if (ry == false)
                {
                   
                    lbltitle.Text = "This Project is already a part of our record";
                    lbltitle.Visible = true;
                }
                else
                {
                    lbltitle.Text = "";
                }
               
            }
            else
            {
                lbltitle.Text = "Characters Only!!";
                lbltitle.Visible = true;
            }
        }

        private void txtdesc_KeyUp(object sender, KeyEventArgs e)
        {
            lbldesc.Visible = false;
            if(st.Allchar(txtdesc.Text) == true)
            {
                lbldesc.Text = "";
            }
            else
            {
                lbldesc.Text = "Characters only!!";
                lbldesc.Visible = true;
            }
        }

        private void Add_Project_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
        }

        private void txtdesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbldesc_Click(object sender, EventArgs e)
        {

        }

        private void txttittle_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewReports frm = new ViewReports();
            this.Hide();
            frm.Show();
        }
    }
}
