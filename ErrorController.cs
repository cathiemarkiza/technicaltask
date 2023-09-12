using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("error")]
public class ErrorController : ControllerBase
{
    [HttpGet]
    public IActionResult Error()
    {
        // Return error response or custom error view
        return StatusCode(500, "An error occurred.");
    }
}
