using Application.DTOs.Exam;
using Application.DTOs.Lesson;
using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Application.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Helpers;

namespace Application.Service.Implementations
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResult> CreateAsync(ExamCreateAndUpdateDto lesson)
        {
            if (lesson == null) return ServiceResult.Failed("Lesson DTO is null.");
            try
            {
                var lessonEntity = _mapper.Map<Exam>(lesson);
                await _unitOfWork.Repository<Exam>().Create(lessonEntity);
                await _unitOfWork.CommitAsync();
                return ServiceResult.Succeed("Exam created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failed(ex.Message);
            }
        }


        public async Task<ServiceResult> DeleteAsync(int id)
        {
            if (id <= 0) return ServiceResult.Failed("Invalid Lesson ID.");

            var exam = await _unitOfWork.Repository<Exam>().GetById(id);
            if (exam == null) return ServiceResult.Failed("Lesson not found.");

            await _unitOfWork.Repository<Exam>().Delete(exam);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Succeed("Exam deleted successfully.");
        }

        public async Task<List<ExamListDTO>> GetAllAsync()
        {
            var exams = await _unitOfWork.Repository<Exam>().GetAll();
            return _mapper.Map<List<ExamListDTO>>(exams);
        }

        public async Task<List<ExamListDTO>> SearchAsync(string? searchText)
        {
            var exams = await _unitOfWork.Repository<Exam>().GetAll();
           
            return _mapper.Map<List<ExamListDTO>>(exams);
        }

        public async Task<ExamListDTO> GetByIdAsync(int id)
        {
            var exam = await _unitOfWork.Repository<Exam>().GetById(id);
            return _mapper.Map<ExamListDTO>(exam);
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var exam = await _unitOfWork.Repository<Exam>().GetById(id);
            if (exam == null) return ServiceResult.Failed("Exam not found.");

            exam.SoftDeleted = true;
            await _unitOfWork.Repository<Exam>().Update(exam);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Succeed("Exam soft deleted successfully.");
        }

        public async Task<ServiceResult> UpdateAsync(int id, ExamCreateAndUpdateDto exam)
        {
            if (id <= 0) return ServiceResult.Failed("Invalid Exam ID.");
            if (exam == null) return ServiceResult.Failed("Exam DTO is null.");

            var existingExam = await _unitOfWork.Repository<Exam>().GetById(id);
            if (existingExam == null) return ServiceResult.Failed("Lesson not found.");

            _mapper.Map(exam, existingExam);
            await _unitOfWork.Repository<Exam>().Update(existingExam);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Succeed("Exam updated successfully.");
        }
    }
}
