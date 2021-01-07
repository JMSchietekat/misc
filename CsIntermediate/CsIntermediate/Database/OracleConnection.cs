using System;

namespace CsIntermediate.Database
{
    public class OracleConnection : DbConnection
    {
        public OracleConnection(string connectionString) : base(connectionString)
        {
        }

        public override void Open()
        {
            Console.WriteLine("Open Oracle database connection");
        }

        public override void Close()
        {
            Console.WriteLine("Close Oracle database connection");
        }
    }
}