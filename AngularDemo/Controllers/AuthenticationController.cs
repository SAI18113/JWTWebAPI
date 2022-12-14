using AngularDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AngularDemo.Controllers;
[Route("[controller]")]
[ApiController]


public class AuthenticationController : Controller
{
    private readonly IUserService _service;
    private readonly IConfiguration _configuration;
    public AuthenticationController(IUserService service, IConfiguration configuration)
    {
        _service = service;
        _configuration = configuration;
    }
    [HttpGet]
    [Route("login")]
    public async Task<IActionResult> Login(string Email, string Password)
    {
        if(await _service.IsValidUser(Email, Password))
        {
            var _user = _service.Get(Email);
            var authClaims = new List<Claim>();
            authClaims.Add(new Claim("Email", Email));
            authClaims.Add(new Claim(ClaimTypes.NameIdentifier, Email));
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });

        }
        return Unauthorized();
    }
}
