using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication23
{
    class Student
    {
        private string First_Name;
        private string Last_Name;
        private int Gender;
        private int Contact;
        private string Email;
        private DateTime DOB;




        bool isvalid(string f, string l, int cont, string e)
        {
            if(f.All(char.IsLetter))
            {
                setfirstname(f);
                return true;
            }
            else
            {
                return false;
            }
        }


        bool lastisvalid(string f, string l, int cont, string e)
        {
            if (l.All(char.IsLetter))
            {
                setfirstname(f);
                return true;
            }
            else
            {
                return false;
            }
        }




        public string getfirstname()
        {
            return First_Name;
        }
        public void setfirstname(string name)
        {
            First_Name = name;
        }
        public string getlastname()
        {
            return Last_Name;
        }
        public void setlastname(string name)
        {
            Last_Name = name;
        }
        public int getgender()
        {
            return Gender;
        }
        public void setgender(int s)
        {
            Gender = s;
        }
        public DateTime getdob()
        {
            return DOB;
        }
        public void setdob(DateTime s)
        {
            DOB = s;
        }
        public string getemail()
        {
            return Email;
        }
        public void setemail(string s)
        {
            Email = s;
        }



    }
}
