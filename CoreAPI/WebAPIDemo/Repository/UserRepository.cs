using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPIDemo.Models;
using WebAPIDemo.Utility;

namespace WebAPIDemo.Repository
{
    public class UserRepository
    {
        private SQLAccess sqlacc = null;
        private SqlCommand cmd = null;
        public DataSet GetAllUser(string connectionstr)
        {
            sqlacc = new SQLAccess();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_tb_User";//Name of Stored Procedure
            cmd.Parameters.AddWithValue("@Mode", 1);
            return sqlacc.GetDataSet(connectionstr, cmd);
        }

        public DataSet GetByName(string connectionstr, string Name)
        {
            sqlacc = new SQLAccess();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_tb_User";//Name of Stored Procedure
            cmd.Parameters.AddWithValue("@UserName", Name);
            cmd.Parameters.AddWithValue("@Mode", 2);
            return sqlacc.GetDataSet(connectionstr, cmd);
        }

        public object AddEdit(string connectionstr, UserModel usermodel, bool Insert)
        {
            sqlacc = new SQLAccess();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_tb_User";//Name of Stored Procedure
            cmd.Parameters.AddWithValue("@UserId", usermodel.Id);
            cmd.Parameters.AddWithValue("@UserName", usermodel.UserName);
            cmd.Parameters.AddWithValue("@EmailId", usermodel.EmailId);
            cmd.Parameters.AddWithValue("@Mobile", usermodel.Mobile);
            cmd.Parameters.AddWithValue("@Address", usermodel.Address);
            cmd.Parameters.AddWithValue("@IsActive", usermodel.IsActive);
            if (Insert)
            {
                cmd.Parameters.AddWithValue("@Mode", 3);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Mode", 4);
            }
            return sqlacc.ExecuteNonQuery(connectionstr, cmd);
        }

        public object Delete(string connectionstr, int UserId)
        {
            sqlacc = new SQLAccess();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_tb_User";//Name of Stored Procedure
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@Mode", 5);
            return sqlacc.ExecuteNonQuery(connectionstr, cmd);
        }
    }
}