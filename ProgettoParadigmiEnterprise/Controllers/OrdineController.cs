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
        /// <summary>
        /// Crea un ordine
        /// </summary>
        /// <param name="request">Richiesta contentente indirizzo e elenco degli id delle portate presenti sul menu</param>
        /// <returns>Numero identificativo e costo totale (con l'applicazione di eventuali sconti)</returns>
        [HttpPost]
        [Route("creaOrdine")]
        public IActionResult CreaOrdine([FromBody] CreaOrdineRequest request)
        {
            List<Portata> portate = portataService.GetPortateById(request.portate); // Prelevo le portate selezionate
            Ordine ordine = ordineService.CreaOrdine(GetEmailUtente(), request.indirizzo, portate);
            return Ok(new CreaOrdineResponse(ordine.numero, CalcolatorePrezzoOrdine.CalcolaTotale(ordine)));
        }
        /// <summary>
        /// Visualizza lo storico degli ordini di uno o più utenti
        /// </summary>
        /// <param name="dataInizio"></param>
        /// <param name="dataFine"></param>
        /// <param name="emailUtente">Opzionale</param>
        /// <returns>Se il richiedente è un amministratore ritorna tutti gli ordini di tutti gli utenti o di un utente
        /// selezionato altrimenti ritorna lo storico degli ordini dell'utente che effettua la richiesta</returns>
        [HttpGet]
        [Route("vediStorico")]
        public IActionResult VediStoricoOrdini(DateOnly dataInizio, DateOnly dataFine, string emailUtente = null)
        {
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