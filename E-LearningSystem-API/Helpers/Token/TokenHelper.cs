using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_LearningSystem_API.Helpers.Token
{
    public  static class TokenHelper
    {

        public static string GenerateJWTToken(string userId, string roleName)
        {
        
            var JWTTokenHandler = new JwtSecurityTokenHandler();
           
            string secrect = "LongPrimarySecrectForPasswordManageApplicationASPCoreModuleForDevelopementPurppose";
            var tokenBytesKey = Encoding.UTF8.GetBytes(secrect);
           
            var descriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(2),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId",userId),
                    new Claim("Role",roleName)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenBytesKey), SecurityAlgorithms.HmacSha256Signature)
            };
        
            var tokenJson = JWTTokenHandler.CreateToken(descriptor);
          
            var token = JWTTokenHandler.WriteToken(tokenJson);
            return token;
        }
        public static string IsValidToken(string token)
        {
            try
            {
                var JWTTokenHandler = new JwtSecurityTokenHandler();
                string secrect = "LongPrimarySecrectForPasswordManageApplicationASPCoreModuleForDevelopementPurppose";
                var tokenBytesKey = Encoding.UTF8.GetBytes(secrect);

                var tokenValidatorParms = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenBytesKey),
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }; var tokenBase = JWTTokenHandler.ValidateToken(token, tokenValidatorParms, out SecurityToken validatedToken);

                return "Valid";
            }

            catch (Exception ex)
            {
                return $"InValid {ex.Message}";
            }

        }
    }
}
