using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication23
{
    class Student
    {
       public bool Allchar(string s)
        {
            if(s.All(Char.IsLetter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


      public  bool Alldigits(string s)
        {
            if(s.All(Char.IsDigit) == true &&  s != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


      public  bool Email(string s)
        {
            if(s.Contains("@") && s.Contains(".com"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


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





    }
}
