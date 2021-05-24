using System.Collections.Generic;
using AutoMapper;
using Hospital.Data;
using Hospital.Dtos;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    
    [Route("api/admissions")]
    [ApiController]
    public class AdmissionsController : ControllerBase 
    {
        private readonly IAdmissionsRepo admissions_repository; //Idoctor before singleton got used
        private readonly IPatientsRepo patients_repository; 
        private readonly IDoctorsRepo doctors_repository; 
        private readonly IMapper _mapper;

        public AdmissionsController(IDoctorsRepo doctors,IAdmissionsRepo admissions,IPatientsRepo patients, IMapper mapper)
        {
            doctors_repository = doctors;
            patients_repository = patients;
            admissions_repository = admissions;
            _mapper = mapper; 

            admissions_repository.PopulateData(doctors_repository,patients_repository); //Making sure to populate the admissions after the other mockups has run
        }

        [HttpGet("{patientId}/{doctorId}")]
        public ActionResult <IEnumerable<AdmissionsController>> GetPatientAssociatedWithDoctor(int patientId, int doctorId) //For checking if the Doctor has acess to patient on that admission
        {
            Doctor ourDoctor = doctors_repository.GetDoctorById(doctorId);
            
            Patient ourPatient = patients_repository.GetpatientBySSN(patientId);
            
            if (admissions_repository.HasAccess(ourDoctor,ourPatient))
            {
                return Ok(ourPatient);
            }
            return Ok("Not allowed");
            
        }
    }
}