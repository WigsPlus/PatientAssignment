using System.Collections.Generic;
using Hospital.Models;

namespace Hospital.Data
{
    public class MockAdmissionsRepo :IAdmissionsRepo //Dummy data
    {
        public static MockAdmissionsRepo instance;

        public List<Admission> admissions;

        public MockAdmissionsRepo()
        {
            admissions = new List<Admission>();
        }

        public Admission CreateAdmission(Patient patient, string department)
        {
            Admission admission = new Admission
            {
                department = department, 
                patientInAdmission=patient, 
                doctorsAssociated= new List<Doctor>()
            };

            admissions.Add(admission);
            
            return admission;
        }

        public void AddDoctorToAdmission(Doctor doctor, Admission admission)
        {          
            admission.doctorsAssociated.Add(doctor); //TODO: Create check for nullable values
        }

        public IEnumerable<Admission> GetHospitalAdmissions()
        {
            return admissions;
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void PopulateData(IDoctorsRepo doctors, IPatientsRepo patients)
        {           
            Admission PatientAdmission = CreateAdmission(patients.GetpatientBySSN(67048766),"Århus");  
            AddDoctorToAdmission(doctors.GetDoctorById(0),PatientAdmission);                          //Creating a dummy admission where the doctor is associated to a patient
        }

        public bool HasAccess(Doctor x, Patient y)
        {
            foreach (Admission admission in admissions)
            {
                if (admission.patientInAdmission == y)
                {
                    foreach (Doctor doc in admission.doctorsAssociated)
                    {
                        if (doc==x && doc.department == admission.department)
                        {
                            return true;
                        }
                    }
                }
            }
            
            return false;
        }
    }
}