namespace MessageConsumerService.Repository
{
    public interface IDecryptor
    {
        string DecryptMessage(string msg);
    }
}
