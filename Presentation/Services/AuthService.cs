using Microsoft.AspNetCore.Http.HttpResults;
using Presentation.Models;
using System.Reflection;

namespace Presentation.Services;

public class AuthService
{
    public async Task<AuthServiceResult> AlreadyExistsAsync(string email)
    {
        using var http = new HttpClient();
        var response = await http.GetFromJsonAsync<AccountServiceResult>($"https://localhost:7217/api/accounts?email={email}");
        return response.Succeeded;
    }

    public async Task<AuthServiceResult> SignUpAsync(SignUpModel model)
    {
        var exists = await AlreadyExistsAsync(model.Email);
        if (!exists)
        {
            return null;
        }

        using var http = new HttpClient();
        var response = await http.PostAsJsonAsync("https://localhost:7217/api/accounts", model);
    }
}
