namespace FilmApplication.Models.Films
{
    public class FilmDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }

    }
}
