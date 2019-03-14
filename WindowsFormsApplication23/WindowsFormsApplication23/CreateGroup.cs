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
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public CreateGroup()
        {
            InitializeComponent();
            comboBox1.Visible = false;
            string cmd4 = "Select Title from Project where Id not in (Select ProjectId from GroupProject) ";
            SqlConnection op = new SqlConnection(conURL);
            op.Open();
            SqlCommand er = new SqlCommand(cmd4, op);
            SqlDataReader rd = er.ExecuteReader();
            while (rd.Read())
            {
                string s = rd["Title"].ToString();
                comboBox1.Items.Add(s);
            }
            op.Close();
        }

        private void CreateGroup_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            string cmd = "Select RegistrationNo,Id from Student where Id in (Select Id from Student except Select StudentId from GroupStudent);";
            SqlConnection q = new SqlConnection(conURL);
            q.Open();
           
            SqlDataAdapter ad = new SqlDataAdapter(cmd,q);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {

                if(Convert.ToBoolean(row.Cells["ADD"].Value) == true)

                {
                     string Reg = row.Cells["RegistrationNo"].Value.ToString();
                     string cmd = "Select Id from Student where RegistrationNo ='" + Reg + "'";
                    
                     SqlConnection op = new SqlConnection(conURL);
                     op.Open();
                     SqlCommand g = new SqlCommand(cmd, op);
                    
                   
                    int q = (int)g.ExecuteScalar();
                   
                    
                    
                     string cmd2 = "Insert into [Group] (Created_On) Values ('"+DateTime.Now.Date+"')";
                     SqlCommand g1 = new SqlCommand(cmd2, op);
                     g1.ExecuteNonQuery();
                     string cmd3 = "Select max(Id) from [Group]";
                     SqlCommand rt = new SqlCommand(cmd3, op);
                     int gh = (int)rt.ExecuteScalar();
                   
                     string final = "Insert into GroupStudent (GroupId, StudentId,Status,AssignmentDate) values ('" + gh + "','" + q + "','" + 4 + "','" + DateTime.Now.Date + "')";
                     SqlCommand g2 = new SqlCommand(final, op);
                     g2.ExecuteNonQuery();

                    string cmdt = "Select Id from Project where Title = '" + comboBox1.Text + "'";
                    SqlCommand bn = new SqlCommand(cmdt, op);
                    int yu = (int)bn.ExecuteScalar();

                    string vb = "Insert into GroupProject (ProjectId,GroupId,AssignmentDate) values ('" + yu + "','" + gh + "','" + DateTime.Now + "')";
                    SqlCommand kl = new SqlCommand(vb, op);
                    kl.ExecuteNonQuery();
                    MessageBox.Show("Group has been Created");
                   
                   
                }
                   
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Visible = true;
            label1.Visible = true;
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
