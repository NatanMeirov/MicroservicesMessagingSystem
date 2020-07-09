using MessageProducerService.Models;

namespace MessageProducerService.Repository
{
    public interface IMessageGenerator // Gives the ability to create in the future a Message Generator from a DB for example...
    {
        Message GenerateNewMessage();
    }
}
