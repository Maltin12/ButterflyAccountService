namespace Butterfly.Account.Domain.Entities
{
    public class Nationality
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}