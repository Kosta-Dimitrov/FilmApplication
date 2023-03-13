using FilmApplication.Identity;

namespace FilmApplication.Services.Interfaces
{
    public interface IRegisterService
    {
        bool Register(UserDto model);
    }
}
