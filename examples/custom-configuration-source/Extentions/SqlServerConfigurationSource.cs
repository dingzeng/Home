using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace custom_configuration_source.Extentions
{
    public class SqlServerConfigurationSource : IConfigurationSource
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        public SqlServerConfigurationSource(string connectionString, string tableName)
        {
            this._connectionString = connectionString;
            this._tableName = tableName;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SqlServerConfigurationProvider(this);
        }

        public Dictionary<string, string> QueryAll()
        {
            var data = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT [Key], [Value] FROM [dbo].[{this._tableName}]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var key = reader["Key"].ToString();
                            var value = reader["Value"].ToString();
                            data.Add(key, value);
                        }
                    }
                }
            }
            return data;
        }
    }
}
