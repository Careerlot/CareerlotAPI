using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CareerController : ControllerBase 
{
    [HttpGet]
    public IActionResult Get() => Ok("API is working");
}