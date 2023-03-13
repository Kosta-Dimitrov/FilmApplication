using FilmApplication.Models.Actors;
using FilmApplication.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApplication.Services
{
    public class ActorService : IActorService
    {
        private readonly FilmContext context;

        public ActorService(FilmContext filmContext)
        {
            this.context = filmContext;
        }

        public async Task Add(ActorDto model)
        {
            this.context.Actors.Add(new Actor
            {
                DateOfBirth = model.dateOfBirth,
                Name = model.Name,
            });
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var actor = this.context.Actors.FirstOrDefault(a=>a.Id==id);
            if (actor != null)
            {
                this.context.Actors.Remove(actor);
            }
            await this.context.SaveChangesAsync();
        }

        public Actor GetActorById(int id)
            => this.context.Actors.FirstOrDefault(a => a.Id == id);

        public async Task AddActor(int id,ActorDto model)
        {
            var actor = GetActorById(id);
            actor.DateOfBirth = model.dateOfBirth;
            actor.Name = model.Name;
            await this.context.SaveChangesAsync();
        }
    }
}
