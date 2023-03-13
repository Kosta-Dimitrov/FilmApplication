namespace FilmApplication.Validations
{
    public class Constants
    {
        public class Film
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 35;
            public const int MinYear = 1899;
            public const int MinDescriptionLength = 5;
            public const int MaxDescriptionLength = 250;
            public const int MaxDuration = 1234;
        }

        public class Actor
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 35;
        }
    }
}
