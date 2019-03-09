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
            while(rdr.Read())
            {
                string id = rdr[0].ToString();
                comboBox1.Items.Add(id);
            }
            rdr.Close();
            string cmd = "Select Title from Project";
            SqlCommand f = new SqlCommand(cmd, c);
           
            SqlDataReader r = f.ExecuteReader();
            while(r.Read())
            {
                string title = r["Title"].ToString();
                comboBox2.Items.Add(title);
            }
            r.Close();
            string h = "Select Value from Lookup where Category = 'ADVISOR_ROLE'";
            SqlCommand g = new SqlCommand(h, c);
            SqlDataReader t = g.ExecuteReader();
            while(t.Read())
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
            string cmnd = "Select Id from Project where Title = '" + comboBox2.Text + "'";
            SqlCommand k = new SqlCommand(cmnd, con);
            int id  = (int)k.ExecuteScalar();
            string cmn = "Select Id from Lookup where Value = '" + comboBox3.Text + "'";
            SqlCommand ko = new SqlCommand(cmnd, con);
            int ide = (int)ko.ExecuteScalar();
            string h = "Insert into ProjectAdvisor(AdvisorId, ProjectId,AdvisorRole,AssignmentDate) values ('" + comboBox1.Text + "', '" + id + "','" + ide + "','" + DateTime.Now + "')";
            SqlCommand g = new SqlCommand(h, con);
            g.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Done!!");
        }
    }
}
