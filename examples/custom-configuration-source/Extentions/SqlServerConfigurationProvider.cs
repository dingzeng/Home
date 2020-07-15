using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace custom_configuration_source.Extentions
{
    public class SqlServerConfigurationProvider : IConfigurationProvider
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        public SqlServerConfigurationProvider(string connectionString, string tableName)
        {
            this._connectionString = connectionString;
            this._tableName = tableName;
        }

        public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
        {
            foreach (var item in earlierKeys)
            {
                yield return $"{parentPath}.{item}";
            }
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Set(string key, string value)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"UPDATE {this._tableName} SET Value = '{value}' WHERE Key = {key}";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool TryGet(string key, out string value)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT TOP 1 Value FROM {this._tableName} WHERE Key = '{key}'";
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        value = reader["Value"].ToString();
                        return true;
                    }
                    else
                    {
                        value = string.Empty;
                        return false;
                    }
                }
            }
        }
    }
}
