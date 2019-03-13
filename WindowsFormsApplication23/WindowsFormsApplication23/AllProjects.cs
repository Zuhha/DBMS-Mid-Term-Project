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
    public partial class AllProjects : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public AllProjects()
        {
            InitializeComponent();
            panel2.Visible = false;
        }

        private void AllProjects_Load(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(conURL);
            string s = "Select * from Project";
           
            SqlDataAdapter ad = new SqlDataAdapter(s,c);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                panel2.Visible = true;
                panel1.Visible = false;
                textBox1.Text = dataGridView1.CurrentRow.Cells["Title"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();
                
                
            }
            else if (e.ColumnIndex == 1)
            {
                int u = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                string s = "Delete from ProjectAdvisor where ProjectId = '" + u + "'";
                string st = "Delete from GroupProject where ProjectId = '"+u+"'";
                string hu = "Delete from Project where Id = '" + u + "'";
               
                SqlConnection op = new SqlConnection(conURL);
                op.Open();
                SqlCommand cmd = new SqlCommand(s, op);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand(st, op);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand(hu, op);
                cmd2.ExecuteNonQuery();
                op.Close();
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                MessageBox.Show("Removed Successfully");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void Update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            string s = "Update Project SET Description = '" + textBox2.Text + "', Title = '" + textBox1.Text + "'  where Id = '" + id + "' ";
            SqlConnection c = new SqlConnection(conURL);
            c.Open();
            SqlCommand q = new SqlCommand(s, c);
            q.ExecuteNonQuery();
            c.Close();
            MessageBox.Show("Updated");
        }
    }
}
