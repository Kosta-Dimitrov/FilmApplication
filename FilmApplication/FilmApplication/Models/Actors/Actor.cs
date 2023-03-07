using System;
using System.Collections.Generic;
using FilmApplication.Models.Films;
namespace FilmApplication.Models.Actors
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Film> Films { get; set; }
    }
}
