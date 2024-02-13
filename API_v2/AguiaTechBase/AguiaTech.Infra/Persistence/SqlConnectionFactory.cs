using AguiaTech.Application.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguiaTech.Infra.Persistence
{
    internal sealed class SqlConnectionFactory(IConfiguration configuration) : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration = configuration;

        public SqlConnection CreateConnection()
        {
            string connectionString = _configuration?["ConnectionStrings:Connection"] ?? "";
            
            return new SqlConnection(connectionString);
        }

        public void CloseConnection(SqlConnection connection)
        {
            connection.Close();
        }
    }
}
