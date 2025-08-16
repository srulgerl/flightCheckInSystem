using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class DWConnection
    {
        public string ConnectionString { get; }

        public DWConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
