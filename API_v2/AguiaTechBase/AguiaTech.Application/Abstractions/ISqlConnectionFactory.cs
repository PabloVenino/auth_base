using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguiaTech.Application.Abstractions
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection();
        void CloseConnection(SqlConnection connection);
    }
}
