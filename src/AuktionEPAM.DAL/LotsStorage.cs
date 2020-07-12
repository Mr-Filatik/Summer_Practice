using AuktionEPAM.ENTITY;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Interfaces;
using System.Configuration;

namespace AuktionEPAM.DAL
{
    public class LotsStorage : Interfaces.ILotsStorage
    {
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\G\src\AuktionEPAM.DAL\App_Data\DataBase.mdf;Integrated Security=True";
        UsersStorage usersStorage = new UsersStorage();
        public void AddLot(Lot lot)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand sql_command = Get_sql_command(connection, "dbo.Add_lot");
                sql_command.Parameters.Add(Get_sql_parameter("v1", lot.Id_creator, DbType.Int32));
                sql_command.Parameters.Add(Get_sql_parameter("v2", lot.Name, DbType.String));
                sql_command.Parameters.Add(Get_sql_parameter("v3", lot.Start_price, DbType.Int32));
                sql_command.Parameters.Add(Get_sql_parameter("v4", lot.Start_time, DbType.DateTime));
                sql_command.Parameters.Add(Get_sql_parameter("v5", lot.Status, DbType.Boolean));
                connection.Open();
                sql_command.ExecuteNonQuery();
            }
        }

        public ICollection<Lot> SelectAllLots()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand sql_command = Get_sql_command(connection, "dbo.All_Lots");
                sql_command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                var reader = sql_command.ExecuteReader();
                List<Lot> lots = new List<Lot>();
                while (reader.Read())
                {
                    lots.Add(new Lot()
                    {
                        Id_lot = Convert.ToInt32(reader.GetValue(0)),
                        Id_creator = Convert.ToInt32(reader.GetValue(1)),
                        Name = Convert.ToString(reader.GetValue(2)),
                        Start_price = Convert.ToInt32(reader.GetValue(3)),
                        Start_time = Convert.ToDateTime(reader.GetValue(4)),
                        Status = Convert.ToBoolean(reader.GetValue(5)),
                        Creator = usersStorage.GetInfoUser(Convert.ToInt32(reader.GetValue(1)))
                    });
                }
                return lots;
            }
        }

        public ICollection<Lot> SelectMyLots(int id_user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand sql_command = Get_sql_command(connection, "dbo.My_Lots");
                //sql_command.CommandType = System.Data.CommandType.StoredProcedure;
                sql_command.Parameters.Add(Get_sql_parameter("v1", id_user, DbType.Int32));
                connection.Open();
                var reader = sql_command.ExecuteReader();
                List<Lot> lots = new List<Lot>();
                while (reader.Read())
                {
                    lots.Add(new Lot()
                    {
                        Id_lot = Convert.ToInt32(reader.GetValue(0)),
                        Id_creator = Convert.ToInt32(reader.GetValue(1)),
                        Name = Convert.ToString(reader.GetValue(2)),
                        Start_price = Convert.ToInt32(reader.GetValue(3)),
                        Start_time = Convert.ToDateTime(reader.GetValue(4)),
                        Status = Convert.ToBoolean(reader.GetValue(5)),
                        Creator = usersStorage.GetInfoUser(Convert.ToInt32(reader.GetValue(1)))
                    });
                }
                return lots;
            }
        }

        public void DeleteLot(int id_lot)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand sql_command = Get_sql_command(connection, "dbo.Delete_lot");
                sql_command.Parameters.Add(Get_sql_parameter("v1", id_lot, DbType.Int32));
                connection.Open();
                sql_command.ExecuteReader();
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
