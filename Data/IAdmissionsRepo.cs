using System;
using System.Collections.Generic;
using Hospital.Models;

namespace Hospital.Data
{
    public interface IAdmissionsRepo
    {
        IEnumerable<Admission> GetHospitalAdmissions();

        void SaveChanges(); 
        
        void PopulateData(IDoctorsRepo doctors,IPatientsRepo patients); //Populates dummy data

        Admission CreateAdmission(Patient patient, string department);

        void AddDoctorToAdmission(Doctor doctor, Admission admission);

        Boolean HasAccess(Doctor x, Patient y);
    }
}
