using System;
using Microsoft.VisualBasic;

namespace CsIntermediate.Database
{
    public abstract class DbConnection
    {
        private string _connectionString;

        public string ConnectionString
        {
            get { return _connectionString;}
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();

                _connectionString = value;
            }
        }

        public TimeSpan Timeout { get; set; }

        protected DbConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public abstract void Open();
        public abstract void Close();
    }
}