using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InsuranceAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace InsuranceAPI.Tools
{
    public static class Token
    {
        public static string CreateToken(Insurance insurance, string tokenKey)
        {
            List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, insurance.UserName)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: cred
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string CreateToken(Expert expert, string tokenKey)
        {
            List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, expert.UserName)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: cred
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string? DecodeToken(string token, string tokenKey)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(tokenKey);
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                SecurityToken securityToken;
                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

                var nameClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

                return nameClaim?.Value;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}