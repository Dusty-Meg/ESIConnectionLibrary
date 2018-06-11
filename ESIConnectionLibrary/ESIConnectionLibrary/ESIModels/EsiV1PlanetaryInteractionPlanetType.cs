using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV1PlanetaryInteractionPlanetType
    {
        [EnumMember(Value = "temperate")]
        Temperate,

        [EnumMember(Value = "barren")]
        Barren,

        [EnumMember(Value = "oceanic")]
        Oceanic,

        [EnumMember(Value = "ice")]
        Ice,

        [EnumMember(Value = "gas")]
        Gas,

        [EnumMember(Value = "lava")]
        Lava,

        [EnumMember(Value = "storm")]
        Storm,

        [EnumMember(Value = "plasma")]
        Plasma
    }
}