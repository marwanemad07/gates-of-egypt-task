namespace ECommerceApp.Domain.Entities
{
    public class BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
