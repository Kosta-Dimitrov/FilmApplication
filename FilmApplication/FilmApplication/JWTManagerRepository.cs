using FilmApplication.Identity;
using FilmApplication.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FilmApplication
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private IConfiguration iconfiguration;
        private LoginService loginService;
        public JWTManagerRepository(IConfiguration iconfiguration,LoginService loginService)
        {
            this.iconfiguration = iconfiguration;
            this.loginService = loginService;
        }
        public Tokens Authenticate(UserDto user)
        {
            User loggedUser=loginService.Login(user);
            if (loggedUser==null)
            {
                return null;
            }
            //after successfull login
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var roleValue = loggedUser.Role.Name;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, user.Username),
             new Claim(ClaimTypes.Role,roleValue) //?
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}
