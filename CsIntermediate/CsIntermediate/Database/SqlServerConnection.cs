using System;

namespace CsIntermediate.Database
{
    public class SqlServerConnection : DbConnection
    {
        public SqlServerConnection(string connectionString) : base(connectionString)
        {
        }

        public override void Open()
        {
            Console.WriteLine("Open SQL Server database connection");
        }

        public override void Close()
        {
            Console.WriteLine("Open SQL Server database connection");
        }
    }
}