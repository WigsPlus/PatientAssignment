using AutoMapper;
using Hospital.Dtos;
using Hospital.Models;

namespace Hospital.Profiles
{
    public class DoctorsProfile : Profile //Tying the DTO with the internal object
    {
        public DoctorsProfile()
        {
            //Source -> Target
            CreateMap<Doctor, DoctorReadDto>();
            CreateMap<DoctorCreateDto, Doctor>();
            //It is in here i would congatinate the data from the database
        }
    }
}