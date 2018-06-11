using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiRevokeTokenType
    {
        [EnumMember(Value = "accessToken")]
        AccessToken,

        [EnumMember(Value = "refreshToken")]
        RefreshToken
    }
}