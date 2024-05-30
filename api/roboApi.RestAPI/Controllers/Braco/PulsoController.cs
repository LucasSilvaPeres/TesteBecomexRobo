using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using roboApi.Core.Services;

namespace roboApi.RestAPI.Controllers.Braco;

[ApiController]
[Route("api/Braco/[controller]/[action]")]
public class PulsoController : ControllerBase
{
    private readonly PulsoService _pulsoService;
    public PulsoController(PulsoService pulsoService){
        _pulsoService = pulsoService;
    }

    [HttpPost]
    public async Task<ActionResult> EsquerdoPositivoAsync()
    {
        await _pulsoService.RotacaoPulsoEsquerdoPositivo();
        return Ok();
    }  
    [HttpPost] 
    public async Task<ActionResult> EsquerdoNegativoAsync()
    {
        await _pulsoService.RotacaoPulsoEsquerdoNegativo();
        return Ok();
    }   
    [HttpPost]
    public async Task<ActionResult> DireitoPositivoAsync()
    {
        await _pulsoService.RotacaoPulsoDireitoPositivo();
        return Ok();
    }   
    [HttpPost]
    public async Task<ActionResult> DireitoNegativoAsync()
    {
        await _pulsoService.RotacaoPulsoDireitoNegativo();
        return Ok();
    }   
}
