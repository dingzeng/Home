using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace custom_configuration_source.Extentions
{
    public class SqlServerConfigurationSource : IConfigurationSource
    {
        public string ConnectionString { get; }
        public string TableName { get; }

        public SqlServerConfigurationSource(string connectionString, string tableName)
        {
            this.ConnectionString = connectionString;
            this.TableName = tableName;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SqlServerConfigurationProvider(this);
        }
    }
}
