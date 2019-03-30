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
            comboBox2.Visible = false;
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
            labelerror.Visible = false;
            lblerror.Visible = false;
            button3.Visible = false;

            int count = 0;
            foreach (string i in comboBox1.Items)
            {
                count++;


            }
            if (count == 0)
            {
                MessageBox.Show("All Projects have been assigned, There is no project left in Unassigned :) ");
            }
            else
            {
                label1.Visible = false;
                string cmd = "Select RegistrationNo,Id from Student where Id in (Select Id from Student except Select StudentId from GroupStudent);";
                SqlConnection q = new SqlConnection(conURL);
                q.Open();

                SqlDataAdapter ad = new SqlDataAdapter(cmd, q);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool iss = false;
            int count = 0;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(r.Cells["ADD"].Value) == true)
                {
                    count++;
                    iss = true;
                    //    break;
                }
            }
            if (iss == true && comboBox1.Text != "" && count <= 4)
            {
                List<int> indexes = new List<int>();
                SqlConnection op = new SqlConnection(conURL);
                op.Open();
                string cmd2 = "Insert into [Group] (Created_On) Values ('" + DateTime.Now.Date + "')";
                SqlCommand g1 = new SqlCommand(cmd2, op);
                g1.ExecuteNonQuery();
                string cmd3 = "Select max(Id) from [Group]";
                SqlCommand rt = new SqlCommand(cmd3, op);
                int gh = (int)rt.ExecuteScalar();



                string cmdt = "Select Id from Project where Title = '" + comboBox1.Text + "'";
                SqlCommand bn = new SqlCommand(cmdt, op);
                int yu = (int)bn.ExecuteScalar();


                string vb = "Insert into GroupProject (ProjectId,GroupId,AssignmentDate) values ('" + yu + "','" + gh + "','" + DateTime.Now + "')";
                SqlCommand kl = new SqlCommand(vb, op);
                kl.ExecuteNonQuery();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["ADD"].Value) == true)
                    {
                        int c = row.Index;
                        indexes.Add(c);

                    }
                }
                foreach (int i in indexes)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)

                    {
                        if (row.Index == i)
                        {

                            string Reg = row.Cells["RegistrationNo"].Value.ToString();
                            string cmd = "Select Id from Student where RegistrationNo ='" + Reg + "'";
                            SqlCommand g = new SqlCommand(cmd, op);
                            int q = (int)g.ExecuteScalar();

                            string s = "Select Id from Lookup where Category = 'STATUS' and Value = 'InActive'";
                           
                            SqlCommand go = new SqlCommand(s, op);
                            int qo = (int)go.ExecuteScalar();

                            string final = "Insert into GroupStudent (GroupId, StudentId,Status,AssignmentDate) values ('" + gh + "','" + q + "','" + qo + "','" + DateTime.Now.Date + "')";
                            SqlCommand g2 = new SqlCommand(final, op);
                            g2.ExecuteNonQuery();


                        }



                    }

                }
                MessageBox.Show("Group has been Created");
                this.Hide();
                CreateGroup gm = new CreateGroup();
                gm.Show();
            }
            else if (count > 4)
            {
                labelerror.Text = "Only 4 students are allowed in a group";
                labelerror.Visible = true;
            }
            else
            {
                lblerror.Text = "Please Select a Title";
                lblerror.Visible = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button1.Visible = false;
            comboBox2.Visible = true;
            string cmd = "Select Title from Project where Id in (Select ProjectId from GroupProject where GroupId in (select GroupId from GroupStudent group by GroupId having count(GroupId) < 4 ) except select Id from Project where Title = '" + comboBox1.Text + "')";
            SqlConnection con = new SqlConnection(conURL);
            con.Open();
            SqlCommand c = new SqlCommand(cmd, con);
            SqlDataReader rdr = c.ExecuteReader();
            while (rdr.Read())
            {
                string s = rdr["Title"].ToString();
                comboBox2.Items.Add(s);
            }
            button1.Visible = false;
            button2.Visible = false;
            comboBox1.Visible = false;
            label1.Text = "Select Project";
            label1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                string cmd = "select GroupId from GroupProject where ProjectId = (Select Id from Project where Title = '" + comboBox2.Text + "')";
                SqlConnection c = new SqlConnection(conURL);
                c.Open();
                SqlCommand con = new SqlCommand(cmd, c);
                int h = (int)con.ExecuteScalar();
                

                string co = "Select count(StudentId) from GroupStudent where GroupId = '" + h + "'";
                SqlCommand conn = new SqlCommand(co, c);
                int ho = (int)conn.ExecuteScalar();

                bool iss = false;
                int count = 0;
                List<int> indexes = new List<int>();
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(r.Cells["ADD"].Value) == true)
                    {
                        count++;
                        iss = true;
                        int com = r.Index;
                        indexes.Add(com);
                    }
                }
                if(count == 0)
                {
                    labelerror.Text = "Select the student first";
                    labelerror.Visible = true;
                }

                if (ho + count <= 4 && comboBox2.Text != "")
                {

                    foreach (int i in indexes)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)

                        {
                            if (row.Index == i)
                            {

                                string Reg = row.Cells["RegistrationNo"].Value.ToString();
                                string cd = "Select Id from Student where RegistrationNo ='" + Reg + "'";
                                SqlCommand g = new SqlCommand(cd, c);
                                int q = (int)g.ExecuteScalar();
                                

                                string final = "Insert into GroupStudent (GroupId, StudentId,Status,AssignmentDate) values ('" + h + "','" + q + "','" + 4 + "','" + DateTime.Now.Date + "')";
                                SqlCommand g2 = new SqlCommand(final, c);
                                g2.ExecuteNonQuery();


                            }



                        }
                        
                    }
                    MessageBox.Show("Student has been added");
                    this.Hide();
                    CreateGroup frm = new CreateGroup();
                    frm.Show();




                }
                else if (comboBox2.Text == "")
                {
                    lblerror.Text = "Select Title for project";
                    lblerror.Visible = true;
                    
                }
                else if (ho + count > 4)
                {
                    labelerror.Text = "Only 4 students are allowed in each group";
                    labelerror.Visible = true;
                }



            }
            else
            {
                lblerror.Text = "Select Title for project";
                lblerror.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ViewReports frm = new ViewReports();
            this.Hide();
            frm.Show();
        }
    }
   
}
