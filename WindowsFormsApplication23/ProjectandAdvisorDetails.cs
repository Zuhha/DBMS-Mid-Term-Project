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
    public partial class ProjectandAdvisorDetails : Form
    {
        public ProjectandAdvisorDetails()
        {
            InitializeComponent();
        }

        private void ProjectandAdvisorDetails_Load(object sender, EventArgs e)
        {
           
           
            panel2.Visible = false;
            label4.Visible = false;

            string query = "Select Id from Advisor";
            Person p = new Person();
            p.load(query, comboBox1);

            string cmd = "Select Title from Project";
            p.load(cmd, comboBox2);
            string h = "Select Value from Lookup where Category = 'ADVISOR_ROLE'";
            p.load(h, comboBox3);

            string cmd8 = "select AdvisorId,FirstName+' '+LastName as Name ,ProjectId,(Select value from [Lookup] where Id = AdvisorRole) as AdvisorRole , Title, AssignmentDate from ProjectAdvisor join Project on ProjectAdvisor.ProjectId = Project.Id join Person on ProjectAdvisor.AdvisorId = Person.Id order by Title ";

            dbConnection.getInstance().fill(cmd8, dataGridView1);

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }

            else if (e.ColumnIndex == 1)
            {
                string o = dataGridView1.CurrentRow.Cells["ProjectId"].FormattedValue.ToString();
                int u = Convert.ToInt32(o);


                int uu = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AdvisorId"].FormattedValue.ToString());

                string s = "Delete from ProjectAdvisor where ProjectId = '" + u + "'and AdvisorId = '" + uu + "'";

                dbConnection.getInstance().exectuteQuery(s);
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                MessageBox.Show("Deleted");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



            if (comboBox1.Text != "")
            {
                lbladvisor.Text = "";

            }
            else if (comboBox1.Text == "")
            {
                lbladvisor.Text = "Please SElect the Advisor";
                lbladvisor.Visible = true;
            }
            if (comboBox2.Text != "")
            {
                lbltitle.Text = "";
            }
            else if (comboBox2.Text == "")
            {
                lbltitle.Text = "Select the Title";
            }
            if (comboBox3.Text != "")
            {
                lblrole.Text = "";

            }
            else if (comboBox3.Text == "")
            {
                lblrole.Text = "Select the Role of Advisor";
            }
            if (dateTimePicker1.Value > DateTime.Now)
            {
                label4.Text = "Enter correct Assignment Date";
                label4.Visible = true;
            }
            else if (dateTimePicker1.Value <= DateTime.Now)
            {
                label4.Text = "";
            }

            if (lbladvisor.Text == "" && lblrole.Text == "" && lbltitle.Text == "" && label4.Text == "")
            {

                string cmnd = "Select Id from Project where Title = '" + comboBox2.Text + "'";

                int id = dbConnection.getInstance().getScalerData(cmnd);

                string b = "Select Id from Lookup where Value = '" + comboBox3.Text + "'";

                int o = dbConnection.getInstance().getScalerData(b);




                string query = "Select Count(AdvisorId) from ProjectAdvisor where ProjectId = '" + id + "' and AdvisorId = '" + Convert.ToInt32(comboBox1.Text) + "'";

                int count = dbConnection.getInstance().getScalerData(query);

                bool c = true;

                if (count >= 1)
                {
                    label4.Text = "This Advisor is already serving project '" + comboBox2.Text + "'";
                    label4.Visible = true;
                    c = false;
                }


                else if (c == true)
                {

                    try
                    {
                        string s = "Select Id from Lookup where Value = '" + comboBox3.Text + "'";


                        int i = dbConnection.getInstance().getScalerData(s);



                        string os = "Update ProjectAdvisor SET ProjectId = '" + id + "', AdvisorId = '" + Convert.ToInt32(comboBox1.Text) + "',AdvisorRole = '" + i + "',AssignmentDate = '" + dateTimePicker1.Value + "' where ProjectId = '" + dataGridView1.CurrentRow.Cells["ProjectId"].Value + "'and AdvisorId = '" + dataGridView1.CurrentRow.Cells["AdvisorId"].Value + "'";
                        dbConnection.getInstance().exectuteQuery(os);
                        MessageBox.Show("Updated");
                        this.Hide();
                        ProjectandAdvisorDetails frm = new ProjectandAdvisorDetails();
                        frm.Show();
                    }
                    catch (Exception et)
                    {
                        throw (et);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                lbladvisor.Visible = false;
                label4.Visible = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                lbltitle.Visible = false;
                label4.Visible = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                lblrole.Visible = false;
                label4.Visible = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProjectandAdvisorDetails frm = new ProjectandAdvisorDetails();
            frm.Show();
        }
     
    }
}