using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.Models
{
    public class StudantGrade
    {
        public int StudantGradeId { get; set; }
        [Required]
        public float Grade { get; set; }
        [Required]
        public int StudantId { get; set; }
        public Studant Studant { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}