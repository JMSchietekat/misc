using Dapper;
using System.Data.SqlClient;
using System.Linq;
using static System.Console;
using static System.Environment;

namespace CsDapper
{
    
    public class Farm
    {
        public int IdFarm { get; }
        public string Description { get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");

            var connectionString = GetEnvironmentVariable("sqlConnectionString");
            const string query = @"SELECT IdFarm, Description FROM dbo.Farm WHERE IdStatus < 4;";

            using var connection = new SqlConnection(connectionString);
            
            var farms = connection.QueryAsync<Farm>(query).Result.ToList();

            WriteLine(farms.Count);
            
            farms.ForEach(farm => WriteLine(farm.IdFarm + ": " + farm.Description));

        }
    }
}