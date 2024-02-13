using AguiaTech.Application.Abstractions;
using AguiaTech.Application.Commands;
using AuthBase.Core.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguiaTech.Application.Handlers;


internal class RefreshTokenCommandHandler(ISqlConnectionFactory sqlConnection, IMediator mediator) : IRequestHandler<RefreshTokenCommand, string>
{
    private readonly ISqlConnectionFactory _sqlConnection = sqlConnection;
    private readonly IMediator _mediator = mediator;

    public async Task<string> Handle(RefreshTokenCommand entity, CancellationToken cancellation)
    {
        await using SqlConnection connection = _sqlConnection.CreateConnection();
        try
        {
            return "ahhh novo token aq :)";
            // TODO: Criar logica para RefreshToken
            //return (List<UserModel>)await connection.QueryAsync<UserModel>(
            //    "user_select_by_login",
            //    param: new { entity.Login, entity.Password },
            //    commandType: System.Data.CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            _ = ex.Message;
            // TODO: Log exception
            return "";
        }
        finally
        {
            _sqlConnection.CloseConnection(connection);
        }
    }
}

