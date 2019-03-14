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
            if(s.All(Char.IsDigit))
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

       
       



    }
}
