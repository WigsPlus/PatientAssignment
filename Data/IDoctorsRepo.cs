using System.Collections.Generic;
using Hospital.Models;

namespace Hospital.Data
{
    //Decoupling the code -- Easier to change down the line
    public interface IDoctorsRepo
    {

        IEnumerable<Doctor> GetHospitalDoctors();

        Doctor GetDoctorById(int id); 
        void CreateDoctor(Doctor doc);

        void SaveChanges(); 

    }
}