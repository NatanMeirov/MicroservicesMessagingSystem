namespace MessageProducerService.Repository
{
    public static class MessageGeneratorFactory // Factory class - allows to control the return type in the future (change only here and not in the client side), and maybe add some logic to select which software should be used
    {
        public static IMessageGenerator CreateNewMessageGenerator()
        {
            return new StaticMessageGenerator();
        }
    }
}
