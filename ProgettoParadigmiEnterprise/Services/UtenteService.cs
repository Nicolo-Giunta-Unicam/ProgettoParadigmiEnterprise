using Microsoft.Extensions.Options;
using ProgettoParadigmiEnterprise.Abstractions;
using ProgettoParadigmiEnterprise.Model;
using ProgettoParadigmiEnterprise.Repositories;

namespace ProgettoParadigmiEnterprise.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository utenteRepository;
        private readonly JwtTokenService jwtTokenService;
        public UtenteService(UtenteRepository _utenteRepository, JwtTokenService _jwtTokenService)
        {
            utenteRepository = _utenteRepository;
            jwtTokenService = _jwtTokenService;
        }

        public bool Registra(string _email, string _password, string _nome, string _cognome)
        {
            if (utenteRepository.GetUtenteByEmail(_email) != null) return false;
            Utente utente = new Utente(_email, _nome, _cognome, _password, Ruolo.Cliente);
            utenteRepository.Add(utente);
            utenteRepository.Save();
            return true;
        }

        public string Accedi(string _email, string _password)
        {
            if (utenteRepository.CheckPasswordCorretta(_password, _email))
                return jwtTokenService.GenerateToken(utenteRepository.GetUtenteByEmail(_email));
            else return null;
        }
    }
}
