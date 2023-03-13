using FilmApplication.Models.Actors;
using FilmApplication.Services;
using FilmApplication.Validations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmApplication.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class ActorController:ControllerBase
    {
        private readonly ActorService actorService;
        private readonly ActorValidator actorValidator;

        public ActorController(ActorService actorService, ActorValidator actorValidator)
        {
            this.actorService= actorService;
            this.actorValidator= actorValidator;
        }


        [HttpPost]
        [MyAuthorize]
        public async Task<IActionResult> Add([FromBody] ActorDto model)
        {
            if (actorValidator.Validate(model).IsValid)
            {
                await this.actorService.Add(model);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [MyAuthorize]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.actorService.Delete(id);
            return Ok();
        }

        [HttpPut]
        [MyAuthorize]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody]ActorDto model)
        {
            var actor = this.actorService.GetActorById(id);
            if (actor!=null)
            {
                if (actorValidator.Validate(model).IsValid)
                {
                    await this.actorService.AddActor(id,model);
                }
            }
            return BadRequest();
        }
    }
}
