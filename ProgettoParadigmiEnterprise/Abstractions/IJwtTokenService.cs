using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Abstractions
{
    public interface IJwtTokenService
    {
        public string GenerateToken(Utente _utente);
    }
}
