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
    public partial class CreateGroup : Form
    {
      
        public CreateGroup()
        {
            InitializeComponent();
            
           
            
        }

        private void CreateGroup_Load(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            label1.Visible = true;
            comboBox1.Visible = true;

            string cmd4 = "Select Title from Project where Id not in (Select ProjectId from GroupProject) ";
            Person p = new Person();
            p.load(cmd4, comboBox1);
            labelerror.Visible = false;
            lblerror.Visible = false;
            button3.Visible = false;
            Group g = new Group();
            g.exists(comboBox1, label1, dataGridView1);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Group g = new Group();
            bool iss = g.checkboxchech(dataGridView1);
            int count = g.NoOfSt(dataGridView1);
            if (iss == true && comboBox1.Text != "" && count <= 4)
            {
                List<int> indexess = new List<int>();
               
                string cmd2 = "Insert into [Group] (Created_On) Values ('" + DateTime.Now.Date + "')";
                dbConnection.getInstance().exectuteQuery(cmd2);
                string cmd3 = "Select max(Id) from [Group]";

                int gh = dbConnection.getInstance().getScalerData(cmd3);



                string cmdt = "Select Id from Project where Title = '" + comboBox1.Text + "'";
               
                int yu = dbConnection.getInstance().getScalerData(cmdt);


                string vb = "Insert into GroupProject (ProjectId,GroupId,AssignmentDate) values ('" + yu + "','" + gh + "','" + DateTime.Now + "')";
                dbConnection.getInstance().exectuteQuery(vb);
                //List of those row indexes having add checkbox checked
                List<int> indexes = g.ListOfindexes(indexess, dataGridView1);
                foreach (int i in indexes)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)

                    {
                        if (row.Index == i)
                        {

                            string Reg = row.Cells["RegistrationNo"].Value.ToString();
                            string cmd = "Select Id from Student where RegistrationNo ='" + Reg + "'";

                            int q = dbConnection.getInstance().getScalerData(cmd);

                            string s = "Select Id from Lookup where Category = 'STATUS' and Value = 'InActive'";
                           
                           
                            int qo = dbConnection.getInstance().getScalerData(s);

                            string final = "Insert into GroupStudent (GroupId, StudentId,Status,AssignmentDate) values ('" + gh + "','" + q + "','" + qo + "','" + DateTime.Now.Date + "')";
                            dbConnection.getInstance().exectuteQuery(final);


                        }



                    }

                }
                MessageBox.Show("Group has been Created");
                this.Hide();
                CreateGroup gm = new CreateGroup();
                gm.Show();
            }
            else if (count > 4)
            {
                labelerror.Text = "Only 4 students are allowed in a group";
                labelerror.Visible = true;
            }
            else if(comboBox1.Text == "")
            {
                lblerror.Text = "Please Select a Title";
                lblerror.Visible = true;
            }
            else if(iss == false)
            {
                lblerror.Text = "Select Student First";
                lblerror.Visible = true;

            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            labelerror.Text = "";
            lblerror.Text = "";
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

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button1.Visible = false;
            comboBox2.Visible = true;
            comboBox1.Visible = false;
            comboBox1.Text = "";
            string cmd = "Select Title from Project where Id in (Select ProjectId from GroupProject where GroupId in (select GroupId from GroupStudent group by GroupId having count(GroupId) < 4 ) except select Id from Project where Title = '" + comboBox1.Text + "')";
            Person p = new Person();
            p.load(cmd, comboBox2);
            button1.Visible = false;
            button2.Visible = false;
            comboBox1.Visible = false;
            label1.Text = "Select Project";
            label1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Group g = new Group();
            g.Addstudentinexistinggroup(comboBox2, dataGridView1, labelerror, lblerror);
        
            }

        private void label2_Click(object sender, EventArgs e)
        {
            ViewReports frm = new ViewReports();
            this.Hide();
            frm.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblerror.Text = "";
            labelerror.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblerror.Text = "";
            labelerror.Text = "";
        }
    }
   
}
