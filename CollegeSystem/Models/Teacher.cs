using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public string BirthDay { get; set; }
        [Required]
        public float Salary { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}