using MessageConsumerService.Models;

namespace MessageConsumerService.Repository
{
    public interface IMessageConsumer
    {
        bool ConsumeMessage(out Message msg);
    }
}
