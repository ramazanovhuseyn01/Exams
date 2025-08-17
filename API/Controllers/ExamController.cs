
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Exam;
using Application.Service.Implementations;
using Application.Service.Interfaces;

namespace Exam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly ILogger<ExamController> _logger;

        public ExamController(IExamService examService, ILogger<ExamController> logger)
        {
            _examService = examService;
            _logger = logger;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateExam(ExamCreateAndUpdateDto exam)
        {
            var result = await _examService.CreateAsync(exam);
            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> UpdateExam(int id, ExamCreateAndUpdateDto exam)
        {
            var result = await _examService.UpdateAsync(id, exam);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> RemoveExam(int id)
        {
            var result = await _examService.DeleteAsync(id);
            return Ok(result);
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllExams()
        {
            try
            {
                var result = await _examService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching Exam.");
                return StatusCode(500, "Internal server error.");
            }

        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _examService.GetByIdAsync(id);
            return Ok(result);
        }


    }
}