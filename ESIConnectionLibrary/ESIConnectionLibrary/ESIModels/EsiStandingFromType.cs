using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiStandingFromType
    {
        [EnumMember(Value = "agent")]
        Agent,

        [EnumMember(Value = "npc_corp")]
        NpcCorp,

        [EnumMember(Value = "faction")]
        Faction
    }
}