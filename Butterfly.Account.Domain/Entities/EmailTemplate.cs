namespace Butterfly.Account.Domain.Entities
{
    public class EmailTemplate
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
    }

}