using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.JWT
{
    public class JWToken
    {
        private string _jwtPass;

        public JWToken()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("jwTokenConfig.json")
                .Build();

            var secretKey = configuration.GetSection("JwtSettings:SecretKey").Value;
            _jwtPass = secretKey;
        }





        public string GenerarTokenJWT(string usuario)
        {
            // Configurar la clave secreta
            var clave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtPass));

            // Crear las credenciales de seguridad con la clave secreta
            var credenciales = new SigningCredentials(clave, SecurityAlgorithms.HmacSha256);

            // Crear las reclamaciones (claims) del token
            var reclamaciones = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Configurar la configuración del token JWT
            var configuracionToken = new JwtSecurityToken(
                "Felipe",
                usuario,
                reclamaciones,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credenciales
            );

            // Generar el token JWT
            var tokenJWT = new JwtSecurityTokenHandler().WriteToken(configuracionToken);

            return tokenJWT;
        }


    }
}
