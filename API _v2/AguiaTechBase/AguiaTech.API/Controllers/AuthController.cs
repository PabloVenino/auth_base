using AguiaTech.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AguiaTech.API;

[Route("v1/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Login()
    {
        try
        {
            var result = await _authService.Login();

            if (result is not null)
                return true ? Ok(result) : BadRequest(result);
            else
                return BadRequest("kk deu erro");
        }
        catch (Exception ex)
        {
            // TODO: Log exception;
            return StatusCode(500, "Infelizmente houve um erro inesperado, tente novamente mais tarde.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> RefreshToken(string token)
    {
        try
        {

            return Ok();
        }
        catch (Exception ex)
        {
            // TODO: Log exception;
            return StatusCode(500, "Infelizmente houve um erro inesperado, tente novamente mais tarde.");
        }
    }
}
