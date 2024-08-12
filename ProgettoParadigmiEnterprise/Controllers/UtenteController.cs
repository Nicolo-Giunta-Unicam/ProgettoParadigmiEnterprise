using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using ProgettoParadigmiEnterprise.Abstractions;
using ProgettoParadigmiEnterprise.Requests;
using ProgettoParadigmiEnterprise.Utility;

namespace ProgettoParadigmiEnterprise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService utenteService;

        public UtenteController(IUtenteService _utenteService)
        {
            utenteService = _utenteService;
        }
        /// <summary>
        /// Effettua la registrazione
        /// </summary>
        /// <param name="request">Una richiesta contenente le informazioni di un utente non ancora registrato</param>
        [HttpPost]
        [Route("registrazione")]
        public IActionResult Registrazione([FromBody] RegistrazioneRequest request)
        {
            if(utenteService.Registra(request.email, PasswordEncrypter.EncryptPassword(request.password), request.nome, request.cognome))
                return Ok("Registrazione Effettuata");
            else return BadRequest("Registrazione Fallita");
        }
        /// <summary>
        /// Effettua l'accesso
        /// </summary>
        /// <param name="request">Richiesta contenente la mail e la password di un utente già registrato</param>
        /// <returns>In caso di successo restituisce il token JWT per l'autorizzazione</returns>
        [HttpPost]
        [Route("accesso")]
        public IActionResult Accesso([FromBody] AccessoRequest request)
        {
            string token = utenteService.Accedi(request.email, PasswordEncrypter.EncryptPassword(request.password));
            if (token != null)
                return Ok("Accesso Effettuato "+token);
            else return BadRequest("Accesso Fallito");
        }

    }
}