using AuthBase.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguiaTech.Application.Commands;


public record UserLoginCommand() : IRequest<List<UserModel>>
{
    public required string Login { get; init; }
    public required string Password { get; init; }
}

public record RefreshTokenCommand : IRequest<string>
{
    public required string Token { get; init; }
}

public record ForgotPasswordCommand : IRequest
{
    public required string Email { get; init; }
    public required string AuthCode { get; init; }
}

public record SendEmailCode : IRequest
{
    public required string Email { get; init; }
}

public record ResetPasswordCommand : IRequest
{
    public required string Code { get; init; }
    public required string NewPassword { get; init; }
}