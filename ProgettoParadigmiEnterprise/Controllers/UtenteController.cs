using Microsoft.AspNetCore.Mvc;
using ProgettoParadigmiEnterprise.Requests;

namespace ProgettoParadigmiEnterprise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtenteController : ControllerBase
    {
        [HttpPost]
        [Route("registrazione")]
        public IActionResult Registrazione([FromBody] RegistrazioneRequest request)
        {
            return Ok();
        }
    }
}