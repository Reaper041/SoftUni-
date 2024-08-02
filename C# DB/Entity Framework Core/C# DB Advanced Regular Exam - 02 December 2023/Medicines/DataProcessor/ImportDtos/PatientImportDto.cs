using System.ComponentModel.DataAnnotations;

namespace Medicines.DataProcessor.ImportDtos
{
    public class PatientImportDto
    {
        [Required]
        [MinLength(GlobalConstants.GlobalConstants.PatientFullNameMinLength)]
        [MaxLength(GlobalConstants.GlobalConstants.PatientFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        public string AgeGroup { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        public int[] Medicines { get; set; } = null!;
    }
}
