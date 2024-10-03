using CinemaApp.Web.ViewModels.Cinema;
using System.ComponentModel.DataAnnotations;

using static CinemaApp.Common.EntityValidationConstants.Movie;

namespace CinemaApp.Web.ViewModels.Movie
{
    public class AddMovieToCinemaInputModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        public IList<CinemaCheckBoxInputModel> Cinemas { get; set; } = 
            new List<CinemaCheckBoxInputModel>();
    }
}
