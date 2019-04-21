using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}