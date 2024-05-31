using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using roboApi;
using roboApi.Core.Services;

namespace roboApi.RestAPI.Controllers.Braco;

[ApiController]
[Route("api/Robo/Braco/[controller]/[action]")]
public class CotoveloController : ControllerBase
{
    private readonly CotoveloService _cotoveloService;
    public CotoveloController(CotoveloService cotoveloService){
        _cotoveloService = cotoveloService;
    }
    [HttpPost]
    public async Task<ActionResult> EsquerdoContrairAsync()
    {
        await _cotoveloService.ContrairCotoveloEsquerdo();
        return Ok();
    }   
    [HttpPost]
    public async Task<ActionResult> EsquerdoDescontrairAsync()
    {
        await _cotoveloService.DescontrairCotoveloEsquerdo();
        return Ok();
    }   
    [HttpPost]
    public async Task<ActionResult> DireitoContrairAsync()
    {
        await _cotoveloService.ContrairCotoveloDireito();
        return Ok();
    }   
    [HttpPost]
    public async Task<ActionResult> DireitoDescontrairAsync()
    {
        await _cotoveloService.DescontrairCotoveloDireito();
        return Ok();
    }   
}
