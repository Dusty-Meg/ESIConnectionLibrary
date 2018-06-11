using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiMarketState
    {
        [EnumMember(Value = "cancelled")]
        Cancelled,

        [EnumMember(Value = "expired")]
        Expired
    }
}