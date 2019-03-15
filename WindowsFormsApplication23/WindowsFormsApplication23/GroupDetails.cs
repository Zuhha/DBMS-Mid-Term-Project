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
    public partial class GroupDetails : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public GroupDetails()
            
        {
           
            InitializeComponent();
        }

        private void GroupDetails_Load(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(conURL);
            string cmd8 = "Select * from GroupStudent ";
            SqlDataAdapter ad = new SqlDataAdapter(cmd8, c);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person_Details frm = new Person_Details();
            this.Hide();
            frm.Show();
        }
    }
}
