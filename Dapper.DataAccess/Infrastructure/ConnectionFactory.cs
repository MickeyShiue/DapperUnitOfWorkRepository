using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.DataAccess.Infrastructure
{
    public class ConnectionFactory
    {
        public ConnectionFactory()
        {

        }

        public DbConnection CreateDbConn()
        {
            return new SqlConnection(GetConnectionString());
        }

        private string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["NorthwndConnectionString"].ConnectionString;
        }
    }
}
