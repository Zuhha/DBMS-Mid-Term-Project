﻿using System;
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
    public partial class AllAdvisors : Form
    {
        string c = "Data Source = (local); Initial Catalog = ProjectA; Integrated Security = True";

        public AllAdvisors()
        {
            InitializeComponent();
        }

        private void AllAdvisors_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection(c);
            string s = "Select * from Advisor";
            SqlDataAdapter ad = new SqlDataAdapter(s, con);
            DataTable st = new DataTable();
            ad.Fill(st);
            dataGridView1.DataSource = st;

            con.Open();
            string f = "Select Value from Lookup where Category = 'DESIGNATION'";
            SqlCommand g = new SqlCommand(f, con);
            SqlDataReader rdr = g.ExecuteReader();
            while(rdr.Read())
            {
                string c = rdr["Value"].ToString();
                comboBox1.Items.Add(c);
            }
            rdr.Close();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                panel2.Visible = true;
                panel1.Visible = false;
                comboBox1.Text = dataGridView1.CurrentRow.Cells["Designation"].Value.ToString();
                txtsalary.Text = dataGridView1.CurrentRow.Cells["Salary"].Value.ToString();


            }
            else if (e.ColumnIndex == 1)
            {
                int u = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                string s = "Delete from ProjectAdvisor where AdvisorId = '" + u + "'";
                
                string hu = "Delete from Advisor where Id = '" + u + "'";

                SqlConnection op = new SqlConnection(c);
                op.Open();
                SqlCommand cmd = new SqlCommand(s, op);
                cmd.ExecuteNonQuery();
               
                SqlCommand cmd2 = new SqlCommand(hu, op);
                cmd2.ExecuteNonQuery();
                op.Close();
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                MessageBox.Show("Removed Successfully");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            if (st.Alldigits(txtsalary.Text) == false)
            {
                MessageBox.Show("Enter Valid Salary");
            }

            else if (st.Alldigits(txtsalary.Text) == true)
            {
                try
                {
                    SqlConnection co = new SqlConnection(c);
                    co.Open();
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                    string r = "Select Id from Lookup where Value = '" + comboBox1.Text + "'";
                    SqlCommand v = new SqlCommand(r, co);
                    int y = (int)v.ExecuteScalar();


                    string s = "Update Advisor SET Designation = '" + y + "', Salary = '" + txtsalary.Text + "'  where Id = '" + id + "' ";


                    SqlCommand q = new SqlCommand(s, co);
                    q.ExecuteNonQuery();
                    co.Close();
                    MessageBox.Show("Updated");
                }

                catch (Exception et)
                {
                    throw (et);
                }
            }
                
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Person_Details frm = new Person_Details();
            this.Hide();
            frm.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
