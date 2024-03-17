using AssignmentXCompany.Services.Abstract;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AssignmentXCompany.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken()
        {
            var _securityKeyStringValue = _configuration.GetSection("JwtSettings")["SecretKey"]!;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKeyStringValue));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var issuer = _configuration.GetSection("JwtSettings")["Issuer"]!;
            var audience = _configuration.GetSection("JwtSettings")["Audience"]!;

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, "test@mail.com")
            };

            var expires = DateTime.Now.AddHours(1);

            var token = new JwtSecurityToken(
                claims: authClaims,
                expires: expires,
                signingCredentials: credentials,
                issuer: issuer,
                audience: audience
                );
            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }
}
