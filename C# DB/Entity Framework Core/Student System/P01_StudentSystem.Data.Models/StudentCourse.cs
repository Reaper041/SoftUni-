using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        // TODO: Relations

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set;}

        public virtual Course Course { get; set; }
    }
}
