using Application.Helpers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Exam
{
    public record CreateLessonCommand : IRequest<ServiceResult>
    {
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public decimal Class { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
    }
}