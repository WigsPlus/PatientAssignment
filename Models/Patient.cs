using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Patient
    {
        [Required]
        public string name { get; set; }    
        [Required]
        public int SSN { get; set; }
    }
}