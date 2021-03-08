using Dapr.CleanArchitecture.Application.Dto;

namespace Dapr.CleanArchitecture.Application.ApplicationUser.Queries.GetToken
{
    public class LoginResponse
    {
        public ApplicationUserDto User { get; set; }

        public string Token { get; set; }
    }
}
