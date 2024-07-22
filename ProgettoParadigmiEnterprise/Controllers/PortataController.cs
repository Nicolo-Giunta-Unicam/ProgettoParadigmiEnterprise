using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgettoParadigmiEnterprise.Abstractions;
using ProgettoParadigmiEnterprise.Model;
using ProgettoParadigmiEnterprise.Requests;
using System.Security.Claims;

namespace ProgettoParadigmiEnterprise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PortataController : ControllerBase
    {
        private readonly IPortataService portataService;
        public PortataController(IPortataService _portataService)
        {
            portataService = _portataService;
        }
        [HttpPost]
        [Route("creaPortata")]
        public IActionResult CreaPortata([FromBody] CreaPortataRequest request)
        {
            if (GetRuoloUtente() != Ruolo.Amministratore.ToString()) return BadRequest("Non si dispone dei privilegi necessari");
            Portata portata = portataService.CreaPortata(request.nome, request.prezzo, request.tipologia);
            return Ok("Portata creata con id: "+ portata.id);
        }

        [HttpGet]
        [Route("vediMenu")]
        [AllowAnonymous]
        public IActionResult VediMenu() => Ok(portataService.GetAllPortate());

        private string GetRuoloUtente() => User.FindFirst(ClaimTypes.Role).Value;
    }
}