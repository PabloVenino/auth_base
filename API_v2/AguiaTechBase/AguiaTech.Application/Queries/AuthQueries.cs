using AuthBase.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguiaTech.Application.Queries;


public record UserGetByIdQuery : IRequest<UserModel>
{
    public required Guid Id { get; init; }
}

public record UsersGetQuery : IRequest<List<UserModel>>
{
    public required Guid[] Id { get; init; }
}
