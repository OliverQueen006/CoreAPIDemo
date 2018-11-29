using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            cmd.CommandText = "";//Name of Stored Procedure
            cmd.Parameters.AddWithValue("@Mode", 1);
            return sqlacc.GetDataSet(connectionstr, cmd);
        }
    }
}