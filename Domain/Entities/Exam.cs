using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Exam : BaseEntity
    {
        public string? LessonCode { get; set; }

        [Range(10000, 99999, ErrorMessage = "StudentNumber must be a 5-digit number.")]
        public decimal StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public decimal Grade { get; set; }

        public virtual ICollection<Student>? Students { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}