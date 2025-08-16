using Application.Features.Commands.Exam;
using Application.Helpers;
using MediatR;
using Repository.Repositories.Interfaces;

namespace Application.Features.Handlers.Exam
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, ServiceResult>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateLessonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var lesson = await _unitOfWork.Repository<Domain.Entities.Lesson>().GetById(request.LessonId);

                if (lesson == null)
                    return ServiceResult.Failed("Lesson not found.");

                lesson.LessonCode = request.LessonCode;
                lesson.Class = request.Class;
                lesson.TeacherFirstName = request.TeacherFirstName;
                lesson.TeacherLastName = request.TeacherLastName;
                lesson.LessonName = request.LessonName;

                await _unitOfWork.Repository<Domain.Entities.Lesson>().Update(lesson);
                await _unitOfWork.CommitAsync();

                return ServiceResult.Succeed("Lesson updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failed($"An error occurred while creating the lesson: {ex.Message}");
            }

        }
    }
}