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
    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public  string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

/// <summary>
/// Checks that all input letters are characters
/// </summary>
/// <param name="s">string which is to be checked</param>
/// <returns>True or false according to input given</returns>

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
        /// Gives mostRecenly added  Persons' Id
        /// </summary>
        /// <returns>Max Id</returns>
        public int maxid()
        {
            int y = dbConnection.getInstance().getScalerData("Select max(Id) from Person");
            return y;
        }
        /// <summary>
        /// Prohibits Duplicateinsertion . Persons with same Firstname,Lastname , contact are considerd as Same.
        /// </summary>
        /// <param name="firstname">FirstName of Person</param>
        /// <param name="lastname">LastName of Person</param>
        /// <param name="contact">Contact Of Person</param>
        /// <param name="cmd">Query tht will be executed to check uniqueness</param>
        /// <returns></returns>
        public bool uniqueperson(string firstname, string lastname, string contact,string cmd)
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
        /// <summary>
        /// Checks that all input characters are digits
        /// </summary>
        /// <param name="s">String which is being checked</param>
        /// <returns>True if all are digits else false</returns>
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
        /// <summary>
        /// Fills combo Box according to query given 
        /// </summary>
        /// <param name="cmd">query on the base of which Combvo box is being filled</param>
        /// <param name="v">Combox which is to be filled</param>

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
        /// Adds person in list
        /// </summary>
        /// <param name="firstname">FirstName of person</param>
        /// <param name="lastname">Lastname of person</param>
        /// <param name="contact">Contact</param>
        /// <param name="email">Email</param>
        /// <param name="gender">Gender</param>
        /// <param name="dob">Dateofbirth</param>

        public void Addperson(string firstname, string lastname, string contact, string email, string gender, DateTime dob)
        {
            int gen = dbConnection.getInstance().getScalerData("Select Id from Lookup where Value = '" + gender + "'");
            dbConnection.getInstance().exectuteQuery("INSERT INTO Person(FirstName, LastName, Contact, Email,DateOfBirth, Gender) values ('" + firstname + "','" + lastname + "','" + (contact) + "','" + email + "','" + dob + "','" + gen + "')");
        }
        /// <summary>
        /// Checks that email enterd is valid or not
        /// </summary>
        /// <param name="s">string which is to be checked</param>
        /// <returns>true if enterd is valid else false</returns>

        public bool Emails(string s)
        {
            if (s.Contains("@") && s.Contains(".com"))
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
