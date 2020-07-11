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
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\C#\AuktionEPAM\AuktionEPAM.DAL\App_Data\DataBase.mdf;Integrated Security=True";
        
        public void AddLot(Lot lot)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand sql_command = Get_sql_command(connection, "dbo.Add_lot");
                sql_command.Parameters.Add(Get_sql_parameter("v1", lot.Id_creator, DbType.Int32));
                sql_command.Parameters.Add(Get_sql_parameter("v2", lot.Name, DbType.String));
                sql_command.Parameters.Add(Get_sql_parameter("v3", lot.Start_price, DbType.Int32));
                sql_command.Parameters.Add(Get_sql_parameter("v4", lot.Start_time, DbType.DateTime));
                sql_command.Parameters.Add(Get_sql_parameter("v5", 0, DbType.Int32));
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
                    lots.Add(new Lot(Convert.ToInt32(reader.GetValue(0)),
                                      Convert.ToInt32(reader.GetValue(1)),
                                      Convert.ToString(reader.GetValue(2)),
                                      Convert.ToInt32(reader.GetValue(3)),
                                      Convert.ToDateTime(reader.GetValue(4)),
                                      Convert.ToBoolean(reader.GetValue(5)),
                                      Convert.ToInt32(reader.GetValue(6)),
                                      Convert.ToDateTime(reader.GetValue(7)),
                                      Convert.ToString(reader.GetValue(8)),
                                      Convert.ToString(reader.GetValue(9)),
                                      Convert.ToString(reader.GetValue(10)),
                                      Convert.ToString(reader.GetValue(11))
                                      ));
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
