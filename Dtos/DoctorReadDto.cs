using System.ComponentModel.DataAnnotations;

namespace Hospital.Dtos
{
    public class DoctorReadDto
    {
        
        public int DoctorId {get; set;}

        public string Name { get; set; }

        public string Department {get; set;}
    }
}