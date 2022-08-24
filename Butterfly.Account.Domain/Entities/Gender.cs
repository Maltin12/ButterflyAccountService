namespace Butterfly.Account.Domain.Entities
{
    public class Gender
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public ICollection<User> Users { get; set; }
    }
}