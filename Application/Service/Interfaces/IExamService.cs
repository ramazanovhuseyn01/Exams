using Application.DTOs.Exam;
using Application.DTOs.Lesson;
using Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    public interface IExamService
    {
        Task<ServiceResult> CreateAsync(ExamCreateAndUpdateDto lesson);
        Task<List<ExamListDTO>> GetAllAsync();
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult> SoftDeleteAsync(int id);
        Task<ServiceResult> UpdateAsync(int id, ExamCreateAndUpdateDto lesson);
        Task<List<ExamListDTO>> SearchAsync(string? searchText);
        Task<ExamListDTO> GetByIdAsync(int id);
    }
}
