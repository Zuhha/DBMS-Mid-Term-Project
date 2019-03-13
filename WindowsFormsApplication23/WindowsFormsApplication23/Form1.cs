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
    public partial class Person_Details : Form
    {
        public Person_Details()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
                SqlConnection con = new SqlConnection(conURL);
                con.Open();


                string em = "Select Id from Lookup where Value = '" + comboBox1.Text + "'";
                SqlCommand nd = new SqlCommand(em, con);
                SqlDataReader r = nd.ExecuteReader();
                int id = 0;
                while (r.Read())
                {
                    id = r.GetInt32(0);
                }
                r.Close();
                string cmd = "INSERT INTO Person(FirstName, LastName, Contact, Email,DateOfBirth, Gender) values ('" + txtfirstname.Text + "','" + txtlastname.Text + "','" + txtcontact.Text + "','" + txtemail.Text + "','" + (dateTimePicker1.Value) + "','" + id + "')";
                SqlCommand command = new SqlCommand(cmd, con);
                command.ExecuteNonQuery();


                string stmt = "Select max(Id) from Person ";
                SqlCommand b = new SqlCommand(stmt, con);
                int y = (int)b.ExecuteScalar();

                string Query = "Insert into Student(Id, RegistrationNo) values ('" + y + "','" + txtregno.Text + "')";
                SqlCommand o = new SqlCommand(Query, con);
                o.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Person has been added");

            }

            catch(Exception et)
            {
                throw (et);
            }










        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            CreateGroup form = new CreateGroup();
            form.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Add_Advisor frm = new Add_Advisor();
            frm.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Add_Project ad = new Add_Project();
            ad.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Assign_Project_To_Advisor ad = new Assign_Project_To_Advisor();
            ad.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Student_Details g = new Student_Details();
            g.Show();
        }
    }
}
