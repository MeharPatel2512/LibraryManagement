using Library.Models.Request;
using Library.Models.Response;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.Middleware
{
    public class TokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<LoginUserResponse> GenerateToken(LoginUserModel.TokenGenerationModel tokenGenerationModel)
        {
            var claims = new[]
            {
                new Claim("UserId", tokenGenerationModel.UserId.ToString()),
                new Claim("Role", tokenGenerationModel.Role),
                new Claim(ClaimTypes.Email, tokenGenerationModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) 
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_config["Jwt:TokenExipryMinutes"])),
                signingCredentials: creds
            );

            string my_token = new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginUserResponse{
                UserId = tokenGenerationModel.UserId,
                Email = tokenGenerationModel.Email,
                Role = tokenGenerationModel.Role,
                Token = my_token,
                Expirytime = 30
            };
        }
    }
}