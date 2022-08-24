namespace Butterfly.Account.Domain.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public ICollection<User> Users { get; set; }

    }
}