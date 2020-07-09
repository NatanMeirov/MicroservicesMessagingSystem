using MessageProducerService.Models;

namespace MessageProducerService.Repository
{
    public interface IMessageProducer // Allows to implement another Message Producer in the future (in other way). And the same for all other interfaces in this solution.
    {
        bool ProduceMessage(Message msg);
    }
}
