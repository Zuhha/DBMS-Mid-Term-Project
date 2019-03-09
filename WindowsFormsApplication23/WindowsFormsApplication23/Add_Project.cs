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
    public partial class Add_Project : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";

        public Add_Project()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conURL);
            con.Open();
            string cmd = "Insert into Project(Description, Title) values ('" + txtdesc.Text + "','" + txttittle.Text + "')";
            SqlCommand g = new SqlCommand(cmd, con);
            g.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Done!");
        }
    }
}
