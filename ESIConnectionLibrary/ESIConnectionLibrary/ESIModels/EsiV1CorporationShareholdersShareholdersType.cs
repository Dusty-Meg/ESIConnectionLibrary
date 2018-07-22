using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV1CorporationShareholdersShareholdersType
    {
        [EnumMember(Value = "character")]
        Character,

        [EnumMember(Value = "corporation")]
        Corporation
    }
}