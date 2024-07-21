using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Utility
{
    public class PasswordEncrypter
    {
        public static string EncryptPassword(string _password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(_password);
            data = System.Security.Cryptography.SHA256.HashData(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }
    }

    public class CalcolatorePrezzoOrdine
    {
        const decimal scontoPastoCompleto = 0.10m; // Sconto del 10%
        public static decimal CalcolaTotale(Ordine _ordine)
        {
            decimal totale = 0;

            // Separo le portate per tipo e le ordino per prezzo 
            var primi = _ordine.portate.Where(p => p.tipologia == TipologiaPortata.Primo).OrderByDescending(p => p.prezzo).ToList();
            var secondi = _ordine.portate.Where(p => p.tipologia == TipologiaPortata.Secondo).OrderByDescending(p => p.prezzo).ToList();
            var contorni = _ordine.portate.Where(p => p.tipologia == TipologiaPortata.Contorno).OrderByDescending(p => p.prezzo).ToList();
            var dolci = _ordine.portate.Where(p => p.tipologia == TipologiaPortata.Dolce).OrderByDescending(p => p.prezzo).ToList();

            // Calcolo il numero di pasti completi
            int numeroPastiCompleti = Math.Min(Math.Min(primi.Count, secondi.Count), Math.Min(contorni.Count, dolci.Count));

            // Applico lo sconto ai pasti completi
            for (int i = 0; i < numeroPastiCompleti; i++)
            {
                totale += primi[i].prezzo * (1 - scontoPastoCompleto);
                totale += secondi[i].prezzo * (1 - scontoPastoCompleto);
                totale += contorni[i].prezzo * (1 - scontoPastoCompleto);
                totale += dolci[i].prezzo * (1 - scontoPastoCompleto);
            }

            // Aggiunge i prezzi delle restanti portate senza sconto
            totale += primi.Skip(numeroPastiCompleti).Sum(p => p.prezzo);
            totale += secondi.Skip(numeroPastiCompleti).Sum(p => p.prezzo);
            totale += contorni.Skip(numeroPastiCompleti).Sum(p => p.prezzo);
            totale += dolci.Skip(numeroPastiCompleti).Sum(p => p.prezzo);

            return totale;

        }

    }
}
