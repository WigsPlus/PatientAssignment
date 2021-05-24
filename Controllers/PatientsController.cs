using AutoMapper;
using Hospital.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController
    {
        private readonly IPatientsRepo _repository;
        private readonly IMapper _mapper;

        public PatientsController(IPatientsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;         
        }
    }
}