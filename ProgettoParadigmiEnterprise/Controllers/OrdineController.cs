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
        private readonly IPortataService portataService;

		public OrdineController(IOrdineService _ordineService, IPortataService _portataService)
        {
            ordineService = _ordineService;
            portataService = _portataService;
        }

        [HttpPost]
        [Route("creaOrdine")]
        public IActionResult CreaOrdine([FromBody] CreaOrdineRequest request)
        {
            List<Portata> portate = portataService.GetPortateById(request.portate);
            Ordine ordine = ordineService.CreaOrdine(GetEmailUtente(), request.indirizzo, portate);
            return Ok(new CreaOrdineResponse(ordine.numero, CalcolatorePrezzoOrdine.CalcolaTotale(ordine)));
        }

        [HttpGet]
        [Route("vediStorico")]
        public IActionResult VediStoricoOrdini(DateOnly dataInizio, DateOnly dataFine, string emailUtente = null)
        {
            /*string utente = emailUtente==null ? GetEmailUtente() : emailUtente;
            if (GetRuoloUtente() == Ruolo.Amministratore.ToString())
                return Ok(ordineService.GetAllOrdini());
            return Ok(ordineService.GetOrdiniByUtente(utente));*/

            if (GetRuoloUtente() == Ruolo.Amministratore.ToString())
                if (emailUtente == null)
                    return Ok(ordineService.GetAllOrdini());
                else return Ok(ordineService.GetOrdiniByUtente(emailUtente));
            return Ok(ordineService.GetOrdiniByUtente(GetEmailUtente()));
        }

        private string GetEmailUtente() => User.FindFirst(ClaimTypes.Email).Value;
        private string GetRuoloUtente() => User.FindFirst(ClaimTypes.Role).Value;
    }
}