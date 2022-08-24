namespace Butterfly.Account.Application.Services.Accounts.Commands.Login
{
    public class LoginModel
    {
        public string Token { get; set; }
        public DateTime? Expires_in { get; set; }
        public string Schema { get; set; }
    }
}