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
    public partial class Evaluation : Form
    {
        Evaluations st = new Evaluations();
        public Evaluation()
        {
            InitializeComponent();
        }

        private void Evaluation_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
           
            string cmd = "Select Id from [Group]";
            
            st.load(cmd, comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (lblname.Text == "" && lblobtained.Text == "" && lbltotalmarks.Text == "" && lblgroupid.Text == "" && lbltotalwieghtage.Text == "")
            {
                bool c = st.uniqueevaluation(txtname, comboBox1);
                if (c == false)
                {
                    MessageBox.Show("This Group has already been evaluated for this evaluation");
                }
                else if (c == true)
                {
                    string cmd = "Insert into Evaluation (Name, TotalMarks,TotalWeightage) values ('" + txtname.Text + "','" + txttotalmarks.Text + "','" + txttotalwieghtage.Text + "')";
                    dbConnection.getInstance().exectuteQuery(cmd);



                    int id = st.maxid();
                    string cmd1 = "Insert into GroupEvaluation (GroupId, EvaluationId, ObtainedMarks, EvaluationDate) values ('" + comboBox1.Text + "','" + id + "','" + txtobtained.Text + "','" + DateTime.Now + "') ";
                    dbConnection.getInstance().exectuteQuery(cmd1);

                    MessageBox.Show("Evaluation Has been marked");
                }


            }


            else
            {
                lblerror.Text = "Enter Valid Entries !!!";
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

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void comboBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            
           
            

        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtname_KeyUp(object sender, KeyEventArgs e)
        {
            if (st.Allchar(txtname.Text) == true)
            {
                lblname.Visible = false;
                lblname.Text = "";
            }
            else
            {
                lblname.Visible = true;
                lblname.Text = "Characters only !!!";
            }
        }

        private void txttotalmarks_KeyUp(object sender, KeyEventArgs e)
        {
            if(st.Alldigits(txttotalmarks.Text) == true)
            {
                lbltotalmarks.Text = "";
                lbltotalmarks.Visible = false;
            }
            else
            {
                lbltotalmarks.Text = "Digits Only !!";
            }
           
        }

        private void txtobtained_KeyUp(object sender, KeyEventArgs e)
        {
            if (st.Alldigits(txtobtained.Text) == true)
            {
                lblobtained.Text = "";
                lblobtained.Visible = false;
                if (Convert.ToInt32(txtobtained.Text) > Convert.ToInt32(txttotalmarks.Text))
                {
                    lblobtained.Text = "Enter Valid Marks";
                    lblobtained.Visible = true;
                }
            }
            else
            {
                lblobtained.Text = "Digits Only !!";
            }
           
        }

        private void txttotalwieghtage_KeyUp(object sender, KeyEventArgs e)
        {
            if (st.Alldigits(txttotalwieghtage.Text) == true)
            {
                lbltotalwieghtage.Text = "";
                lbltotalwieghtage.Visible = false;
            }
            else
            {
                lbltotalwieghtage.Text = "Digits Only !!";
            }

        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = "";
            if(comboBox1.Text != "")
            {
                lblgroupid.Visible = false;
                lblgroupid.Text = "";
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            ViewReports frm = new ViewReports();
            this.Hide();
            frm.Show();
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            label6.Text = "";
        }

        private void txttotalmarks_TextChanged(object sender, EventArgs e)
        {
            label6.Text = "";
        }

        private void txtobtained_TextChanged(object sender, EventArgs e)
        {
            label6.Text = "";
        }

        private void txttotalwieghtage_TextChanged(object sender, EventArgs e)
        {
            label6.Text = "";
        }
    }
}
