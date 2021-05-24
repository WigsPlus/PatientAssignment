using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Hospital.Models;

namespace Hospital.Data
{
    public class MockDoctorsRepo : IDoctorsRepo //Dummy data
    {

        public List<Doctor> doctors;

        public MockDoctorsRepo()
        {
            doctors = new List<Doctor>
            {
            new Doctor{doctorId=0,name="Søren", department="Århus"},
            new Doctor{doctorId=1,name="Kasper", department="Vejle"},
            new Doctor{doctorId=2,name="Ole", department="Århus"}
            };    
        }
        
        public IEnumerable<Doctor> GetHospitalDoctors()
        {          
            return doctors;
        }

        public Doctor GetDoctorById(int id)
        {
           
            return doctors.FirstOrDefault(s => s.doctorId == id);
               
        }

        public void CreateDoctor(Doctor doc)
        {
            if (doc == null)
            {
                throw new ArgumentNullException(nameof(doc));
            }
            doctors.Add(doc);


        //If a database was setup this was needed everytime change was made to the storage data
        }

        public void SaveChanges() // Would be needed if a database would had been setup
        {
            throw new NotImplementedException(); 
        }
    }
}