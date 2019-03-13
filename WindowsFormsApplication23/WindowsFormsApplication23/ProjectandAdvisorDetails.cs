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
    public partial class ProjectandAdvisorDetails : Form
    {
        public ProjectandAdvisorDetails()
        {
            InitializeComponent();
        }
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        private void ProjectandAdvisorDetails_Load(object sender, EventArgs e)
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

            string cmd8 = "Select * from ProjectAdvisor ";
           
            SqlDataAdapter ad = new SqlDataAdapter(cmd8, c);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            dataGridView1.DataSource = dt;
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
                string o = dataGridView1.CurrentRow.Cells["ProjectId"].FormattedValue.ToString();
                int u = Convert.ToInt32(o);
                string oo = dataGridView1.CurrentRow.Cells["AdvisorId"].FormattedValue.ToString();
                int uu = Convert.ToInt32(o);
                string s = "Delete from ProjectAdvisor where ProjectId = '" + u + "'and AdvisorId = '"+uu+"'";
                
                SqlConnection op = new SqlConnection(conURL);
                op.Open();
                
                SqlCommand cmd1 = new SqlCommand(s, op);
                cmd1.ExecuteNonQuery();
               
                op.Close();
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                MessageBox.Show("Deleted");
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conURL);
            con.Open();
            string s = "Select Id from Lookup where Value = '" + comboBox3.Text + "'";
            string g = "Select Id from Project where Title = '" + comboBox2.Text + "'";
            SqlCommand gh = new SqlCommand(s, con);
            int i = (int)gh.ExecuteScalar();
            SqlCommand gho = new SqlCommand(g, con);
            int j = (int)gho.ExecuteScalar();


            string os = "Update ProjectAdvisor SET ProjectId = '" + j + "', AdvisorId = '" + Convert.ToInt32(comboBox1.Text) + "',AdvisorRole = '" + i + "',AssignmentDate = '" + dateTimePicker1.Value + "' where ProjectId = '"+dataGridView1.CurrentRow.Cells["ProjectId"].Value+ "'and AdvisorId = '" + dataGridView1.CurrentRow.Cells["AdvisorId"].Value + "'";
            SqlCommand go = new SqlCommand(os, con);
            go.ExecuteNonQuery();
            MessageBox.Show("Updated");
        }
    }
}
