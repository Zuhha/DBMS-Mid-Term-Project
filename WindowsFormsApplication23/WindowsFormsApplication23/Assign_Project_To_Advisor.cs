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
    public partial class Assign_Project_To_Advisor : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public Assign_Project_To_Advisor()
        {
            InitializeComponent();
        }

        private void Assign_Project_To_Advisor_Load(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(conURL);
            c.Open();
            string query = "Select Id from Advisor";
            SqlCommand q = new SqlCommand(query, c);
            SqlDataReader rdr = q.ExecuteReader();
            while (rdr.Read())
            {
                string id = rdr[0].ToString();
                comboBox1.Items.Add(id);
            }
            rdr.Close();
            string cmd = "Select Title from Project";
            SqlCommand f = new SqlCommand(cmd, c);

            SqlDataReader r = f.ExecuteReader();
            while (r.Read())
            {
                string title = r["Title"].ToString();
                comboBox2.Items.Add(title);
            }
            r.Close();
            string h = "Select Value from Lookup where Category = 'ADVISOR_ROLE'";
            SqlCommand g = new SqlCommand(h, c);
            SqlDataReader t = g.ExecuteReader();
            while (t.Read())
            {
                string em = t["Value"].ToString();
                comboBox3.Items.Add(em);
            }


            t.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conURL);
            con.Open();
            //One Advisor can not play two responsibilities in same group

            string cmnd = "Select Id from Project where Title = '" + comboBox2.Text + "'";
            SqlCommand k = new SqlCommand(cmnd, con);
            int id = (int)k.ExecuteScalar();


            string str = "Select Count(AdvisorId) from ProjectAdvisor where ProjectId = '" + id + "' and AdvisorId ='" + Convert.ToInt32(comboBox1.Text) + "'";
            SqlCommand bk = new SqlCommand(str, con);
            int count = (int)bk.ExecuteScalar();
            bool f = true;
            if (count >= 1)
            {
                f = false;
            }






            string b = "Select Id from Lookup where Value = '" + comboBox3.Text + "'";
            SqlCommand cgh = new SqlCommand(b, con);
            int o = (int)cgh.ExecuteScalar();


            string kon = "Select Count(ProjectId) from ProjectAdvisor where AdvisorId ='" + comboBox1.Text + "' and AdvisorRole = '" + o + "' ";
            SqlCommand cg = new SqlCommand(kon, con);
            int yo = (int)cg.ExecuteScalar();

            bool ry = true;
            if (yo >= 1)
            {
                ry = false;
            }

            //Repeatation Of REcord
            string on = "Select Title from Project where Id = (Select ProjectId from ProjectAdvisor where AdvisorId ='" + comboBox1.Text + "' and AdvisorRole = '" + o + "' )";
            SqlCommand yh = new SqlCommand(on, con);
            SqlDataReader rdr = yh.ExecuteReader();
            string p = "";
            while (rdr.Read())
            {
                p = rdr["Title"].ToString();
            }
            rdr.Close();

            if (ry == false)
            {
                MessageBox.Show("We are Sorry This Advisor has already been assigned as " + comboBox3.Text + " to " + p);
            }
            else if (f == false)
            {
                MessageBox.Show("This Advisor is already serving project " + comboBox2.Text);
            }
            else if (ry == true)
            {
                try
                {

                    string cmn = "Select Id from Lookup where Value = '" + comboBox3.Text + "'";
                    SqlCommand ko = new SqlCommand(cmn, con);
                    int ide = (int)ko.ExecuteScalar();

                    string h = "Insert into ProjectAdvisor(AdvisorId, ProjectId,AdvisorRole,AssignmentDate) values ('" + comboBox1.Text + "', '" + id + "','" + ide + "','" + DateTime.Now + "')";
                    SqlCommand g = new SqlCommand(h, con);
                    g.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Done!!");
                }
                catch (Exception et)
                {
                    throw (et);
                }

            }




        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Evaluation frm = new Evaluation();
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
    }
}
