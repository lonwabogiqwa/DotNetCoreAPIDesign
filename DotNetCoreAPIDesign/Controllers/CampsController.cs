using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DotNetCoreAPIDesign.Data;
using DotNetCoreAPIDesign.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreAPIDesign.Controllers
{
    [Route("api/[controller]")]
    public class CampsController:ControllerBase
    {
        private readonly ICampRepository _repository;
        private readonly IMapper _mapper;
        public CampsController(ICampRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<CampDomain[]>> Get(bool includeTalks=false)
        {
            try
            {
                var results = await _repository.GetAllCampsAsync(includeTalks);
                
                return _mapper.Map<CampDomain[]>(results); 

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }
        [HttpGet("{moniker}")]
        public async Task<ActionResult<CampDomain>> Get(string moniker)
        {
            try
            {
                var result = await _repository.GetCampAsync(moniker);
                if (result == null) return NotFound();
                return _mapper.Map<CampDomain>(result);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{searchByDate}/{theDate}")]
        public async Task<ActionResult<CampDomain[]>> SearchByDate(DateTime theDate, bool includeTalks= false)
        {
            try
            {
                var results = await _repository.GetAllCampsByEventDate(theDate, includeTalks);
                if (!results.Any()) return NotFound();
                return _mapper.Map<CampDomain[]>(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
    }
}
