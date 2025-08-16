using Application.Features.Commands.Exam;
using Application.Helpers;
using Domain.Entities;
using MediatR;
using Repository.Repositories.Interfaces;
using System.Diagnostics;

namespace Application.Features.Handlers.Exam
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, ServiceResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLessonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var lesson = new Domain.Entities.Lesson
                {
                    CreateDate = DateTime.UtcNow.AddHours(4),
                    LessonName = request.LessonName,
                    LessonCode = request.LessonCode,
                    Class = request.Class,
                    TeacherFirstName = request.TeacherFirstName,
                    TeacherLastName = request.TeacherLastName
                };

                await _unitOfWork.Repository<Domain.Entities.Lesson>().Create(lesson);
                await _unitOfWork.CommitAsync();

                return ServiceResult.Succeed("Lesson created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failed($"An error occurred while creating the lesson: {ex.Message}");
            }



        }
    }
   
}