namespace Sprencia_Api.Services.Security
{
    public interface IEncryptService
    {
        string EncryptString(string text);
        string DecryptString(string cipherText);

    }
}
