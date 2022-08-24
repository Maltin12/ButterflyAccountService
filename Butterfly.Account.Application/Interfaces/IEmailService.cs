using System.Threading.Tasks;
using Butterfly.Account.Application.Models;

namespace visionagency.Butterfly.Account.Application.Interfaces
{
    public interface IEmailService
    {
        Task Send(EmailModel model);
    }
}