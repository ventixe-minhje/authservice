using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SignUpController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        using var http = new HttpClient();
        var response = await http.PostAsJsonAsync("https://localhost:7217/api/accounts", model);
    }
}
