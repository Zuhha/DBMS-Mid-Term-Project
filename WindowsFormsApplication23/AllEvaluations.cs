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
        Student st = new Student();
        public AllEvaluations()
        {
            InitializeComponent();
        }

        private void AllEvaluations_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
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
            txtobtained.Text = dataGridView1.CurrentRow.Cells["ObtainedMarks"].Value.ToString();







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


           if (lblname.Text == "" && lblobtained.Text == ""&& lbltotalmarks.Text == "" && lbltotalwieghtage.Text == "" )
            {


                string os = "Update Evaluation SET Name = '" + txtname.Text + "', TotalMarks = '" + Convert.ToInt32(txttotalmarks.Text) + "',TotalWeightage = '" + Convert.ToInt32(txttotalwieghtage.Text) + "' where Id = '" + dataGridView1.CurrentRow.Cells["Id"].Value + "'";
                string oss = "Update GroupEvaluation SET ObtainedMarks = '" + txtobtained.Text + "' where EvaluationId = '" + dataGridView1.CurrentRow.Cells["Id"].Value + "'";
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
           else
            {
                lblerror.Text = "Enter Correct Data";
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
            if (st.Alldigits(txttotalmarks.Text) == true)
            {
                lbltotalmarks.Text = "";
                lbltotalmarks.Visible = false;
            }
            else
            {
                lbltotalmarks.Text = "Digits Only !!";
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

        private void txtobtainrd_KeyUp(object sender, KeyEventArgs e)
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

        private void lbltotalwieghtage_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllEvaluations frm = new AllEvaluations();
            frm.Show();

        }
    }
}
