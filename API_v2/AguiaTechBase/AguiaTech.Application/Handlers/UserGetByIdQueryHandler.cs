using AguiaTech.Application.Abstractions;
using AguiaTech.Application.Commands;
using AguiaTech.Application.Queries;
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


internal class UserGetByIdQueryHandler(ISqlConnectionFactory sqlConnection, IMediator mediator) : IRequestHandler<UserGetByIdQuery, UserModel>
{
    private readonly ISqlConnectionFactory _sqlConnection = sqlConnection;
    private readonly IMediator _mediator = mediator;

    public async Task<UserModel?> Handle(UserGetByIdQuery entity, CancellationToken cancellation)
    {
        await using SqlConnection connection = _sqlConnection.CreateConnection();
        try
        {
            return new UserModel()
            {
                Id = entity.Id,
                UserInfosId = 1,
                UserCredentialId = new Guid(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };
            // TODO: Criar logica para GetUserById

            //return (List<UserModel>)await connection.QueryAsync<UserModel>(
            //    "user_select_by_login",
            //    param: new { entity.Login, entity.Password },
            //    commandType: System.Data.CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            _ = ex.Message;
            // TODO: Log exception
            return null;
        }
        finally
        {
            _sqlConnection.CloseConnection(connection);
        }
    }
}

