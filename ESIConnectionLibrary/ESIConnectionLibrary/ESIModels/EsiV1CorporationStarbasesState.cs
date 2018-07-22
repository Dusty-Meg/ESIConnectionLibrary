using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV1CorporationStarbasesState
    {
        [EnumMember(Value = "offline")]
        Offline,

        [EnumMember(Value = "online")]
        Online,

        [EnumMember(Value = "onlining")]
        Onlining,

        [EnumMember(Value = "reinforced")]
        Reinforced,

        [EnumMember(Value = "unanchoring")]
        Unanchoring
    }
}