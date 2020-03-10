using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiLocationType
    {
        [EnumMember(Value = "station")]
        Station,

        [EnumMember(Value = "solar_system")]
        SolarSystem,

        [EnumMember(Value = "item")]
        Item,

        [EnumMember(Value = "other")]
        Other
    }
}