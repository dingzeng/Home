using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace custom_configuration_source.Extentions
{
    public class SqlServerConfigurationSource : IConfigurationSource
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        public SqlServerConfigurationSource(string connectionString,string tableName)
        {
            this._connectionString = connectionString;
            this._tableName = tableName;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SqlServerConfigurationProvider(this._connectionString, this._tableName);
        }
    }
}
