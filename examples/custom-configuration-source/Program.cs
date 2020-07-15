using System;
using Microsoft.Extensions.Configuration;

namespace custom_configuration_source
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=tcp:127.0.0.1,5433;Database=dotnetcoredemo;User Id=sa;Password=Km666888;";
            string tableName = "sys_config";

            var configuration = new ConfigurationBuilder()
                .AddSqlServerConfiguration(connectionString, tableName)
                .Build();

            // Write
            configuration["Hello"] = DateTime.Now.ToString();

            // READ
            Console.WriteLine(configuration["Hello"]);
            Console.ReadLine();
        }
    }
}
