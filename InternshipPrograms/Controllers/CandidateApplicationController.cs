using InternshipPrograms.Application.Dtos; 
using InternshipPrograms.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InternshipPrograms.Controllers
{
    [Route("[controller]")]
    [ApiController]

    //EF Approach
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;
        private readonly ICandidateApplication service;

        public CandidateController(ILogger<CandidateController> logger, ICandidateApplication service)
        {
            _logger = logger;
            this.service = service;
        }

        [HttpGet("GetApplicationsById")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var res = await service.GetAsync(id);
                if (res == null)
                {
                    return NotFound(new Response<CandidateApplicationDto>(res));
                }
                return Ok(new Response<CandidateApplicationDto>(res));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }

        [HttpGet("GetAllApplications")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await service.GetAllAsync();
                return Ok(new Response<IEnumerable<CandidateApplicationDto>>(res));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }

        [HttpPost("CreateApplication")]
        public async Task<IActionResult> Post([FromForm] CreateCandidateApplicationDto dto)
        { 
            try
            {
                var res = await service.AddAsync(dto);
                return Ok(new Response<string>(res));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }

        [HttpPut("UpdateApplication")]
        public async Task<IActionResult> Put([FromForm] UpdateCandidateApplicationDto task)
        { 
            try
            {
                var res = await service.UpdateAsync(task);
                return Ok(new Response<string>(res));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }

        [HttpDelete("DeleteApplication")]
        public IActionResult Delete(string id)
        {
            try
            {
                var res =   service.DeleteAsync(id).Result;
                return Ok(new Response<string>(res));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }
    } 
}