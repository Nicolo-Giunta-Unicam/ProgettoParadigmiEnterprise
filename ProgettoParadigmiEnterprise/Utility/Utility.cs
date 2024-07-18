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
}
