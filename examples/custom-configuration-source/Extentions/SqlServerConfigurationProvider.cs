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
            var data = Source.QueryAll();
            foreach (var item in data)
            {
                this.Data.Add(item.Key, item.Value);
            }
        }
    }
}
