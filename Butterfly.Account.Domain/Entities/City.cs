namespace Butterfly.Account.Domain.Entities
{
    public class City
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ZipCode { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;



    }

}