using AguiaTech.Application.Abstractions;
using AuthBase.Core.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ObjectiveC;

namespace AguiaTech.Application.Queries;

internal class AuthQueryHandler(ISqlConnectionFactory sqlConnection) : IRequestHandler<UserData, List<UserModel>>
{
    private readonly ISqlConnectionFactory _sqlConnection = sqlConnection;

    public async Task<List<UserModel>> Handle(UserData entity, CancellationToken cancellation)
    {
        await using SqlConnection connection = _sqlConnection.CreateConnection();
        try
        {
            var userData = await connection.QueryAsync<UserModel>(sql: "SELECT * FROM [dbo].[users]", commandType: System.Data.CommandType.Text);
            return userData.ToList();
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

    //public async Task<List<string>> Handle(GetUserAuthCode request, CancellationToken cancellationToken)
    //{
    //    await using SqlConnection connection = _sqlConnection.CreateConnection();
    //    var userData = await connection.QueryAsync<string>("proc");
    //    return userData.ToList();
    //}

    //public async Task Handle(DoLogin request, CancellationToken cancellationToken)
    //{
    //    await using SqlConnection connection = _sqlConnection.CreateConnection();
    //    var userData = await connection.QueryAsync<string>("proc");
    //    return;
    //}

}
