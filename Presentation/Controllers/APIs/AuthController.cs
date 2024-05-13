using Application.Abstractions.Implementations;
using Application.Abstractions.Interfaces;
using Application.DTOs;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Presentation.Models;
using System.Drawing.Printing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Presentation.Controllers.APIs;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private IUserRepo _userRepo;
    private IConfiguration _config;

    public AuthController(IUserRepo userRepo,
        IConfiguration config)
    {
        _userRepo = userRepo;
        _config = config;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO request)
    {
        try
        {
            var user = _userRepo.Get(request.Email, request.Password);
            return Ok(new ResponseModel { Data = new { User = user, Token = CreateToken(user) } });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(AddUserDTO request)
    {
        try
        {
            var res = await _userRepo.Add(request);
            return Ok(new ResponseModel { Message = "User registered successfully.", Data = new { UserId = res } });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
        }
    }

    private string CreateToken(GetUserDTO user)
    {

        List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(user)),
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _config.GetSection("SecretKeys:JWT").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

