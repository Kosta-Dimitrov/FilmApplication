using FilmApplication.Models.Actors;
using System.Threading.Tasks;

namespace FilmApplication.Services.Interfaces
{
    public interface IActorService
    {
        Task Add(ActorDto model);
        Task Delete(int id);
        Actor GetActorById(int id);
        Task AddActor(int id, ActorDto model);
    }
}
