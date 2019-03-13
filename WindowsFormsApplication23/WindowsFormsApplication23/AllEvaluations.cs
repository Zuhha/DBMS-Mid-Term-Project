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
    public partial class AllEvaluations : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public AllEvaluations()
        {
            InitializeComponent();
        }

        private void AllEvaluations_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection c = new SqlConnection(conURL);
            string cmd8 = "Select * from Evaluation ";
            SqlDataAdapter ad = new SqlDataAdapter(cmd8, c);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            dataGridView1.DataSource = dt;
            textBox1.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["TotalMarks"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["TotalWeightage"].Value.ToString();

           

            



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
                string o = dataGridView1.CurrentRow.Cells["Id"].FormattedValue.ToString();
                int u = Convert.ToInt32(o);
                
                string s = "Delete from GroupEvaluation where EvaluationId = '" + u + "'";
                string ss = "Delete from Evaluation where Id = '" + u + "'";


                SqlConnection op = new SqlConnection(conURL);
                op.Open();

                SqlCommand cmd1 = new SqlCommand(s, op);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand(ss, op);
                cmd2.ExecuteNonQuery();

                op.Close();
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                MessageBox.Show("Deleted");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string os = "Update Evaluation SET Name = '" + textBox1.Text + "', TotalMarks = '" + Convert.ToInt32(textBox2.Text) + "',TotalWeightage = '" + Convert.ToInt32(textBox3.Text) + "' where Id = '" + dataGridView1.CurrentRow.Cells["Id"].Value + "'";
            SqlConnection conU = new SqlConnection(conURL);
            conU.Open();
            SqlCommand go = new SqlCommand(os, conU);
            go.ExecuteNonQuery();
            conU.Close();
            MessageBox.Show("Updated");
        }
    }
}
