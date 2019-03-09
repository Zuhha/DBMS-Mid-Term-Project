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
    

    public partial class Add_Group : Form
    {
        string con = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        public Add_Group()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            
            string varDate = System.DateTime.Now.Date.ToString();
            string cmd = "Insert into Group( Created_On) values ('"+varDate+"')";
            SqlCommand c = new SqlCommand(cmd,conn);
            c.ExecuteNonQuery();
            con.Clone();
            MessageBox.Show("Group has been added!!!");
        }
    }
}
