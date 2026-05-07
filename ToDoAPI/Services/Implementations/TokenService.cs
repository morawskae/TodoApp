using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoAPI.Models;

namespace ToDoAPI.Services.Implementations
{
    public class TokenService
    {

        private readonly IConfiguration _config;
        private readonly string _secretKey;
        private readonly int _accessTokenExpiryMinute;

        public TokenService(IConfiguration config)
        {
            _config = config;
            _secretKey = _config["ApiSettings:Secret"];
            _accessTokenExpiryMinute = _config.GetValue<int>("\"ApiSettings:AccessTokenExpiryMinutes",60);
        }

        public string GenerateToken(User user)
        {
            var _claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var _creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var _token = new JwtSecurityToken(
                issuer: _config[_secretKey],
                audience: _config[_secretKey],
                claims: _claims,
                expires: DateTime.Now.AddMinutes(_accessTokenExpiryMinute),
                signingCredentials: _creds
                );

            return new JwtSecurityTokenHandler().WriteToken(_token);

        }

        //will continue
    }
}
