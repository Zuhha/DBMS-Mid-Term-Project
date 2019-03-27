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
    public partial class Evaluation : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        Student st = new Student();
        public Evaluation()
        {
            InitializeComponent();
        }

        private void Evaluation_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            SqlConnection con = new SqlConnection(conURL);
            con.Open();
            string cmd = "Select Id from [Group]";
            SqlCommand c = new SqlCommand(cmd, con);
            SqlDataReader rdr = c.ExecuteReader();
            while (rdr.Read())
            {
                int s = rdr.GetInt32(0);
                comboBox1.Items.Add(s);
            }
            rdr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (lblname.Text == "" && lblobtained.Text=="" && lbltotalmarks.Text ==""&& lblgroupid.Text == "" && lbltotalwieghtage.Text == "")
                {
            
                    string cmd = "Insert into Evaluation (Name, TotalMarks,TotalWeightage) values ('" + txtname.Text + "','" + txttotalmarks.Text + "','" + txttotalwieghtage.Text + "')";
                    SqlConnection q = new SqlConnection(conURL);
                    q.Open();
                    SqlCommand c = new SqlCommand(cmd, q);
                    c.ExecuteNonQuery();


                    string o = "Select max(Id) from Evaluation";
                    SqlCommand n = new SqlCommand(o, q);
                    int id = (int)n.ExecuteScalar();
                    string cmd1 = "Insert into GroupEvaluation (GroupId, EvaluationId, ObtainedMarks, EvaluationDate) values ('" + comboBox1.Text + "','" + id + "','" + txtobtained.Text + "','" + DateTime.Now + "') ";
                    SqlCommand fg = new SqlCommand(cmd1, q);
                    fg.ExecuteNonQuery();

                    MessageBox.Show("Evaluation Has been marked");


                }
                else
            {
                lblerror.Text = "Enter Valid Entries !!!";
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

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void comboBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            
           
            

        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
           
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
            if(st.Alldigits(txttotalmarks.Text) == true)
            {
                lbltotalmarks.Text = "";
                lbltotalmarks.Visible = false;
            }
            else
            {
                lbltotalmarks.Text = "Digits Only !!";
            }
           
        }

        private void txtobtained_KeyUp(object sender, KeyEventArgs e)
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

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text != "")
            {
                lblgroupid.Visible = false;
                lblgroupid.Text = "";
            }
        }
    }
}