using FilmApplication.Models.Films;
using FilmApplication.Models.QueryObjects;
using FilmApplication.Services;
using FilmApplication.Validations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmApplication.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController:ControllerBase
    {
        private FilmService filmService;
        private FilmValidator validator;
        public FilmController(FilmService filmService, FilmValidator validator)
        {
            this.filmService= filmService;
            this.validator=validator;
        }

        [MyAuthorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FilmDto model)
        {
            if (validator.Validate(model).IsValid)
            {
                await filmService.Add(model);
                return Ok();
            }
            return BadRequest();
        }

        [MyAuthorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await filmService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]SearchFilmQuery searchFilmQuery)
        {
            return Ok(await this.filmService.GetAllFilms(searchFilmQuery));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Film film=await this.filmService.GetById(id);
            if(film!=null)
            {
                return Ok(film);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("{id}")]
        [MyAuthorize]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] FilmDto model)
        {
            if (filmService.GetById(id) != null)
            {
                if(validator.Validate(model).IsValid)
                {
                    await filmService.Update(id,model);
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
