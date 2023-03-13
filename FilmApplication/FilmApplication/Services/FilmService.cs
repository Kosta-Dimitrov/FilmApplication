using System.Linq;
using System.Collections.Generic;
using FilmApplication.Models.Films;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FilmApplication.Models.QueryObjects;
using FilmApplication.Services.Interfaces;

namespace FilmApplication.Services
{
    public class FilmService : IFilmService
    {
        private FilmContext context;
        public FilmService(FilmContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task Add(FilmDto model)
        {
            this.context.Films.Add(new Film
            {
                Description = model.Description,
                Year = model.Year,
                Name = model.Name,
                Duration = model.Duration,
                ImageUrl = model.ImageUrl,
                Id = model.Id
            });
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Film filmToDelete = await this.GetById(id);
            if (filmToDelete != null)
            {
                this.context.Films.Remove(filmToDelete);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<Film> GetById(int id)
            => await this.context.Films.FirstOrDefaultAsync(f => f.Id == id);

        public async Task<List<Film>> GetAllFilms(SearchFilmQuery searchFilmQuery)
        {
            var allFilms=this.context.Films.AsQueryable();
            if (searchFilmQuery.name != null)
            {
                allFilms = allFilms.Where(f => f.Name.ToLower().Contains(searchFilmQuery.name.ToLower()));
            }
            if (searchFilmQuery.minLongevity != null)
            {
                allFilms=allFilms.Where(f=>f.Duration>=searchFilmQuery.minLongevity);
            }
            return await allFilms.ToListAsync();
        }

        public async Task Update(int id,FilmDto model)
        {
            var film = await this.context.Films.FirstOrDefaultAsync(f => f.Id == id);
            film.Description = model.Description;
            film.Year = model.Year;
            film.Name = model.Name;
            film.Duration = model.Duration;
            film.ImageUrl=model.ImageUrl;
            await context.SaveChangesAsync();
        }
    }
}
