using FilmApplication.Models.Films;
using FilmApplication.Models.QueryObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmApplication.Services.Interfaces
{
    public interface IFilmService
    {
        Task Add(FilmDto model);
        Task Delete(int id);
        Task<Film> GetById(int id);
        Task<List<Film>> GetAllFilms(SearchFilmQuery searchFilmQuery);
        Task Update(int id, FilmDto model);
    }
}
