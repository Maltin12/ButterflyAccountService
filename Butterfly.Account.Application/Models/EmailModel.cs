namespace Butterfly.Account.Application.Models
{
    public class EmailModel
    {
        public string Receiver { get; set; }
        public string Subject { get; set;}
        public string Content { get; set; }
        public bool IsHtmlBody { get; set; }
    }
}