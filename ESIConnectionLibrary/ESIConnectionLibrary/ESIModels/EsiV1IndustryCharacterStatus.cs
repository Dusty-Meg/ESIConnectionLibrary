using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV1IndustryCharacterStatus
    {
        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "cancelled")]
        Cancelled,

        [EnumMember(Value = "delivered")]
        Delivered,

        [EnumMember(Value = "paused")]
        Paused,

        [EnumMember(Value = "ready")]
        Ready,

        [EnumMember(Value = "reverted")]
        Reverted
    }
}
