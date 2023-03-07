using FilmApplication.Identity;
using FilmApplication.Models.Films;

namespace FilmApplication.Models.Comments
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public Film Film { get; set; }
        public int FilmId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
