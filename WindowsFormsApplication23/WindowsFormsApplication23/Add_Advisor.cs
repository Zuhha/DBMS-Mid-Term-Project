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
    public partial class Add_Advisor : Form
    {
        string conURL = "Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";

        public Add_Advisor()
        {
            InitializeComponent();
            SqlConnection c = new SqlConnection(conURL);
            c.Open();
            string cmd = "Select Value from Lookup where Category = 'DESIGNATION' Order by Value";
            SqlCommand q = new SqlCommand(cmd, c);
            SqlDataReader rdr = q.ExecuteReader();

            while (rdr.Read())
            {
                string h = rdr[0].ToString();
                comboBox1.Items.Add(h);
            }
            c.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(conURL);
            c.Open();
            string cmd = "Select Id from Lookup where Value = '"+comboBox1.Text+"'";
            SqlCommand q = new SqlCommand(cmd, c);
            int y  = (int)q.ExecuteScalar();
            string x = "Insert into Advisor(Id, Designation, Salary) values ('" + txtid.Text + "','" + y + "','" + txtsalary.Text + "')";
            SqlCommand u = new SqlCommand(x, c);
            u.ExecuteNonQuery();
            c.Close();


            MessageBox.Show("Inserted");

        }
    }
}
