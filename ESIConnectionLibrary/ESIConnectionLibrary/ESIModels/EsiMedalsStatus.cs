using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiMedalsStatus
    {
        [EnumMember(Value = "public")]
        Public,

        [EnumMember(Value = "private")]
        Private
    }
}