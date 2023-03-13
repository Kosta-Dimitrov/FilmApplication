using FilmApplication.Identity;
using FilmApplication.Services.Interfaces;
using System;
using System.Linq;

using static FilmApplication.Validations.Constants.User;

namespace FilmApplication.Services
{
    public class RegisterService : IRegisterService
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
            if (String.IsNullOrEmpty(model.Username) || String.IsNullOrWhiteSpace(model.Username) || model.Username.Length < NameMinLength)
            {
                throw new ArgumentOutOfRangeException($"Username should be at least { NameMinLength } symbols");
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
            if (String.IsNullOrEmpty(model.Password) || String.IsNullOrWhiteSpace(model.Password) || model.Password.Length < PasswordMinLength)
            {
                throw new ArgumentOutOfRangeException($"Password should be at least { PasswordMinLength } symbols");
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
