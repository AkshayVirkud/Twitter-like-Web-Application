using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace TwitterAplication
{
    /// <summary>
    /// 
    /// </summary>
    public static class Utility
    {
        static string connectionString = System.Configuration.ConfigurationManager.AppSettings["connString"];
        //static string connectionString = @"Data Source=USER-PC\AKSHAY;Initial Catalog=Litmus;Persist Security Info=True;User ID=sa;Password=akshay";
        //static string connectionString = @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=Litmus;Integrated Security = True;"; 
      
        /// <summary>
        /// It executes select statement and returns dataset
        /// </summary>
        /// <param name="query">SQL Select Query</param>
        /// <returns>Dataset containing the selected values</returns>
        public static DataSet ExecuteSelectQuery(string query)
        {
            DataSet  objDataset = new DataSet();
 
            SqlConnection objSQLiteConnection = new SqlConnection(connectionString);
            objSQLiteConnection.Open();

            SqlCommand objSQLCommand = new SqlCommand(query, objSQLiteConnection);
            objSQLCommand.CommandType = CommandType.Text;

            SqlDataAdapter objSqlAdapter = new SqlDataAdapter();

            objSqlAdapter.SelectCommand = objSQLCommand;
            objSqlAdapter.Fill(objDataset);

            objSQLiteConnection.Close();

            return objDataset;
        }


        /// <summary>
        /// It executes select statement and returns first row and first column of the result,
        /// </summary>
        /// <param name="query">SQL Select Query</param>
        /// <returns>First Row & First Column of the result</returns>
        public static object ExecuteSelectQueryWithSingleResult(string query)
        {
            object result = new object();

            SqlConnection objSQLiteConnection = new SqlConnection(connectionString);
            objSQLiteConnection.Open();

            SqlCommand objSQLCommand = new SqlCommand(query, objSQLiteConnection);
            objSQLCommand.CommandType = CommandType.Text;

            result = (objSQLCommand.ExecuteScalar());

            objSQLiteConnection.Close();

            return result;
        }


        /// <summary>
        /// Inserts a record in the database
        /// </summary>
        /// <param name="query">SQL Insert Query</param>
        /// <returns>Result TRUE if Insert was Successful else FALSE</returns>
        public static bool ExecuteInsertQuery(string query)
        {
            bool result = false;

            SqlConnection objSQLiteConnection = new SqlConnection(connectionString);
            objSQLiteConnection.Open();

            SqlCommand objSQLCommand = new SqlCommand(query, objSQLiteConnection);
            objSQLCommand.CommandType = CommandType.Text;

            int noOfRows = objSQLCommand.ExecuteNonQuery();

            objSQLiteConnection.Close();

            if (noOfRows != -1)
            {
                result = true;
            }

            return result;
        }


        /// <summary>
        /// Updates a record in the database
        /// </summary>
        /// <param name="query">SQL Update Query</param>
        /// <returns>Result TRUE if Update was Successful else FALSE</returns>
        public static bool ExecuteUpdateQuery(string query)
        {
            bool result = false;

            SqlConnection objSQLiteConnection = new SqlConnection(connectionString);
            objSQLiteConnection.Open();

            SqlCommand objSQLCommand = new SqlCommand(query, objSQLiteConnection);
            objSQLCommand.CommandType = CommandType.Text;

            objSQLCommand.ExecuteNonQuery();

            return result;
        }


        /// <summary>
        /// Deletes a record from the dataset.
        /// </summary>
        /// <param name="query">SQL Delete Query</param>
        /// <returns>Result TRUE if Delete was Successful else FALSE</returns>
        public static bool ExecuteDeleteQuery(string query)
        {
            bool result = false;

            SqlConnection objSQLiteConnection = new SqlConnection(connectionString);
            objSQLiteConnection.Open();

            SqlCommand objSQLCommand = new SqlCommand(query, objSQLiteConnection);
            objSQLCommand.CommandType = CommandType.Text;

            objSQLCommand.ExecuteNonQuery();
            objSQLiteConnection.Close();

            return result;
        }

        /// <summary>
        /// Computes SHA1 Hashed password for the plain text password string.
        /// </summary>
        /// <param name="password">plain text password</param>
        /// <returns>Hashed password</returns>
        public static string ComputeHashedPassword(string password)
        {
            string hashedPassword = string.Empty;

            byte[] key = System.Text.Encoding.Default.GetBytes(password);

            SHA1 sha1 = SHA1Managed.Create();

            byte[] hash = sha1.ComputeHash(key);

            foreach (byte b in hash)
            {
                hashedPassword += Convert.ToInt32(b).ToString("x2");
            }

            return hashedPassword;

        }

    }
}