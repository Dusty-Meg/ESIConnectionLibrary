using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV1CalendarSummaryEventResponses
    {
        [EnumMember(Value = "declined")]
        Declined,

        [EnumMember(Value = "not_responded")]
        NotResponded,

        [EnumMember(Value = "accepted")]
        Accepted,

        [EnumMember(Value = "tentative")]
        Tentative
    }
}