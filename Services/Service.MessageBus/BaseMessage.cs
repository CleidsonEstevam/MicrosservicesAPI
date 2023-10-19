using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.MessageBus
{
    public class BaseMessage
    {
        [JsonIgnore]
        public long Id { get; set; }
        public DateTime MessageCreated { get; set; }
    }
}
