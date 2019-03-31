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
    public partial class AllProjects : Form
    {
        
        public AllProjects()
        {
            InitializeComponent();
            this.SuspendLayout();
           
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AllProjects";
            this.ResumeLayout(false);
            panel2.Visible = false;
        }

        private void AllProjects_Load(object sender, EventArgs e)
        {
            
            string s = "Select * from Project";
            dbConnection.getInstance().fill(s, dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                panel2.Visible = true;
                panel1.Visible = false;
                txttitle.Text = dataGridView1.CurrentRow.Cells["Title"].Value.ToString();
                txtdesc.Text = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();


            }
            else if (e.ColumnIndex == 1)
            {
                int u = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                string s = "Delete from ProjectAdvisor where ProjectId = '" + u + "'";
                string st = "Delete from GroupProject where ProjectId = '" + u + "'";
                string hu = "Delete from Project where Id = '" + u + "'";

                dbConnection.getInstance().exectuteQuery(s);
                dbConnection.getInstance().exectuteQuery(st);
                dbConnection.getInstance().exectuteQuery(hu);

                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                MessageBox.Show("Removed Successfully");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void Update_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            if (txttitle.Text == "" || txtdesc.Text == "")
            {
                MessageBox.Show("Enter All Fields");
            }
            else if (st.Allchar(txttitle.Text) == false)
            {
                MessageBox.Show("Enter a valid Title");
            }
            else if (st.Allchar(txtdesc.Text) == false)
            {
                MessageBox.Show("Enter a valid Description");
            }
            else if (st.Allchar(txttitle.Text) == true && st.Allchar(txtdesc.Text) == true)
            {
                
                string k = "Select Count(Id) from Project where Title ='" + txttitle.Text + "' and Id != '"+dataGridView1.CurrentRow.Cells["Id"].Value+"' ";

                Project P = new Project();
                bool ry = P.uniqueproject(k); 
                
                if (ry == false)
                {
                    MessageBox.Show("Project with this tittle is already a part of our record :)");
                }
                else if (ry == true)
                {

                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                    string s = "Update Project SET Description = '" + txtdesc.Text + "', Title = '" + txttitle.Text + "'  where Id = '" + id + "' ";
                    dbConnection.getInstance().exectuteQuery(s);
                    MessageBox.Show("Updated");
                    this.Hide();
                    AllProjects frm = new AllProjects();
                    frm.Show();

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

        private void groupBox1_Enter(object sender, EventArgs e)
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

       

        private void AllProjects_Load_1(object sender, EventArgs e)
        {

        }

       

        private void AllProjects_Load_2(object sender, EventArgs e)
        {

        }
    }
}
