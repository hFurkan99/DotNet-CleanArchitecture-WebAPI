using App.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CustomBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(ServiceResult<T> result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.Created => Created(result.UrlAsCreated, result),
            _ => new ObjectResult(result) { StatusCode = result.StatusCode.GetHashCode() }
        };
    }

    [NonAction]
    public IActionResult CreateActionResult(ServiceResult result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.NoContent => NoContent(),
            _ => new ObjectResult(result) { StatusCode = result.StatusCode.GetHashCode() }
        };
    }
}
