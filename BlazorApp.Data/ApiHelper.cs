using BlazorApp.Core.Models;
using System.Net.Http.Json;

namespace BlazorApp.Data;

public class ApiHelper
{
    private readonly HttpClient client = new HttpClient { BaseAddress = new Uri("https://api.escuelajs.co/api/v1/") };
    private string _token = string.Empty;

    public async Task<LoginResponse?> AuthicateUser(string email, string password)
    {
        LoginResponse? loginResponse = null;
        try
        {
            var response = await client.PostAsJsonAsync("auth/login", new LoginRequest { Email = email, Password = password });
            response.EnsureSuccessStatusCode();
            loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
            _token = loginResponse?.Access_Token ?? string.Empty;
        }
        catch (Exception) { }

        return loginResponse;
    }

    public async Task<UserResponse?> GetUserProfile()
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");
        return await client.GetFromJsonAsync<UserResponse?>("auth/profile");
    }

    public async Task<List<UserResponse>?> GetUsers()
    {
        return await client.GetFromJsonAsync<List<UserResponse>?>("users");
    }
}
