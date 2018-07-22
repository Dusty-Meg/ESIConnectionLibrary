using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV3CalendarResponse
    {
        [EnumMember(Value = "accepted")]
        Accepted,

        [EnumMember(Value = "declined")]
        Declined,

        [EnumMember(Value = "tentative")]
        Tentative
    }
}