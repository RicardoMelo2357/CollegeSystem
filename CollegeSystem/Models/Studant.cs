using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.Models
{
    public class Studant
    {
        public int StudantId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string BirthDay { get; set; }
        [Required]
        public long RegistrationNumber { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public Teacher Course { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}