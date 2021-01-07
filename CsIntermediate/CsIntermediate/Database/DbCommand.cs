using System;

namespace CsIntermediate.Database
{
    public class DbCommand
    {
        private DbConnection _dbConnection;
        
        public DbCommand(DbConnection dbConnection, string instruction)
        {
            if (dbConnection == null || instruction == null)
                throw new ArgumentNullException();

            _dbConnection = dbConnection;

            Execute(instruction);
        }

        private void Execute(string instruction)
        {
            _dbConnection.Open();
            Console.WriteLine($"Running: {instruction}");
            _dbConnection.Close();
        }
    }
}