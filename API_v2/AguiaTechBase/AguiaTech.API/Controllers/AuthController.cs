using AguiaTech.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AguiaTech.API;

[Route("v1/auth")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Login([Required] string username, [Required] string password)
    {
        try
        {
            var query = new UserData { Login = username, Password = password };
            
            await _mediator.Send(query);

            return Ok();
        }
        catch (Exception ex)
        {
            _ = ex.Message;
            // TODO: Log exception;
            return StatusCode(500, "Infelizmente houve um erro inesperado, tente novamente mais tarde.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> RefreshToken(string token)
    {
        try
        {
            return Ok(token);
        }
        catch (Exception ex)
        {
            _ = ex.Message;
            // TODO: Log exception;
            return StatusCode(500, "Infelizmente houve um erro inesperado, tente novamente mais tarde.");
        }
    }
}
