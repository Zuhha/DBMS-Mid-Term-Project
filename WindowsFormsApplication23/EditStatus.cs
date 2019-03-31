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
    public partial class EditStatus : Form
    {
        
        public EditStatus()
        {
            InitializeComponent();
            panel2.Visible = false;
        }

        private void EditStatus_Load(object sender, EventArgs e)
        {
            string cmd = "Select FirstName+' '+LastName as Name,RegistrationNo,Status as u,GP.GroupId as GroupId,StudentId as StudentId, Title from Person join Student on Person.Id = Student.Id join GroupStudent on StudentId = Person.Id join GroupProject AS GP on  GP.GroupId = GroupStudent.GroupId join Project on Project.Id = GP.ProjectId";
            dbConnection.getInstance().fill(cmd, dataGridView1);
            labelerror.Visible = false;
            Group g = new Group();
            g.Addstatus(dataGridView1);
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                panel2.Visible = true;
                panel1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["StudentId"].Value);
          if (comboBox1.Text == "ACTIVE")
            {
                string oss = "Update GroupStudent SET Status = '" + 3 + "' where StudentId = '" + id + "'";
                dbConnection.getInstance().exectuteQuery(oss);
            }
            else if(comboBox1.Text == "INACTIVE")
            {
                string oss = "Update GroupStudent SET Status = '" + 4 + "' where StudentId = '" + id + "'";
                dbConnection.getInstance().exectuteQuery(oss);
            }
            else if(comboBox1.Text == "")
            {

                labelerror.Text = "Select Status Please";
                labelerror.Visible = true;
            }
            this.Hide();
            EditStatus ed = new EditStatus();
            ed.Show();

           
            
            
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Show();
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
            Person_Details frm = new Person_Details();
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

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GroupDetails frm = new GroupDetails();
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

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(comboBox1.Text =="")
            {
                labelerror.Text = "Select Status Please";
                labelerror.Visible = true;
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = "";
            label6.Visible = false;
            labelerror.Visible = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditStatus frm = new EditStatus();
            frm.Show();
        }
    }

}
