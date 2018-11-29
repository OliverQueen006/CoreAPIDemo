using System;
using System.Data;
using System.Data.SqlClient;

namespace WebAPIDemo.Utility
{
    public class SQLAccess
    {
        #region Declarations
        public SqlCommand cmd = null;

        #endregion

        #region Key Functions

        #region ExecuteNonQuery 
        public bool ExecuteNonQuery(SqlConnection conn, string Query)
        {
            bool result;
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

        public object ExecuteNonQuery(SqlConnection conn, SqlCommand cmd)
        {
            object obj = new object();
            try
            {
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
        public object ExecuteScalarQuery(SqlConnection conn, string Query)
        {
            object obj = new object();
            try
            {
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

        public object ExecuteScalarQuery(SqlConnection conn, SqlCommand cmd)
        {
            object obj = new object();
            try
            {
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
        public DataSet GetDataSet(SqlConnection conn, string Query)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
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

        public DataSet GetDataSet(SqlConnection conn, SqlCommand cmd)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
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