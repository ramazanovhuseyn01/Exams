using Domain.Base;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public decimal StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Class { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}