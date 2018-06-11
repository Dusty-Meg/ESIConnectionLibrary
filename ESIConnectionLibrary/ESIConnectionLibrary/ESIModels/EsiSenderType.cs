using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiSenderType
    {
        [EnumMember(Value = "character")]
        Character,

        [EnumMember(Value = "corporation")]
        Corporation,

        [EnumMember(Value = "alliance")]
        Alliance,

        [EnumMember(Value = "faction")]
        Faction,

        [EnumMember(Value = "other")]
        Other
    }
}