using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV2SearchSearchCategories
    {
        [EnumMember(Value = "agent")]
        Agent,

        [EnumMember(Value = "alliance")]
        Alliance,

        [EnumMember(Value = "character")]
        Character,

        [EnumMember(Value = "constellation")]
        Constellation,

        [EnumMember(Value = "corporation")]
        Corporation,

        [EnumMember(Value = "faction")]
        Faction,

        [EnumMember(Value = "inventory_type")]
        InventoryType,

        [EnumMember(Value = "region")]
        Region,

        [EnumMember(Value = "solar_system")]
        SolarSystem,

        [EnumMember(Value = "station")]
        Station
    }
}