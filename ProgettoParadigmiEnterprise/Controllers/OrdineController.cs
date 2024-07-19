using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgettoParadigmiEnterprise.Abstractions;
using ProgettoParadigmiEnterprise.Requests;
using System.Security.Claims;

namespace ProgettoParadigmiEnterprise.Controllers
{
	[ApiController]
	[Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdineController : ControllerBase
	{
        private readonly IOrdineService ordineService;

		public OrdineController(IOrdineService _ordineService)
        {
            ordineService = _ordineService;
        }

        [HttpPost]
        [Route("creaOrdine")]
        public IActionResult CreaOrdine([FromBody] CreaOrdineRequest request)
        {
            ordineService.CreaOrdine(GetEmailUtente(), request.indirizzo, request.portate);
            return Ok("Ordine Creato");
        }

        private string GetEmailUtente() => User.FindFirst(ClaimTypes.Email).Value;
    }
}