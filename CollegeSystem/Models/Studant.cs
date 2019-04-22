using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.Models
{
    public class Studant
    {
        public int StudantId { get; set; }
        [Required]
        public string StudantName { get; set; }
        [Required]
        public string BirthDay { get; set; }
        [Required]
        public long RegistrationNumber { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        //[Required]
        //public int SubjectId { get; set; }
        //public Subject Subject { get; set; }
    }
}