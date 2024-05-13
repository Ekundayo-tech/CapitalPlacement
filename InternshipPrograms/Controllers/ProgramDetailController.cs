using InternshipPrograms.Application.Dtos; 
using InternshipPrograms.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPrograms.Controllers
{
    [Route("[controller]")]
    [ApiController]

    //EF Approach
    public class EmployerController : ControllerBase
    {
        private readonly ILogger<EmployerController> _logger;
        private readonly IProgramDetails service;

        public EmployerController(ILogger<EmployerController> logger, IProgramDetails service)
        {
            _logger = logger;
            this.service = service;
        }

        [HttpGet("GetProgramById")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var res = await service.GetAsync(id);
                if (res == null)
                {
                    return NotFound(new Response<ProgramDetailDto>(res));
                }
                return Ok(new Response<ProgramDetailDto>(res));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }

        [HttpGet("GetAllProgram")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await service.GetAllAsync();
                return Ok(new Response<IEnumerable<ProgramDetailDto>>(res));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }

        [HttpPost("CreateProgram")]
        public async Task<IActionResult> Post([FromBody] CreateProgramDetailDto task)
        { 
            try
            {
                var res = await service.AddAsync(task);
                return Ok(new Response<string>(res));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }

        [HttpPut("UpdateProgram")]
        public async Task<IActionResult> Put([FromBody] UpdateProgramDetailDto task)
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

        [HttpDelete("DeleteProgram")]
        public IActionResult Delete(string id)
        {
            try
            {
                var res = service.DeleteAsync(id).Result;
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