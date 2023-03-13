using FilmApplication.Identity;

namespace FilmApplication.JWT
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(UserDto user);
    }
}
