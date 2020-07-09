using System;
using System.Text.Json.Serialization;

namespace MessageProducerService.Models
{
    public class Message // Own message class (model) - No dependency between the Producer project and the Consumer project
    {
        public string FullName { get; set; }
        public string Profession { get; set; }
        public DateTime Date{ get; set; }
        public int Age { get; set; }

    }
}
