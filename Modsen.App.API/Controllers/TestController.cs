﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Modsen.App.API.Controllers;

[Route("api/[controller]")]

[ApiController]
public class TestController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
    [HttpGet("un")]
    public IActionResult GetUnAuthorize()
    {
        return Ok();
    }
}