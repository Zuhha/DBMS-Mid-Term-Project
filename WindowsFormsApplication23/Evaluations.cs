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



        // Checks all input letters are digits or not

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
        // Fills comboBox according to given Query
        public void load(string cmd, ComboBox v)

        {
            SqlDataReader rdr = dbConnection.getInstance().getData(cmd);
            while (rdr.Read())
            {
                string h = rdr[0].ToString();
                v.Items.Add(h);
            }
        }
       /// <summary>
       /// Gives Maximum EvaluationId
       /// </summary>
       /// <returns>Returns maximum evaluationId</returns>
        public int maxid()
        {
            int y = dbConnection.getInstance().getScalerData("Select max(Id) from Evaluation");
            return y;
        }
        /// <summary>
        /// Checks that all inputs are character or not.
        /// </summary>
        /// <param name="s">takes a string which is to be checked</param>
        /// <returns></returns>
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
        /// <summary>
        /// Loads data on Updation form according to cell clicked 
        /// </summary>
        /// <param name="txtname">Textbox having name</param>
        /// <param name="txttotalmarks">textbox having totalmarks</param>
        /// <param name="txttotalwieghtage">textbox having total weightage</param>
        /// <param name="txtobtained">textbox having obtained marks</param>
        /// <param name="dataGridView1">Grid From which value has been extracted</param>
        public void loaddata(TextBox txtname, TextBox txttotalmarks, TextBox txttotalwieghtage, TextBox txtobtained, DataGridView dataGridView1)
        
        {
            txtname.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txtobtained.Text = dataGridView1.CurrentRow.Cells["ObtainedMarks"].Value.ToString();
            txttotalmarks.Text = dataGridView1.CurrentRow.Cells["TotalMarks"].Value.ToString();
            txttotalwieghtage.Text = dataGridView1.CurrentRow.Cells["TotalWeightage"].Value.ToString();

        }
        /// <summary>
        /// Prohibits insertion of duplicate data
        /// </summary>
        /// <param name="txtname">textbox habing name of evaluation</param>
        /// <param name="comboBox1">combo Box having GroupIds</param>
        /// <returns></returns>

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
