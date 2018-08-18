using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV2FwSystemsContested
    {
        [EnumMember(Value = "captured")]
        Captured,

        [EnumMember(Value = "contested")]
        Contested,

        [EnumMember(Value = "uncontested")]
        Uncontested,

        [EnumMember(Value = "vulnerable")]
        Vulnerable
    }
}