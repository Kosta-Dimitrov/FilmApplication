using System.Collections.Generic;
using FilmApplication.Models.Actors;
using FilmApplication.Models.Comments;

namespace FilmApplication.Models.Films
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
