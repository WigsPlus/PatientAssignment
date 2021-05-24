using System.Collections.Generic;
using AutoMapper;
using Hospital.Data;
using Hospital.Dtos;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase 
    {
        private readonly IDoctorsRepo _repository; //Idoctor before singleton got used
        private readonly IMapper _mapper;  

        public DoctorsController(IDoctorsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
          
        }

        //Get api/doctors
        [HttpGet]
        public ActionResult <IEnumerable<DoctorReadDto>> GetAllDoctors()
        {
            var allDoctors = _repository.GetHospitalDoctors();

            return Ok(_mapper.Map<IEnumerable<DoctorReadDto>>(allDoctors));
        }

        //Get api/doctors={id}
        [HttpGet("doctorId={id}")]
        public ActionResult <DoctorReadDto> GetDoctorById(int id)
        {
            var doctorItem = _repository.GetDoctorById(id);
            if (doctorItem != null)
            {
                return Ok(_mapper.Map<DoctorReadDto>(doctorItem));
            }
            return NotFound();
        }
        //Post api/doctor
        [HttpPost]
        public ActionResult <DoctorReadDto> CreateDoctorBy(DoctorCreateDto doctorCreateDto)
        {
            var doctorItem = _mapper.Map<Doctor>(doctorCreateDto);
            _repository.CreateDoctor(doctorItem);
            //_repository.SaveChanges();
            var doctorReadDto = _mapper.Map<DoctorReadDto>(doctorItem);

            return Ok(doctorReadDto);
        }
    }
}