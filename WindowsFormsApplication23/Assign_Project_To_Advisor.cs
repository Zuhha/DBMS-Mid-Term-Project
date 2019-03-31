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
        Student st = new Student();
        public Assign_Project_To_Advisor()
        {
            InitializeComponent();
        }

        private void Assign_Project_To_Advisor_Load(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(conURL);
            c.Open();
            label4.Visible = false;
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


            if (comboBox1.Text != "")
            {
                lbladvisor.Text = "";

            }
            else if(comboBox1.Text == "")
            {
                lbladvisor.Text = "Please SElect the Advisor";
                lbladvisor.Visible = true;
            }
            if (comboBox2.Text != "")
            {
                lbltitle.Text = "";
            }
            else if(comboBox2.Text == "")
            {
                lbltitle.Text = "Select the Title";
            }
            if (comboBox3.Text != "")
            {
                lblrole.Text = "";

            }
            else if(comboBox3.Text == "")
            {
                lblrole.Text = "Select the Role of Advisor";
            }
         
             if(lbladvisor.Text == "" && lblrole.Text == "" && lbltitle.Text == "")
            {

                string cmnd = "Select Id from Project where Title = '" + comboBox2.Text + "'";
                SqlCommand k = new SqlCommand(cmnd, con);
                int id = (int)k.ExecuteScalar();

                string b = "Select Id from Lookup where Value = '" + comboBox3.Text + "'";
                SqlCommand cgh = new SqlCommand(b, con);
                int o = (int)cgh.ExecuteScalar();


                string kon = "Select Count(ProjectId) from ProjectAdvisor where ProjectId ='" + id + "' and AdvisorRole = '" + o + "'  ";
                SqlCommand cg = new SqlCommand(kon, con);
                int yo = (int)cg.ExecuteScalar();


                string query = "Select Count(AdvisorId) from ProjectAdvisor where ProjectId = '" + id + "' and AdvisorId = '" + Convert.ToInt32(comboBox1.Text) + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int count = (int)cmd.ExecuteScalar();
                bool check = true;
                bool c = true;
                if (yo >= 1)
                {
                    label4.Text = "'" + comboBox3.Text + "' is already assissigned to this project. If you wanna change then please visit update form. Thanks !";
                    label4.Visible = true;
                    check = false;

                }
                if(count >= 1)
                {
                    label4.Text = "This Advisor is already serving project '" + comboBox2.Text + "'";
                    label4.Visible = true;
                    c = false;
                }


            else if(check == true && c == true)
            {
                try
                {

                   

                    string h = "Insert into ProjectAdvisor(AdvisorId, ProjectId,AdvisorRole,AssignmentDate) values ('" + comboBox1.Text + "', '" + id + "','" + o + "','" + DateTime.Now + "')";
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

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void comboBox2_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void comboBox3_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {

            
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text != "")
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
                lbltitle.Visible = false;
                label4.Visible = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewReports frm = new ViewReports();
            this.Hide();
            frm.Show();
        }
    }
}
