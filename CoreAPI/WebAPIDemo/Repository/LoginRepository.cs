using System;
using System.Data;
using System.Data.SqlClient;
using WebAPIDemo.Utility;

namespace WebAPIDemo.Repository
{
    public class LoginRepository
    {
        private SQLAccess sqlacc = null;
        private SqlCommand cmd = null;

        public object CheckUser(string connectionstr,string EmailId,string Password)
        {
            sqlacc = new SQLAccess();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_tb_User";//Name of Stored Procedure
            cmd.Parameters.AddWithValue("@EmailId", EmailId);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Mode", 6);
            return sqlacc.ExecuteScalarQuery(connectionstr, cmd);
        }
    }
}