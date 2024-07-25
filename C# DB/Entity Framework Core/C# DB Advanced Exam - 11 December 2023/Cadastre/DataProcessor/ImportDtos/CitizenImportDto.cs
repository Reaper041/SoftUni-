using System.ComponentModel.DataAnnotations;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class CitizenImportDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; } = null!;

        [Required]
        public string BirthDate { get; set; } = null!;

        [Required]
        public string MaritalStatus { get; set; } = null!;

        [Required]
        public int[] Properties { get; set; } = null!;
    }
}
