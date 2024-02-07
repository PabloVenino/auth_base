using AuthBase.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguiaTech.Application.Queries;

public record GetUserAuthCode : IRequest<List<string>>;
public record DoLogin : IRequest;
public record UserData : IRequest<List<UserModel>>;

