using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    
    public class DataServices
    {

        /// <summary>
        /// ConnectionStrings
        /// </summary>
        string strconn = ConfigurationManager.ConnectionStrings["connectionStrCon"].ToString();
        private SqlConnection m_conn;
        public SqlConnection Conn
        {
            get { return m_conn; }
            set { m_conn = value; }
        }
        public DataServices()
        {
            this.Conn = new SqlConnection(strconn);
        }
        /// <summary>
        /// Open connection function
        /// </summary>
        /// <returns></returns>
        public Boolean OpenConnection()
        {
            try
            {
                if (this.Conn.State == ConnectionState.Closed)
                {
                    this.Conn.Open();
                }
                return true;
            }
            catch (Exception)
            { }
            return false;
        }

        /// <summary>
        /// Close connection function
        /// </summary>
        public void CloseConnection()
        {
            this.Conn.Close();
        }

        /// <summary>
        /// Get data table
        /// </summary>
        /// <param name="strsql"></param>
        /// <param name="thamao"></param>
        /// <returns></returns>
        public DataTable DATable(string strsql, params SqlParameter[] parameters)
        {
            try
            {
                DataTable table = new DataTable();
                SqlCommand cmd = new SqlCommand(strsql, this.Conn);
                cmd.Parameters.AddRange(parameters);
                table.Load(cmd.ExecuteReader());
                return table;
            }
            catch (Exception)
            { }
            return null;
        }
        /// <summary>
        /// Update database function
        /// </summary>
        /// <param name="strsql">SQL Query</param>
        /// <param name="parameters">Input parameters</param>
        public void Updatedata(string strsql, params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(strsql, this.Conn);
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// Get values function
        /// </summary>
        /// <param name="strsql"></param>
        /// <param name="parameters"></param>
        /// <returns>Interger</returns>
        public int GetValues(string strsql, params SqlParameter[] parameters)
        {
            int val = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(strsql, this.Conn);
                cmd.Parameters.AddRange(parameters);
                val = (int)cmd.ExecuteScalar();

            }
            catch (Exception)
            { }
            return val;
        }
        public DateTime GetDateValues(string strsql, params SqlParameter[] param)
        {
            DateTime val = new DateTime(1900, 01, 01);
            try
            {
                SqlCommand cmd = new SqlCommand(strsql, this.Conn);
                cmd.Parameters.AddRange(param);
                val = (DateTime)cmd.ExecuteScalar();

            }
            catch (Exception)
            { }
            return val;
        }
        public string GetStringValues(string strsql, params SqlParameter[] param)
        {
            string val = "";
            try
            {
                SqlCommand cmd = new SqlCommand(strsql, this.Conn);
                cmd.Parameters.AddRange(param);
                val = (string)cmd.ExecuteScalar();

            }
            catch (Exception)
            { }
            return val;
        }

    }
}
