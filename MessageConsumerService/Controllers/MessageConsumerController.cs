using MessageConsumerService.Models;
using MessageConsumerService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MessageConsumerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageConsumerController : ControllerBase
    {

        private readonly ILogger<MessageConsumerController> _logger;

        public MessageConsumerController(ILogger<MessageConsumerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            string noteToUser = string.Empty;

            Message messageToConsume;

            IMessageConsumer msgConsumer = MessageConsumerFactory.CreateNewMessageConsumer();
            if (msgConsumer.ConsumeMessage(out messageToConsume))
            {
                noteToUser = JsonConvert.SerializeObject(messageToConsume); // Returns the message as a json string to the user
            }
            else
            {
                noteToUser = "Error: Message could not be consumed...";
            }

            return noteToUser;

        }
    }
}
