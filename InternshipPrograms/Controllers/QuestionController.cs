using InternshipPrograms.Application.Dtos;
using InternshipPrograms.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPrograms.Controllers
{
    [Route("[controller]")]
    [ApiController]
     
    public class QuestionsController : ControllerBase
    {
        private readonly ILogger<QuestionsController> _logger;
        private readonly IQuestion service;

        public QuestionsController(ILogger<QuestionsController> logger, IQuestion service)
        {
            _logger = logger;
            this.service = service;
        }

        [HttpGet("Id")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var res = await service.GetAsync(id);
                if (res == null)
                {
                    return NotFound(new Response<QuestionsDto>(res));
                }
                return Ok(new Response<QuestionsDto>(res));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }

        [HttpGet("Type")]
        public async Task<IActionResult> GetByType(string type)
        {
            try
            {
                var res = await service.GetByTypeAsync(type);
                if (res == null)
                {
                    return NotFound(new Response<QuestionsDto>(res));
                }
                return Ok(new Response<QuestionsDto>(res));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await service.GetAllAsync();
                return Ok(new Response<IEnumerable<QuestionsDto>>(res));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateQuestionsDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Task data is invalid.");
            }
            try
            {
                var res = await service.AddAsync(dto);
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateQuestionsDto dto)
        { 
            try
            {
                var res = await service.UpdateAsync(dto);
                return Ok(new Response<string>(res));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = service.DeleteAsync(id).Result;
                return Ok(new Response<string>(result));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message, e.InnerException);
                throw;
            }
        }
    } 
}