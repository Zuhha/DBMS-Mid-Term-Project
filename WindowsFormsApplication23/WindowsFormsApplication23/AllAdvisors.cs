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
                textBox2.Text = dataGridView1.CurrentRow.Cells["Salary"].Value.ToString();


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
            SqlConnection co = new SqlConnection(c);
            co.Open();
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            string r = "Select Id from Lookup where Value = '" + comboBox1.Text + "'";
            SqlCommand v = new SqlCommand(r, co);
            int y = (int)v.ExecuteScalar();


            string s = "Update Advisor SET Designation = '" + y + "', Salary = '" + textBox2.Text + "'  where Id = '" + id + "' ";
           
            
            SqlCommand q = new SqlCommand(s, co);
            q.ExecuteNonQuery();
            co.Close();
            MessageBox.Show("Updated");
        }
    }
}
