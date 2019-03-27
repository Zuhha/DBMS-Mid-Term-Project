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
    public partial class Groups : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public Groups()
        {
            InitializeComponent();
        }

        private void Groups_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conURL);
            string cmd = "Select * from GroupStudent ";
            SqlDataAdapter ad = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);

        }
    }
}
