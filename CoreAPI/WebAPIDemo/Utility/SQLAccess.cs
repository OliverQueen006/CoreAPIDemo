using System;
using System.Data;
using System.Data.SqlClient;

namespace WebAPIDemo.Utility
{
    public class SQLAccess
    {
        #region Declarations
        public SqlCommand cmd = null;
        public SqlConnection conn = null;
        #endregion

        #region Key Functions

        #region ExecuteNonQuery 
        public bool ExecuteNonQuery(string connstr, string Query)
        {
            bool result;
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand(Query, conn);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                int index = cmd.ExecuteNonQuery();
                if (index > 1)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                cmd.Dispose();
            }
            return result;
        }

        public object ExecuteNonQuery(string connstr, SqlCommand cmd)
        {
            object obj = new object();
            try
            {
                conn = new SqlConnection(connstr);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd.Connection = conn;
                obj = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                cmd.Dispose();
            }
            return obj;
        }

        #endregion

        #region ExecuteScalarQuery 
        public object ExecuteScalarQuery(string connstr, string Query)
        {
            object obj = new object();
            try
            {
                conn = new SqlConnection(connstr);
                cmd = new SqlCommand(Query, conn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                cmd.Dispose();
            }
            return obj;
        }

        public object ExecuteScalarQuery(string connstr, SqlCommand cmd)
        {
            object obj = new object();
            try
            {
                conn = new SqlConnection(connstr);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd.Connection = conn;
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                cmd.Dispose();
            }
            return obj;
        }

        #endregion

        #region GetDataSet 
        public DataSet GetDataSet(string connstr, string Query)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                conn = new SqlConnection(connstr);
                cmd = new SqlCommand(Query, conn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                cmd.Dispose();
                sda.Dispose();
            }
            return ds;
        }

        public DataSet GetDataSet(string connstr, SqlCommand cmd)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                conn = new SqlConnection(connstr);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd.Connection = conn;
                sda.SelectCommand = cmd;
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                cmd.Dispose();
                sda.Dispose();
            }
            return ds;
        }

        #endregion

        #endregion
    }
}