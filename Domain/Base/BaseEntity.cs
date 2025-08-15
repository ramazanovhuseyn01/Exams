using Domain.Base.Abstraction;

namespace Domain.Base
{
    public class BaseEntity : IBaseEntity<int>
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool SoftDeleted { get; set; }
    }
}