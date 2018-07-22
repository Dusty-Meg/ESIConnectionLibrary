using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV3CalendarEventOwnerType
    {
        [EnumMember(Value = "eve_server")]
        EveServer,

        [EnumMember(Value = "corporation")]
        Corporation,

        [EnumMember(Value = "faction")]
        Faction,

        [EnumMember(Value = "character")]
        Character,

        [EnumMember(Value = "alliance")]
        Alliance
    }
}