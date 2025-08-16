using Application.DTOs.Lesson;
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
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LessonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResult> CreateAsync(LessonCreateAndUpdateDto lesson)
        {
            if (lesson == null) return ServiceResult.Failed("Lesson DTO is null.");
            try
            {
                var lessonEntity = _mapper.Map<Lesson>(lesson);
                await _unitOfWork.Repository<Lesson>().Create(lessonEntity);
                await _unitOfWork.CommitAsync();
                return ServiceResult.Succeed("Lesson created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failed(ex.Message);
            }
        }


        public async Task<ServiceResult> DeleteAsync(int id)
        {
            if (id <= 0) return ServiceResult.Failed("Invalid Lesson ID.");

            var lesson = await _unitOfWork.Repository<Lesson>().GetById(id);
            if (lesson == null) return ServiceResult.Failed("Lesson not found.");

            await _unitOfWork.Repository<Lesson>().Delete(lesson);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Succeed("Lesson deleted successfully.");
        }

        public async Task<List<LessonListDto>> GetAllAsync()
        {
            var lessons = await _unitOfWork.Repository<Lesson>().GetAll();
            return _mapper.Map<List<LessonListDto>>(lessons);
        }

        public async Task<List<LessonListDto>> SearchAsync(string? searchText)
        {
            var lessons = await _unitOfWork.Repository<Lesson>().GetAll();
            if (!string.IsNullOrEmpty(searchText))
            {
                lessons = lessons.Where(l => l.LessonCode.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return _mapper.Map<List<LessonListDto>>(lessons);
        }

        public async Task<LessonListDto> GetByIdAsync(int id)
        {
            var lesson = await _unitOfWork.Repository<Lesson>().GetById(id);
            return _mapper.Map<LessonListDto>(lesson);
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            if (id <= 0) return ServiceResult.Failed("Invalid Lesson ID.");

            var lesson = await _unitOfWork.Repository<Lesson>().GetById(id);
            if (lesson == null) return ServiceResult.Failed("Lesson not found.");

            lesson.SoftDeleted = true;
            await _unitOfWork.Repository<Lesson>().Update(lesson);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Succeed("Lesson soft deleted successfully.");
        }

        public async Task<ServiceResult> UpdateAsync(int id, LessonCreateAndUpdateDto lesson)
        {
            if (id <= 0) return ServiceResult.Failed("Invalid Lesson ID.");
            if (lesson == null) return ServiceResult.Failed("Lesson DTO is null.");

            var existingLesson = await _unitOfWork.Repository<Lesson>().GetById(id);
            if (existingLesson == null) return ServiceResult.Failed("Lesson not found.");

            _mapper.Map(lesson, existingLesson);
            await _unitOfWork.Repository<Lesson>().Update(existingLesson);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Succeed("Lesson updated successfully.");
        }
    }
}
