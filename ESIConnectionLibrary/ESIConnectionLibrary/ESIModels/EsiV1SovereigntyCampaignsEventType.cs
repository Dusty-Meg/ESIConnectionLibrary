using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV1SovereigntyCampaignsEventType
    {
        [EnumMember(Value = "tcu_defense")]
        TcuDefense,

        [EnumMember(Value = "ihub_defense")]
        IhubDefense,

        [EnumMember(Value = "station_defense")]
        StationDefense,

        [EnumMember(Value = "station_freeport")]
        StationFreeport
    }
}