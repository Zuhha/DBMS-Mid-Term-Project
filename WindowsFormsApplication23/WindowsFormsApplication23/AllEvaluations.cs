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
    public partial class AllEvaluations : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public AllEvaluations()
        {
            InitializeComponent();
        }

        private void AllEvaluations_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection c = new SqlConnection(conURL);
            string cmd8 = "Select e.Id,e.TotalMarks,e.Name,e.TotalWeightage,g.ObtainedMarks from Evaluation as e join GroupEvaluation as g on e.Id = g.EvaluationId";
            SqlDataAdapter ad = new SqlDataAdapter(cmd8, c);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            dataGridView1.DataSource = dt;
            txtname.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txttotalmarks.Text = dataGridView1.CurrentRow.Cells["TotalMarks"].Value.ToString();
            txttotalwieghtage.Text = dataGridView1.CurrentRow.Cells["TotalWeightage"].Value.ToString();
            txtobtainrd.Text = dataGridView1.CurrentRow.Cells["ObtainedMarks"].Value.ToString();







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
                string o = dataGridView1.CurrentRow.Cells["Id"].FormattedValue.ToString();
                int u = Convert.ToInt32(o);

                string s = "Delete from GroupEvaluation where EvaluationId = '" + u + "'";
                string ss = "Delete from Evaluation where Id = '" + u + "'";


                SqlConnection op = new SqlConnection(conURL);
                op.Open();

                SqlCommand cmd1 = new SqlCommand(s, op);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand(ss, op);
                cmd2.ExecuteNonQuery();

                op.Close();
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                MessageBox.Show("Deleted");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Student st = new Student();
            if (txtname.Text == "" || txttotalmarks.Text == "" || txttotalwieghtage.Text == "" || txtobtainrd.Text == "")
            {
                MessageBox.Show("All Fields Are required");
            }
            else if (st.Allchar(txtname.Text) == false)
            {
                MessageBox.Show("Please Enter Valid Name");
            }
            else if (Convert.ToInt32(txttotalmarks.Text) < Convert.ToInt32(txtobtainrd.Text))
            {
                MessageBox.Show("Enter Correct Obtained Marks");
            }
            else if (st.Alldigits(txttotalmarks.Text) == false)
            {
                MessageBox.Show("Please Enter Valid Total Marks");
            }

            else if (st.Alldigits(txttotalwieghtage.Text) == false)
            {
                MessageBox.Show("Please Enter Valid Wieghtage");
            }
            else if (st.Allchar(txtname.Text) == true && st.Alldigits(txttotalmarks.Text) && st.Alldigits(txttotalwieghtage.Text) && Convert.ToInt32(txttotalmarks.Text) >= Convert.ToInt32(txtobtainrd.Text))
            {


                string os = "Update Evaluation SET Name = '" + txtname.Text + "', TotalMarks = '" + Convert.ToInt32(txttotalmarks.Text) + "',TotalWeightage = '" + Convert.ToInt32(txttotalwieghtage.Text) + "' where Id = '" + dataGridView1.CurrentRow.Cells["Id"].Value + "'";
                string oss = "Update GroupEvaluation SET ObtainedMarks = '" + txtobtainrd.Text + "' where EvaluationId = '" + dataGridView1.CurrentRow.Cells["Id"].Value + "'";
                SqlConnection conU = new SqlConnection(conURL);
                conU.Open();
                SqlCommand go = new SqlCommand(os, conU);
                go.ExecuteNonQuery();
                SqlCommand goo = new SqlCommand(oss, conU);
                goo.ExecuteNonQuery();
                conU.Close();
                MessageBox.Show("Updated");
                this.Hide();
                AllEvaluations frm = new AllEvaluations();
                frm.Show();

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
