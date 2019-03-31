using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication23
{
    class Evaluations
    {
        public int totalmarks { get; set; }
        public int obtainedmarks { get; set; }
        public int totalwieghtage { get; set; }
        public string Name { get; set; }
        public DateTime EvaluationDate { get; set; }





        public bool Alldigits(string s)
        {
            if (s.All(Char.IsDigit) == true && s != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void load(string cmd, ComboBox v)

        {
            SqlDataReader rdr = dbConnection.getInstance().getData(cmd);
            while (rdr.Read())
            {
                string h = rdr[0].ToString();
                v.Items.Add(h);
            }
        }

        public int maxid()
        {
            int y = dbConnection.getInstance().getScalerData("Select max(Id) from Evaluation");
            return y;
        }
        public bool Allchar(string s)
        {
            if (s.All(Char.IsLetter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void loaddata(TextBox txtname, TextBox txttotalmarks, TextBox txttotalwieghtage, TextBox txtobtained, DataGridView dataGridView1)
        
        {
            txtname.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txtobtained.Text = dataGridView1.CurrentRow.Cells["ObtainedMarks"].Value.ToString();
            txttotalmarks.Text = dataGridView1.CurrentRow.Cells["TotalMarks"].Value.ToString();
            txttotalwieghtage.Text = dataGridView1.CurrentRow.Cells["TotalWeightage"].Value.ToString();

        }

        public bool uniqueevaluation(TextBox txtname, ComboBox comboBox1)
        {
            string c = "select Count(GroupId)  from  GroupEvaluation join Evaluation on Evaluation.Id = GroupEvaluation.EvaluationId where Name ='" + txtname.Text + "' and GroupId = '" + Convert.ToInt32(comboBox1.Text) + "'";
            int count = dbConnection.getInstance().getScalerData(c);
            if(count >= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
