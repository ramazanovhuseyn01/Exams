using Application.DTOs.Exam;
using Application.Helpers;
using MediatR;

namespace Application.Features.Queries.Lesson
{
    public class GetByIdLessonQuery : IRequest<ExamListDTO>
    {
        public GetByIdLessonQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}