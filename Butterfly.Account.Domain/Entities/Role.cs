using Microsoft.AspNetCore.Identity;

namespace Butterfly.Account.Domain.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}