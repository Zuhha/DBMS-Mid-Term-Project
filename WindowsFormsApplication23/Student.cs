using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication23
{
    class Student:Person
    {
     
        public static List<Student> Students = new List<Student>();
        public string Regno { get; set; }




        public bool REGNO(string Reg_No)
        {
            string s1;
            string s2;
            string s3;
            string s4;
            string s5;
            if (Reg_No.Length != 11)
            {
                return false;
            }


            else if (Reg_No.Length == 11)
            {

                s1 = Reg_No.Substring(0, 4);
                s2 = Reg_No.Substring(5, 2);
                s3 = Reg_No.Substring(8);
                s4 = Reg_No.Substring(4, 1);
                s5 = Reg_No.Substring(7, 1);


                //Checking out that format is correct or not
                if ((s4 == "_" || s4 == "-") && (s5 == "_" || s5 == "-") && s1.All(Char.IsDigit) && s2.All(Char.IsLetter) && s3.All(Char.IsDigit))
                {

                    return true;
                }
                return false;
            }
            else
            { return false; }


        }
        public void AddStudent(string firstname, string lastname, string contact, string email, string gender, DateTime dob, string regno)
        {
            
            Student s = new Student();
            
            s.FirstName = firstname;
            s.LastName = lastname;
            s.Email = email;
            s.Gender = gender;
            s.DateOfBirth = dob;
            s.Contact = contact;
            s.Regno = regno;
            Students.Add(s);
            //int yo = dbConnection.getInstance().getScalerData ("Select Count(Id) from Person where FirstName = '" + firstname + "' and LastName = '" + lastname + "' and Contact = '" + contact + "'");


        }

        public void addstindb(string regno)
        {
            int y = maxid();
            dbConnection.getInstance().exectuteQuery("Insert into Student(Id, RegistrationNo) values ('" + y + "','" + regno + "')");
        }

    


        public bool uniqueregno(string regno,string cmd)
        {
            int yo = dbConnection.getInstance().getScalerData(cmd);
            if (yo >= 1)
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
