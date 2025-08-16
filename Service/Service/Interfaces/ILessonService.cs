using Application.DTOs.Lesson;
using Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Interfaces
{
    public interface ILessonService
    {
        Task<ServiceResult> CreateAsync(LessonCreateAndUpdateDto lesson);
        Task<List<LessonListDto>> GetAllAsync();
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult> SoftDeleteAsync(int id);
        Task<ServiceResult> UpdateAsync(int id, LessonCreateAndUpdateDto lesson);
        Task<List<LessonListDto>> SearchAsync(string? searchText);
        Task<LessonListDto> GetByIdAsync(int id);
    }
}
