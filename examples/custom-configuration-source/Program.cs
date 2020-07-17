using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace custom_configuration_source
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=tcp:127.0.0.1,1433;Database=examples;User Id=sa;Password=Km666888;";
            string tableName = "custom-configuration-source";

            var configuration = new ConfigurationBuilder()
                .AddSqlServerConfiguration(connectionString, tableName)
                .Build();

            Console.WriteLine(configuration["Hello"]);

            var section = configuration.GetSection("Logging");
            Console.WriteLine(section["Level"]);

            Console.ReadLine();
        }
    }
}
