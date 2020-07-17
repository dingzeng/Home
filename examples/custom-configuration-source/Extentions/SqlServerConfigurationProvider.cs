using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace custom_configuration_source.Extentions
{
    public class SqlServerConfigurationProvider : ConfigurationProvider
    {
        public SqlServerConfigurationProvider(SqlServerConfigurationSource source)
        {
            Source = source;
        }

        public SqlServerConfigurationSource Source { get; }

        public override void Load()
        {
            using (SqlConnection conn = new SqlConnection(this.Source.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT [Key], [Value] FROM [dbo].[{this.Source.TableName}]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var key = reader["Key"].ToString();
                            var value = reader["Value"].ToString();
                            this.Data.Add(key, value);
                        }
                    }
                }
            }
        }
    }
}
