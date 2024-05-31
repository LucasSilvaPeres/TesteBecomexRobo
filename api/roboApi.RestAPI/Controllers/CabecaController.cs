using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using roboApi.Core.Services;

namespace roboApi.RestAPI.Controllers
{
    [ApiController]
    [Route("api/Robo/[controller]/[action]")]
    public class CabecaController : ControllerBase
    {
        private readonly CabecaService _cabecaService;
        public CabecaController(CabecaService cabecaService){
            _cabecaService = cabecaService;
        }
        [HttpPost]
        public async Task<ActionResult> InclinacaoCimaAsync()
        {
            await _cabecaService.InclinacaoCima();
            return Ok();
        }   
        [HttpPost]
        public async Task<ActionResult> InclinacaoBaixoAsync()
        {
            await _cabecaService.InclinacaoBaixo();
            return Ok();
        }   
        [HttpPost]
        public async Task<ActionResult> RotacaoPositivoAsync()
        {
            await _cabecaService.RotacaoPositivo();
            return Ok();
        }   
        [HttpPost]
        public async Task<ActionResult> RotacaoNegativoAsync()
        {
            await _cabecaService.RotacaoNegativo();
            return Ok();
        }   
    }
}