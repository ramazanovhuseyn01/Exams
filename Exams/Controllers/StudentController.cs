using Application.DTOs.Student;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Interfaces;

namespace Exam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _studentService.GetAllAsync(); 
                return Ok(students);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching students.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateStudent(StudentCreateAndUpdateDto student)
        {
            var result = await _studentService.CreateAsync(student);
            return Ok(result);
        }

        [HttpPut("Edit/{id}")] 
        public async Task<IActionResult> UpdateStudent(int id, StudentCreateAndUpdateDto student)
        {
            var result = await _studentService.UpdateAsync(id, student);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")] 
        public async Task<IActionResult> RemoveStudent(int id)
        {
            var result = await _studentService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPut("soft-delete/{id}")] 
        public async Task<IActionResult> SoftDeleted(int id)
        {
            var result = await _studentService.SoftDeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("search")] 
        public async Task<IActionResult> SearchStudent(string searchText)
        {
            var result = await _studentService.SearchAsync(searchText);
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _studentService.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
