using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Doctor
    {
        [Required] //Should be [Key] if a database was connected
        public int doctorId {get; set;}

        [Required]
        public string name { get; set; }

        [Required]
        public string department {get; set;}
    }
}