using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SharedLibrary.DataBase_and_more
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; 
        public const string AUDIENCE = "MyAuthClient"; 
        const string KEY = "mysupersecret_secretkey!1234567890abcdef";  
        public const int LIFETIME = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        public static void SetJwtCookie(HttpContext context, Guid userId, string role)
        {
            var token = GenerateJwtToken(userId, role); // Ваш метод генерации JWT

            var options = new CookieOptions
            {
                HttpOnly = true, // Защита от XSS
                Secure = true,    // Только HTTPS
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.Now.AddDays(30) // Срок действия

            };

            if (role != "userId") options.Expires = null;

            context.Response.Cookies.Append("jwt_token", token, options);
        }

        /*public static string GenerateJwtToken(Guid userId, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GetSymmetricSecurityKey().ToString()));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: ISSUER,
                audience: AUDIENCE,
                claims: new[] { new Claim(role, userId.ToString()) },
                *//*claims: claims,*//*
                expires: DateTime.Now.AddYears(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/

        public static string GenerateJwtToken(Guid userId, string role)
        {
            var securityKey = GetSymmetricSecurityKey(); // Используем напрямую, без преобразования в строку
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Role, role) // Стандартный тип для ролей
            };

            var token = new JwtSecurityToken(
                issuer: ISSUER,
                audience: AUDIENCE,
                claims: claims,
                expires: DateTime.Now.AddDays(LIFETIME), // Используем константу LIFETIME
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /*public static bool ValidateToken(string token, string role, out Guid userId)
        {
            userId = Guid.Empty;

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = GetSymmetricSecurityKey();

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key.ToString())),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = ISSUER,
                    ValidAudience = AUDIENCE,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == role).Value);
                

                return true;
            }
            catch
            {
                return false;
            }
        }*/

        public static bool ValidateToken(string token, out Guid userId)
        {
            userId = Guid.Empty;

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = GetSymmetricSecurityKey();

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key, // Используем ключ напрямую
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = ISSUER,
                    ValidAudience = AUDIENCE,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
