namespace CinemaApp.Common
{
    public static class EntityValidationConstants
    {
        public static class Movie
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 50;
            public const int GenreMinLength = 3;
            public const int GenreMaxLength = 20;
            public const int DirectorMinLength = 3;
            public const int DirectorMaxLength = 80;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 250;
        }

        public static class Cinema
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int LocationMinLength = 3;
            public const int LocationMaxLength= 85;
        }
    }
}
