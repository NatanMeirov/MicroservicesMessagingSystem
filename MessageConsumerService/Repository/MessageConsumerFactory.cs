namespace MessageConsumerService.Repository
{
    public static class MessageConsumerFactory  // Factory class - allows to control the return type in the future (change only here and not in the client side), and maybe add some logic to select which software should be used
    {
        public static IMessageConsumer CreateNewMessageConsumer()
        {
            return new RabbitMQMessageConsumer();
        }
    }
}
