using System;
using MessageProducerService.Models;

namespace MessageProducerService.Repository
{
    public class StaticMessageGenerator : IMessageGenerator
    {
        public Message GenerateNewMessage()
        {
            Message msg = new Message() { FullName = "Natan Meirov", Profession = "Software Engineer", Age = 24, Date = DateTime.Now };
            
            return msg;
        }
    }
}
