using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AuktionEPAM.DAL
{
    public static class Function
    {
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\G\src\AuktionEPAM.DAL\App_Data\DataBase.mdf;Integrated Security=True";

        public static SqlCommand Get_sql_command(SqlConnection con, string str)
        {
            SqlCommand sql_command = con.CreateCommand();
            sql_command.CommandType = CommandType.StoredProcedure;
            sql_command.CommandText = str;
            return sql_command;
        }
        public static SqlParameter Get_sql_parameter(string str, object obj, DbType typ)
        {
            return new SqlParameter()
            {
                DbType = typ,
                ParameterName = str,
                Value = obj,
                Direction = ParameterDirection.Input
            };
        }
    }
}
