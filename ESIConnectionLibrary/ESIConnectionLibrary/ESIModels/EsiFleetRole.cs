using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiFleetRole
    {
        [EnumMember(Value = "fleet_commander")]
        FleetCommander,

        [EnumMember(Value = "squad_commander")]
        SquadCommander,

        [EnumMember(Value = "squad_member")]
        SquadMember,

        [EnumMember(Value = "wing_commander")]
        WingCommander
    }
}