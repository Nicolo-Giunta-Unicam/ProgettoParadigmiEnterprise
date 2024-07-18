using Microsoft.AspNetCore.Mvc;
using ProgettoParadigmiEnterprise.Abstractions;
using ProgettoParadigmiEnterprise.Requests;

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

        [HttpPost]
        [Route("registrazione")]
        public IActionResult Registrazione([FromBody] RegistrazioneRequest request)
        {
            if(utenteService.Registra(request.email, request.password, request.nome, request.cognome))
                return Ok("Registrazione Effettuata");
            else return BadRequest("Registrazione Fallita");
        }

        [HttpPost]
        [Route("accesso")]
        public IActionResult Accesso([FromBody] AccessoRequest request)
        {
            if (utenteService.Accedi(request.email, request.password) != null)
                return Ok("Accesso Effettuato");
            else return BadRequest("Accesso Fallito");
        }
    }
}