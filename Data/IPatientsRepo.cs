using System.Collections.Generic;
using Hospital.Models;

namespace Hospital.Data
{
    //Decoupling the code -- Easier to change down the line
    public interface IPatientsRepo
    {

        IEnumerable<Patient> GetHospitalPatients();

        void SaveChanges(); 

        Patient GetpatientBySSN(int SSN);
    }
}