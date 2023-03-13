using FilmApplication.Identity;

namespace FilmApplication.Services.Interfaces
{
    public interface ILoginService
    {
        User Login(UserDto model);
    }
}
