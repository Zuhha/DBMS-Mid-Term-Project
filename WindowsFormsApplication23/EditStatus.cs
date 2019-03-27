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
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public EditStatus()
        {
            InitializeComponent();
            panel2.Visible = false;
        }

        private void EditStatus_Load(object sender, EventArgs e)
        {
            string cmd = "Select FirstName+' '+LastName as Name,RegistrationNo,Status,GroupId,StudentId from Person join Student on Person.Id = Student.Id join GroupStudent on StudentId = Person.Id ";
            SqlConnection con = new SqlConnection(conURL);
            con.Open();
            SqlDataAdapter ada = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            dataGridView1.DataSource = dt;
            labelerror.Visible = false;

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
            SqlConnection conU = new SqlConnection(conURL);
            conU.Open();
            if (comboBox1.Text == "ACTIVE")
            {
                string oss = "Update GroupStudent SET Status = '" + 3 + "' where StudentId = '" + id + "'";
                SqlCommand go = new SqlCommand(oss, conU);
                go.ExecuteNonQuery();
            }
            else if(comboBox1.Text == "INACTIVE")
            {
                string oss = "Update GroupStudent SET Status = '" + 4 + "' where StudentId = '" + id + "'";
                SqlCommand go = new SqlCommand(oss, conU);
                go.ExecuteNonQuery();
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
    }

}
