using BlazorApp.Pages;

namespace BlazorApp.Services
{
    public interface IUserService
    {
        Task<UserResponse> Login(UserRequest user);
    }

    public class UserRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class UserResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
    }
}
