using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiMarketRange
    {
        [EnumMember(Value = "one")]
        One,

        [EnumMember(Value = "ten")]
        Ten,

        [EnumMember(Value = "two")]
        Two,

        [EnumMember(Value = "twenty")]
        Twenty,

        [EnumMember(Value = "three")]
        Three,

        [EnumMember(Value = "thirty")]
        Thirty,

        [EnumMember(Value = "four")]
        Four,

        [EnumMember(Value = "forty")]
        Forty,

        [EnumMember(Value = "five")]
        Five,

        [EnumMember(Value = "region")]
        Region,

        [EnumMember(Value = "solarsystem")]
        Solarsystem,

        [EnumMember(Value = "station")]
        Station
    }
}