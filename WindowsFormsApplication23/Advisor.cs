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
    class Advisor:Person
    {
        public string Designation { get; set; }
        public int salary { get; set; }

        public void AddAdvisor(string desig, int Salary)
        {
            Designation = desig;
            salary = Salary;
        }
        public void fillgender(DataGridView d)
        {
            int rows = Convert.ToInt32(d.RowCount.ToString());
            for (int i = 0; i < rows; i++)
            {
                int so = Convert.ToInt32(d.Rows[i].Cells["g"].Value);

                if (so == 1)
                {
                    d.Rows[i].Cells["Gender"].Value = "Male";

                }
                if (so == 2)
                {
                    d.Rows[i].Cells["Gender"].Value = "Female";
                }
            }

            d.Columns["g"].Visible = false;
        }
        public void Addadvisorindb()
        {
            int y = maxid();
            int yn = dbConnection.getInstance().getScalerData("Select Id from Lookup where Value = '" + Designation + "'");
            dbConnection.getInstance().exectuteQuery("Insert into Advisor(Id,Designation, Salary) values ('" + y + "','" + yn + "','" + salary + "')");
        }


       




        }

    }

