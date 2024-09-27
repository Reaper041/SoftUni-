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
    }
}
