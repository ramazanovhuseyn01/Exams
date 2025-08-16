using Application.DTOs.Lesson;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Interfaces;
using Service.Helpers;

namespace Exam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        private readonly ILogger<LessonController> _logger;

        public LessonController(ILessonService lessonService, ILogger<LessonController> logger)
        {
            _lessonService = lessonService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllLessons()
        {
            try
            {
                var result = await _lessonService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching Lesson.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateLesson(LessonCreateAndUpdateDto lesson)
        {
            var result = await _lessonService.CreateAsync(lesson);
            return Ok(result);
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> UpdateLesson(int id, LessonCreateAndUpdateDto lesson)
        {
            var result = await _lessonService.UpdateAsync(id, lesson);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> RemoveLesson(int id)
        {
            var result = await _lessonService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPut("soft-delete/{id}")]
        public async Task<IActionResult> SoftDeleted(int id)
        {
            var result = await _lessonService.SoftDeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("search")] 
        public async Task<IActionResult> SearchLesson(string searchText)
        {
            var result = await _lessonService.SearchAsync(searchText);
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _lessonService.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
