using MessageProducerService.Models;
using MessageProducerService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MessageProducerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageProducerController : ControllerBase
    {

        private readonly ILogger<MessageProducerController> _logger;

        public MessageProducerController(ILogger<MessageProducerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {

            string noteToUser = string.Empty;

            IMessageGenerator msgGenerator = MessageGeneratorFactory.CreateNewMessageGenerator();
            Message messageToSend = msgGenerator.GenerateNewMessage();

            IMessageProducer msgProducer = MessageProducerFactory.CreateNewMessageProducer();
            if (msgProducer.ProduceMessage(messageToSend))
            {
                noteToUser = "Message has been produced successfully!";
            }
            else
            {
                noteToUser = "Error: Message could not be produced...";
            }

            return noteToUser;
        }
    }
}
