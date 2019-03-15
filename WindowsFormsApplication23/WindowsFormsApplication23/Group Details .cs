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
    public partial class Group_Details : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public Group_Details()
        {
            InitializeComponent();
        }

        private void Group_Details_Load(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(conURL);
            string cmd8 = "Select * from GroupStudent ";
            SqlDataAdapter ad = new SqlDataAdapter(cmd8, c);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
