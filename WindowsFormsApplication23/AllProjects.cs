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
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public AllProjects()
        {
            InitializeComponent();
            panel2.Visible = false;
        }

        private void AllProjects_Load(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(conURL);
            string s = "Select * from Project";

            SqlDataAdapter ad = new SqlDataAdapter(s, c);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            dataGridView1.DataSource = dt;
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

                SqlConnection op = new SqlConnection(conURL);
                op.Open();
                SqlCommand cmd = new SqlCommand(s, op);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand(st, op);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand(hu, op);
                cmd2.ExecuteNonQuery();
                op.Close();
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
                SqlConnection con = new SqlConnection(conURL);
                con.Open();
                string k = "Select Count(Id) from Project where Title ='" + txttitle.Text + "' and Id != '"+dataGridView1.CurrentRow.Cells["Id"].Value+"' ";

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

                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                    string s = "Update Project SET Description = '" + txtdesc.Text + "', Title = '" + txttitle.Text + "'  where Id = '" + id + "' ";
                    SqlConnection c = new SqlConnection(conURL);
                    c.Open();
                    SqlCommand q = new SqlCommand(s, c);
                    q.ExecuteNonQuery();
                    c.Close();
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
    }
}
