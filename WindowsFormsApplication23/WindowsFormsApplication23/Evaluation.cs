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
    public partial class Evaluation : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public Evaluation()
        {
            InitializeComponent();
        }

        private void Evaluation_Load(object sender, EventArgs e)
        {
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
            string cmd = "Insert into Evaluation (Name, TotalMarks,TotalWeightage) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "')";
            SqlConnection q = new SqlConnection(conURL);
            q.Open();
            SqlCommand c = new SqlCommand(cmd, q);
            c.ExecuteNonQuery();


            string o = "Select max(Id) from Evaluation";
            SqlCommand n = new SqlCommand(o, q);
            int id = (int)n.ExecuteScalar();
            string cmd1 = "Insert into GroupEvaluation (GroupId, EvaluationId, ObtainedMarks, EvaluationDate) values ('"+comboBox1.Text+"','"+id+"','"+textBox3.Text+"','"+DateTime.Now+"') ";
            SqlCommand fg = new SqlCommand(cmd1, q);
            fg.ExecuteNonQuery();

        }
    }
}
