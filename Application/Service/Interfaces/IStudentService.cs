using Application.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Helpers;

namespace Application.Service.Interfaces
{
    public interface IStudentService
    {
        Task<ServiceResult> CreateAsync(StudentCreateAndUpdateDto Student);
        Task<List<StudentListDto>> GetAllAsync();
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult> SoftDeleteAsync(int id);
        Task<ServiceResult> UpdateAsync(int id, StudentCreateAndUpdateDto Student);
        Task<List<StudentListDto>> SearchAsync(string? searchText);
        Task<StudentListDto> GetByIdAsync(int id);
    }
}
