using System;
using System.Collections.Immutable;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using static System.Console;
using static System.Environment;

namespace CsDapper
{
    
    public class Farm
    {
        public int IdFarm { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");
            
            string[] lines = System.IO.File.ReadAllLines(@".env");

            var connectionString = GetEnvironmentVariable("sqlConnectionString");
            const string query = @"SELECT * FROM dbo.Farm WHERE IdStatus < 4;";

            using var connection = new SqlConnection(connectionString);
            
            var farms = connection.QueryAsync<Farm>(query).Result.ToImmutableArray();

            WriteLine(farms.Length);
            
            farms.ForEach(farm => WriteLine(farm.IdFarm + ": " + farm.Description + ": " + farm.CreatedDateTime));

        }
    }
}