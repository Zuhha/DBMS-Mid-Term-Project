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
    public partial class GroupDetails : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public GroupDetails()
            
        {
           
            InitializeComponent();
        }

        private void GroupDetails_Load(object sender, EventArgs e)
        {
            
            string cmd8 = "Select GroupProject.GroupId,GroupProject.ProjectId, Title,StudentId, RegistrationNo,AdvisorId,Value as [Advisor Role],(Select Value from [Lookup] where Id = [Status])as [Status] from GroupStudent join Student on GroupStudent.StudentId = StudentId join GroupProject on GroupProject.GroupId = GroupStudent.GroupId join Project on Project.Id = GroupProject.ProjectId join ProjectAdvisor on ProjectAdvisor.ProjectId = GroupProject.ProjectId join [Lookup] on [Lookup].Id = AdvisorRole";
            dbConnection.getInstance().fill(cmd8, dataGridView1);
            string s = "Select GroupId as GroupId, Title as [Project Assigned] from [Group] join GroupProject on GroupProject.GroupId = [Group].Id join Project on Project.Id = GroupProject.ProjectId";
            dbConnection.getInstance().fill(s, dataGridView2);
            panel1.Visible = false;

            string d = "Select RegistrationNo,StudentId, FirstName+' '+LastName as Name,GroupProject.GroupId,Title as Project from Student join PERSON ON PERSON.ID = Student.Id JOIN GroupStudent on StudentId= Student.Id join GroupProject on GroupProject.GroupId = GroupStudent.GroupId join Project on Project.Id = GroupProject.ProjectId";
            dbConnection.getInstance().fill(d, dataGridView3);
            dataGridView3.Visible = false;





        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person_Details frm = new Person_Details();
            this.Hide();
            frm.Show();
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

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditStatus frm = new EditStatus();
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells["GroupId"].Value);
            string s = "Delete from GroupStudent where GroupId = '"+id+"'" ;
            string so = "Delete from GroupProject where GroupId = '" + id + "'";
            string soo = "Delete from GroupEvaluation where GroupId = '" + id + "'";
            string sooo = "Delete from [Group] where Id = '" + id + "'";
            dbConnection.getInstance().exectuteQuery(s);
            dbConnection.getInstance().exectuteQuery(so);
            dbConnection.getInstance().exectuteQuery(soo);
            dbConnection.getInstance().exectuteQuery(sooo);
            MessageBox.Show("Deleted");
            dataGridView2.Rows.Remove(dataGridView2.Rows[e.RowIndex]);



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
            dataGridView1.Visible = false;
            button2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = false;
            dataGridView3.Visible = true;
            button1.Visible = false;


        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                int id = Convert.ToInt32(dataGridView3.CurrentRow.Cells["StudentId"].Value);
                string s = "Delete from GroupStudent where StudentId = '" + id + "'";
                dbConnection.getInstance().exectuteQuery(s);
                MessageBox.Show("Deleted");
                dataGridView3.Rows.Remove(dataGridView3.Rows[e.RowIndex]);
            }
            
        }
    }
}
