using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV2CorporationStarbaseRoles
    {
        [EnumMember(Value = "alliance_member")]
        AllianceMember,

        [EnumMember(Value = "config_starbase_equipment_role")]
        ConfigStarbaseEquipmentRole,

        [EnumMember(Value = "corporation_member")]
        CorporationMember,

        [EnumMember(Value = "starbase_fuel_technician_role")]
        StarbaseFuelTechnicianRole
    }
}