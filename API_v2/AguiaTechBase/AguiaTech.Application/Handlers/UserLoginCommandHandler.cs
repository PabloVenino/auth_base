using AguiaTech.Application.Abstractions;
using AguiaTech.Application.Commands;
using AuthBase.Core.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace AguiaTech.Application.Handlers;

internal class AuthQueryCommands(ISqlConnectionFactory sqlConnection, IMediator mediator) : IRequestHandler<UserLoginCommand, List<UserModel>>
{
    private readonly ISqlConnectionFactory _sqlConnection = sqlConnection;
    private readonly IMediator _mediator = mediator;

    public async Task<List<UserModel>> Handle(UserLoginCommand entity, CancellationToken cancellation)
    {
        await using SqlConnection connection = _sqlConnection.CreateConnection();
        try
        {
            return (List<UserModel>) await connection.QueryAsync<UserModel>(
                "user_select_by_login",
                param: new { entity.Login, entity.Password },
                commandType: System.Data.CommandType.StoredProcedure);

            //await _mediator.Publish(userData, cancellation);

            //return userData.ToList();
            //return await Task.FromResult(userData.ToList());
        }
        catch (Exception)
        {
            // TODO: Log exception
            return [];
        }
        finally
        {
            _sqlConnection.CloseConnection(connection);
        }
    }
}
