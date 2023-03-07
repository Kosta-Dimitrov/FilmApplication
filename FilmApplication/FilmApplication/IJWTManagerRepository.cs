using FilmApplication.Identity;

namespace FilmApplication
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(UserDto user);
    }
}
