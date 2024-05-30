using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using roboApi.Core.Services;
using roboApi.DB.Entities;

namespace roboApi.RestAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RoboController : ControllerBase
{
    private readonly RoboService _roboService;
    public RoboController(RoboService roboService){
        _roboService = roboService;
    }
    [HttpPost]
    public async Task<ActionResult> ReiniciarAsync()
    {
        await _roboService.Reiniciar();

        return Ok();
    }   
    [HttpGet]
    public async Task<ActionResult<Robo>> StatusAsync()
    {
        return Ok(await _roboService.Status());
    }   
}
