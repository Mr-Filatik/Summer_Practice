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
        public int GetLog(string log)
        {
            using (var connection = new SqlConnection(Function.connectionString))
            {
                SqlCommand sql_command = Function.Get_sql_command(connection, "dbo.Get_log");
                sql_command.Parameters.Add(Function.Get_sql_parameter("v1", log, DbType.String));
                connection.Open();
                var reader = sql_command.ExecuteReader();
                int user = 0;
                while (reader.Read())
                {
                    user = Convert.ToInt32(reader.GetValue(0));
                }
                return Convert.ToInt32(user);
            }
        }
        public int GetPas(string log, string pas)
        {
            using (var connection = new SqlConnection(Function.connectionString))
            {
                SqlCommand sql_command = Function.Get_sql_command(connection, "dbo.Get_pas");
                sql_command.Parameters.Add(Function.Get_sql_parameter("v1", log, DbType.String));
                sql_command.Parameters.Add(Function.Get_sql_parameter("v2", pas, DbType.String));
                connection.Open();
                var reader = sql_command.ExecuteReader();
                int user = 0;
                while (reader.Read())
                {
                    user = Convert.ToInt32(reader.GetValue(0));
                }
                return Convert.ToInt32(user);
            }
        }
        public User GetInfoUser(int id_user)
        {
            using (var connection = new SqlConnection(Function.connectionString))
            {
                SqlCommand sql_command = Function.Get_sql_command(connection, "dbo.Get_Info_User");
                sql_command.Parameters.Add(Function.Get_sql_parameter("v1", id_user, DbType.Int32));
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
    }
}
