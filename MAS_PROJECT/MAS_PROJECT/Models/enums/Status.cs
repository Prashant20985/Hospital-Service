using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models.enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        BOOKED,
        CANCELLED,
        AVAILABLE
    }
}
