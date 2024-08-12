using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Abstractions
{
    public interface IJwtTokenService
    {
        /// <summary>
        /// Genera e restituisce un token JWT per un dato utente
        /// </summary>
        public string GenerateToken(Utente _utente);
    }
}
