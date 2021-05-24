using System.Collections.Generic;
using System.Linq;
using Hospital.Models;

namespace Hospital.Data
{
    public class MockPatientsRepo : IPatientsRepo //Dummy data
    {
        public static MockPatientsRepo instance;

        public List<Patient> Patients;

        public MockPatientsRepo()
        {
            Patients = new List<Patient>
            {
            new Patient{SSN=67048766,name="Signe"},
            new Patient{SSN=15078809,name="Maj"},
            new Patient{SSN=34108648,name="Maria"}
            };    
        }

        public IEnumerable<Patient> GetHospitalPatients()
        {
            return Patients;
        }

        public Patient GetpatientBySSN(int SSN)
        {
           return Patients.FirstOrDefault(s => s.SSN == SSN);
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}