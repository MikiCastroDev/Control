using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Control.Core.Domain.Services
{
    public class TokenService
    {
        string _secretKey;
        int _normalExpired;

        public TokenService(string secretKey, int normalExpired)
        {
            _secretKey = secretKey;
            _normalExpired = normalExpired;
        }

        public string GenerateToken(Guid userId)
        {
            byte[] key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_normalExpired),
            SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
