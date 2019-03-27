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
    public partial class EditStatus : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public EditStatus()
        {
            InitializeComponent();
            panel2.Visible = false;
        }

        private void EditStatus_Load(object sender, EventArgs e)
        {
            string cmd = "Select FirstName+' '+LastName as Name,RegistrationNo,Status,GroupId,StudentId from Person join Student on Person.Id = Student.Id join GroupStudent on StudentId = Person.Id ";
            SqlConnection con = new SqlConnection(conURL);
            con.Open();
            SqlDataAdapter ada = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                panel2.Visible = true;
                panel1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["StudentId"].Value);
            SqlConnection conU = new SqlConnection(conURL);
            conU.Open();
            if (comboBox1.Text == "ACTIVE")
            {
                string oss = "Update GroupStudent SET Status = '" + 3 + "' where StudentId = '" + id + "'";
                SqlCommand go = new SqlCommand(oss, conU);
                go.ExecuteNonQuery();
            }
            else if(comboBox1.Text == "INACTIVE")
            {
                string oss = "Update GroupStudent SET Status = '" + 4 + "' where StudentId = '" + id + "'";
                SqlCommand go = new SqlCommand(oss, conU);
                go.ExecuteNonQuery();
            }
            else if(comboBox1.Text == "")
            {
                MessageBox.Show("Select Status First");
            }
            this.Hide();
            EditStatus ed = new EditStatus();
            ed.Show();

           
            
            
        }
    }
}
