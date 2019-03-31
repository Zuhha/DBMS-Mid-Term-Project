using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication23
{
    class Student:Person
    {
        /// <summary>
        /// List of all the students
        /// </summary>
     
        public static List<Student> Students = new List<Student>();
        /// <summary>
        /// Registration No of student
        /// </summary>
        public string Regno { get; set; }


        /// <summary>
        /// Checks validity of registration Number
        /// </summary>
        /// <param name="Reg_No">string which is to be checked</param>
        /// <returns>true if format is correct else false</returns>

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
        /// <summary>
        /// Adds student is list
        /// </summary>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="contact">contact</param>
        /// <param name="email">email</param>
        /// <param name="gender">gender</param>
        /// <param name="dob">dob</param>
        /// <param name="regno">Registration Number</param>
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
        /// <summary>
        /// Adds Student data in Database
        /// </summary>
        /// <param name="regno">Registration Number</param>

        public void addstindb(string regno)
        {
            int y = maxid();
            dbConnection.getInstance().exectuteQuery("Insert into Student(Id, RegistrationNo) values ('" + y + "','" + regno + "')");
        }

    
/// <summary>
/// Prohibits duplication of reg no
/// </summary>
/// <param name="regno"></param>
/// <param name="cmd"></param>
/// <returns>true if regno is unique else false</returns>

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
