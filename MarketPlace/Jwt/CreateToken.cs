using Microsoft.IdentityModel.Tokens;
using Models;
using Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace MarketPlace.Jwt
{
    public class CreateToken
    {

        IConfiguration _configuration;

        public CreateToken(IConfiguration configuration)
        {
     
            _configuration = configuration;


        }


        public static object GenerateToken(string user,IConfiguration con)
        {

           
            var jwt = con.GetSection("Jwt").Get<Jwt>();

        var claims = new[]
        {

                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub,jwt.JWT_SECR),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Usuario" ,user),
            };

        var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.JWT_SECRET_KEY));
        var singIn = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            jwt.JWT_ISSUER_TOKEN,
            jwt.JWT_AUDIENCE_TOKEN,
            claims,
            expires: DateTime.Now.AddMinutes(double.Parse(jwt.JWT_EXPIRE_MINUTES)),
            signingCredentials: singIn

            );
            return token;
             
        }

    }
}
