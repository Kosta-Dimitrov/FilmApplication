using FilmApplication.Identity;
using System;
using System.Linq;

namespace FilmApplication.Services
{
    public class RegisterService
    {
        private FilmContext dbContext;

        public RegisterService(FilmContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private bool CheckUsername(UserDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }
            if (String.IsNullOrEmpty(model.Username) || String.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 5)
            {
                throw new ArgumentOutOfRangeException("Username should be at least 5 symbols");
            }
            if (IsRegistered(model))
            {
                throw new ArgumentException($"Username {model.Username} already exists");
            }
            return true;
        }
        private bool CheckPassword(UserDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }
            if (String.IsNullOrEmpty(model.Password) || String.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 5)
            {
                throw new ArgumentOutOfRangeException("Password should be at least 5 symbols");
            }
            return true;
        }

        private bool IsRegistered(UserDto model)
        {
            return dbContext.Users.Any(u => u.Username == model.Username);
        }
        public bool Register(UserDto model)
        {
            if (CheckPassword(model) && CheckUsername(model))
            {
                dbContext.Users.Add(new User
                {
                    Username = model.Username,
                    PasswordHash = model.Password,
                    RoleId=2
                });
                dbContext.SaveChanges();
            }
            return true;
        }
    }
}
