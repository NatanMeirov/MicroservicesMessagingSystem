namespace MessageProducerService.Repository
{
    public interface IEncryptor
    {
        string EncryptMessage(string msg);
    }
}
