using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    class Group
    {
       public DateTime createdon { get; }


        public void exists(ComboBox c, Label l , DataGridView d)
        {
            int count = 0;
            foreach (string i in c.Items)
            {
                count++;


            }
            if (count == 0)
            {
                MessageBox.Show("All Projects have been assigned, There is no project left in Unassigned :) ");
            }
            else
            {
               //All those students to which group has not been assigned
                string cmd = "Select RegistrationNo,Id from Student where Id in (Select Id from Student except Select StudentId from GroupStudent);";
                dbConnection.getInstance().fill(cmd,d);
                
            }
        }



        public bool checkboxchech(DataGridView d)
        {
            
            bool iss = true;
            foreach (DataGridViewRow r in d.Rows)
            {
                if (Convert.ToBoolean(r.Cells["ADD"].Value) == true)
                {
                   
                    iss = true;
                    break;
                }
                else
                {
                    iss= false;
                }
            }
            return iss;
        }



        public int NoOfSt(DataGridView d)
        {
            int count = 0;
           
            foreach (DataGridViewRow r in d.Rows)
            {
                if (Convert.ToBoolean(r.Cells["ADD"].Value) == true)
                {
                    count++;
                  
                }
              
            }
            return count;

        }


        public List<int> ListOfindexes(List<int> indexes, DataGridView d)
        {
            foreach (DataGridViewRow row in d.Rows)
            {
                if (Convert.ToBoolean(row.Cells["ADD"].Value) == true)
                {
                    int c = row.Index;
                    indexes.Add(c);

                }
            }
            return indexes;
        }


        public void Addstatus(DataGridView d)
        {
            int count = d.RowCount;
            for(int i =0; i < count; i++)
            {
                if(Convert.ToInt32(d.Rows[i].Cells["u"].Value) == 3)
                {
                    d.Rows[i].Cells["Status"].Value = "Active";
                }
                else if(Convert.ToInt32(d.Rows[i].Cells["u"].Value) == 4)
                {
                    d.Rows[i].Cells["Status"].Value = "InActive";
                }
            }
            d.Columns["u"].Visible = false;
        }

        public void Addstudentinexistinggroup(ComboBox comboBox2,DataGridView dataGridView1,Label labelerror, Label lblerror)
        {
            if (comboBox2.Text != "")
            {
                string cmd = "select GroupId from GroupProject where ProjectId = (Select Id from Project where Title = '" + comboBox2.Text + "')";
                int h = dbConnection.getInstance().getScalerData(cmd);
                string co = "Select count(StudentId) from GroupStudent where GroupId = '" + h + "'";
                int ho = dbConnection.getInstance().getScalerData(co);
                bool iss = false;
                int count = 0;
                List<int> indexes = new List<int>();
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(r.Cells["ADD"].Value) == true)
                    {
                        count++;
                        iss = true;
                        int com = r.Index;
                        indexes.Add(com);
                    }
                }
                if (count == 0)
                {
                    labelerror.Text = "Select the student first";
                    labelerror.Visible = true;
                }

                if (ho + count <= 4 && comboBox2.Text != "")
                {

                    foreach (int i in indexes)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)

                        {
                            if (row.Index == i)
                            {

                                string Reg = row.Cells["RegistrationNo"].Value.ToString();
                                string cd = "Select Id from Student where RegistrationNo ='" + Reg + "'";

                                int q = dbConnection.getInstance().getScalerData(cd);


                                string final = "Insert into GroupStudent (GroupId, StudentId,Status,AssignmentDate) values ('" + h + "','" + q + "','" + 4 + "','" + DateTime.Now.Date + "')";
                                dbConnection.getInstance().exectuteQuery(final);


                            }



                        }

                    }
                    MessageBox.Show("Student has been added");
                   // CreateGroup.Hide();
                    CreateGroup frm = new CreateGroup();
                    frm.Hide();
                    CreateGroup frmo = new CreateGroup();
                    frmo.Show();




                }
                else if (comboBox2.Text == "")
                {
                    lblerror.Text = "Select Title for project";
                    lblerror.Visible = true;

                }
                else if (ho + count > 4)
                {
                    labelerror.Text = "Only 4 students are allowed in each group";
                    labelerror.Visible = true;
                }



            }
            else
            {
                lblerror.Text = "Select Title for project";
                lblerror.Visible = true;
            }
        }


    }
}
