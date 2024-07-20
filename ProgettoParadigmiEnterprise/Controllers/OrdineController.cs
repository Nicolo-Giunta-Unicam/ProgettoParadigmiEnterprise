using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgettoParadigmiEnterprise.Abstractions;
using ProgettoParadigmiEnterprise.Model;
using ProgettoParadigmiEnterprise.Requests;
using ProgettoParadigmiEnterprise.Responses;
using ProgettoParadigmiEnterprise.Utility;
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
            Ordine ordine = ordineService.CreaOrdine(GetEmailUtente(), request.indirizzo, request.portate);
            return Ok(new CreaOrdineResponse(ordine.numero, CalcolatorePrezzoOrdine.CalcolaTotale(ordine)));
        }

        private string GetEmailUtente() => User.FindFirst(ClaimTypes.Email).Value;
    }
}