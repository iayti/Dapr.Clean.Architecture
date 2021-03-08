using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Common.Models;

namespace Dapr.CleanArchitecture.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
