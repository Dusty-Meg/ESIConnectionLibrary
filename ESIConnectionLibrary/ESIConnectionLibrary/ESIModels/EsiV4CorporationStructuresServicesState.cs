using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV4CorporationStructuresServicesState
    {
        [EnumMember(Value = "online")]
        Online,

        [EnumMember(Value = "offline")]
        Offline,

        [EnumMember(Value = "cleanup")]
        Cleanup
    }
}