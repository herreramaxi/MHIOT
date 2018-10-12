using MHIOT.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MHIOT.Database
{
    public class TemperatureDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public void Insert(TemperatureData data)
        {
            data.Date = DateTime.UtcNow;
            string query = "INSERT INTO dbo.Temperature(Temperature, Humidity, Date) " +
                           "VALUES (@Temperature, @Humidity, @Date) ";

            // create connection and command
            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@Temperature", SqlDbType.Decimal).Value = data.Temperature;
                cmd.Parameters.Add("@Humidity", SqlDbType.Decimal).Value = data.Humidity;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = data.Date;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public List<TemperatureData> GetAll()
        {            
            var result = new List<TemperatureData>();

            var date = DateTime.UtcNow;
            string query = "SELECT Id, Temperature, Humidity, Date FROM dbo.Temperature " +
                           "ORDER BY Date DESC";

            // create connection and command
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           var data = new TemperatureData();
                            data.Id = reader.GetInt32(0);
                            data.Temperature = reader.GetDecimal(1);
                            data.Humidity = reader.GetDecimal(2);
                            data.Date = reader.GetDateTime(3);

                            result.Add(data);
                        }

                        reader.Close();
                    }
                }

                cn.Close();
            }

            return result;
        }
    }
}