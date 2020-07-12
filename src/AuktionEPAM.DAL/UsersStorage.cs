using AuktionEPAM.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AuktionEPAM.DAL
{
    public class UsersStorage
    {
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\G\src\AuktionEPAM.DAL\App_Data\DataBase.mdf;Integrated Security=True";

        public User GetInfoUser(int id_user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                //SqlCommand sql_command = Get_sql_command(connection, "dbo.Get_Info_User");
                //sql_command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCommand sql_command = Get_sql_command(connection, "dbo.Get_Info_User");
                sql_command.Parameters.Add(Get_sql_parameter("v1", id_user, DbType.Int32));
                connection.Open();
                var reader = sql_command.ExecuteReader();
                User user = null;
                while (reader.Read())
                {
                    user = new User()
                    {
                        Id_user = Convert.ToInt32(reader["Id_user"]),
                        Name = Convert.ToString(reader["Name"]),
                        Surname = Convert.ToString(reader["Surname"]),
                        Phone = Convert.ToString(reader["Phone"]),
                        Email = Convert.ToString(reader["Email"])
                    };
                }
                return user;
            }
        }

        public SqlCommand Get_sql_command(SqlConnection con, string str)
        {
            SqlCommand sql_command = con.CreateCommand();
            sql_command.CommandType = CommandType.StoredProcedure;
            sql_command.CommandText = str;
            return sql_command;
        }

        public SqlParameter Get_sql_parameter(string str, object obj, DbType typ)
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
