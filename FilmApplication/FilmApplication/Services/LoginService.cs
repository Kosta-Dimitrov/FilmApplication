using FilmApplication.Identity;
using FilmApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FilmApplication.Services
{
    public class LoginService : ILoginService
    {
        private FilmContext dbContext;
        public LoginService(FilmContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User Login(UserDto model)
            =>dbContext.Users
            .Include("Role")
            .FirstOrDefault(u => u.Username == model.Username
                              && u.PasswordHash == model.Password);
    }
}
