using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserResponse> Login(UserRequest user)
        {
            UserResponse userResponse = null;
            try
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync<UserRequest>("api/v1/auth/login/", user);
                if (response.IsSuccessStatusCode)
                {
                    userResponse = await response.Content.ReadFromJsonAsync<UserResponse>();
                }
                return userResponse;
            }
            catch (Exception ex)
            {
                return userResponse;
            }
        }
    }
}
