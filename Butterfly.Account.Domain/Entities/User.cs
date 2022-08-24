using Microsoft.AspNetCore.Identity;

namespace Butterfly.Account.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFirstTime { get; set; } = true;
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public Guid GenderId { get; set; }
        public Guid DepartmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
    }
}