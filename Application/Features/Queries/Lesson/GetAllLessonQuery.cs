using Application.DTOs.Exam;
using Application.DTOs.Lesson;
using MediatR;

namespace Application.Features.Queries.Lesson
{
    public class GetAllLessonQuery :IRequest<List<LessonListDto>>
    {
        public int LessonId { get; set; }
        public string LessonCode { get; set; }
        public decimal StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public decimal Grade { get; set; }
    }
}