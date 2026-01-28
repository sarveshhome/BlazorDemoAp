using BlazerDemoApp.Models;
using System.Text.Json;

namespace BlazerDemoApp.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IHttpClientFactory _httpClientFactory;

    public UserRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("JsonPlaceholder");
        var response = await httpClient.GetAsync("users");
        response.EnsureSuccessStatusCode();
        
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<User>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new List<User>();
    }
}