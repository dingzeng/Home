using custom_configuration_source.Extentions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.Configuration
{
    public static class SqlServerConfigurationExtensions
    {
        public static IConfigurationBuilder AddSqlServerConfiguration(this IConfigurationBuilder builder, string connectionString, string tableName)
        {
            var source = new SqlServerConfigurationSource(connectionString, tableName);
            return builder.Add(source);
        }
    }
}
