namespace Domain.Base.Abstraction
{
    public interface IBaseEntity<T>
    {
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool SoftDeleted { get; set; }
    }
}