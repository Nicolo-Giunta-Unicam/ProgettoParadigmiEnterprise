using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProgettoParadigmiEnterprise.Abstractions;
using ProgettoParadigmiEnterprise.Model;
using ProgettoParadigmiEnterprise.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProgettoParadigmiEnterprise.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtAuthenticationOption jwtAuthenticationOption;

        public JwtTokenService(IOptions<JwtAuthenticationOption> _jwtAuthenticationOption)
        {
            jwtAuthenticationOption = _jwtAuthenticationOption.Value;
        }

        public string GenerateToken(Utente _utente) {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _utente.nome),
                new Claim(ClaimTypes.Email, _utente.email),
                new Claim(ClaimTypes.Role, _utente.ruolo.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAuthenticationOption.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securtyyoken = new JwtSecurityToken(
                jwtAuthenticationOption.Issuer,
                null,
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securtyyoken);
        }
    }
}
