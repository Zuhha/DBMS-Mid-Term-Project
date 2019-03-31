using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;


namespace WindowsFormsApplication23
{
    class dbConnection
    {
        private static dbConnection instance;
        public String ConnectionString = @"Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
        private SqlConnection connection;

        /// <summary>
        /// Allows to make only one object of class.
        /// </summary>
        /// <returns> Instance of class. </returns>
        /// 
        public void fill(string cms,DataGridView d)
        {
            
            SqlDataAdapter ad = new SqlDataAdapter(cms, getConnection());
            DataTable st = new DataTable();
            ad.Fill(st);
            d.DataSource = st;
        }

        public static dbConnection getInstance()
        {
            if (instance == null)
                instance = new dbConnection();
            return instance;
        }

        private dbConnection()
        {


        }

        /// <summary>
        /// Opens SQL Connection
        /// </summary>
        /// <returns> SQL connection object </returns>
        public SqlConnection getConnection()
        {
            connection = new SqlConnection(ConnectionString);
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            return connection;
        }

        /// <summary>
        /// Reads the data from SQL database.
        /// </summary>
        /// <param name="commnadText"> String in string.Format style. It is the string that goes in query. </param>
        /// <returns> SQL Reader Object </returns>
        public SqlDataReader getData(String commnadText)
        {
            connection = getConnection();
            SqlCommand cmd = new SqlCommand(commnadText, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public int getScalerData(String commnadText)
        {
            connection = getConnection();
            SqlCommand cmd = new SqlCommand(commnadText, connection);
            int i = Convert.ToInt32( cmd.ExecuteScalar());
            return i;
            //return reader;
        }

        /// <summary>
        /// Executes the commands in query and calculates number of rows effected.
        /// </summary>
        /// <param name="commnadText"> String in string.Format style. It is the string that goes in query. </param>
        /// <returns> number of affected rows. </returns>
        public int exectuteQuery(String commnadText)
        {
            connection = getConnection();
            SqlCommand cmd = new SqlCommand(commnadText, connection);
            int rows = cmd.ExecuteNonQuery();
            return rows;
        }

        /// <summary>
        /// Close the connection.
        /// </summary>
        public void closeConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
                
        }
    }
}
