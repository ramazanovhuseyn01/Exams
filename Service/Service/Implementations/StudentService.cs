using Application.DTOs.Student;
using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.Helpers;
using Service.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResult> CreateAsync(StudentCreateAndUpdateDto student)
        {
            if (student is null) return ServiceResult.Failed("student Dto Null");
            try
            {
                var mappingStudent = _mapper.Map<Student>(student);
                await _unitOfWork.Repository<Student>().Create(mappingStudent);
                await _unitOfWork.CommitAsync();
                return ServiceResult.Succeed("New Student Created");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failed(ex.Message);
            }
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            if (id <= 0) return ServiceResult.Failed("StudentID is invalid");
            var student = await _unitOfWork.Repository<Student>().GetById(id);
            if (student == null) return ServiceResult.Failed("Student not found");
            await _unitOfWork.Repository<Student>().Delete(student);
            await _unitOfWork.CommitAsync();
            return ServiceResult.Succeed("Student deleted successfully");
        }

        public async Task<List<StudentListDto>> GetAllAsync()
        {
            var students = await _unitOfWork.Repository<Student>().GetAll();
            return _mapper.Map<List<StudentListDto>>(students);
        }

        public async Task<StudentListDto> GetByIdAsync(int id)
        {
            var student = await _unitOfWork.Repository<Student>().GetById(id);
            return _mapper.Map<StudentListDto>(student);
        }

        public async Task<List<StudentListDto>> SearchAsync(string? searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return await GetAllAsync();
            }

            var students = await _unitOfWork.Repository<Student>().GetAll();
            var filteredStudents = students.Where(s => s.FirstName.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
            return _mapper.Map<List<StudentListDto>>(filteredStudents);
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            if (id <= 0) return ServiceResult.Failed("StudentID is invalid");
            var student = await _unitOfWork.Repository<Student>().GetById(id);
            if (student == null) return ServiceResult.Failed("Student not found");
            student.SoftDeleted = true; // Assuming there is an IsDeleted property
            await _unitOfWork.Repository<Student>().Update(student);
            await _unitOfWork.CommitAsync();
            return ServiceResult.Succeed("Student soft deleted successfully");
        }

        public async Task<ServiceResult> UpdateAsync(int id, StudentCreateAndUpdateDto student)
        {

            if (id <= 0) return ServiceResult.Failed("StudentID is invalid");
            if (student is null) return ServiceResult.Failed("Student Dto Null");
            try
            {
                var existingStudent = await _unitOfWork.Repository<Student>().GetById(id);
                if (existingStudent == null) return ServiceResult.Failed("Student not found");

                _mapper.Map(student, existingStudent);
                await _unitOfWork.Repository<Student>().Update(existingStudent);
                await _unitOfWork.CommitAsync();

                return ServiceResult.Succeed("Student updated successfully");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failed(ex.Message);
            }
        }
    }
}
