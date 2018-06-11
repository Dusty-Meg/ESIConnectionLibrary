using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV1PlanetaryInteractionCorporationCustomsOfficeStandingLevel
    {
        [EnumMember(Value = "bad")]
        Bad,

        [EnumMember(Value = "excellent")]
        Excellent,

        [EnumMember(Value = "good")]
        Good,

        [EnumMember(Value = "neutral")]
        Neutral,

        [EnumMember(Value = "terrible")]
        Terrible
    }
}