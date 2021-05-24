using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Admission
    {   
        [Required]
        public string department { get; set; }
        
        [Required]
        public List<Doctor> doctorsAssociated { get; set; } 

        [Required]
        public Patient patientInAdmission { get; set; }
    }
}