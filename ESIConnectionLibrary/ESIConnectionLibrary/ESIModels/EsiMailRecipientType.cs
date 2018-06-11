using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiMailRecipientType
    {
        [EnumMember(Value = "alliance")]
        Alliance,

        [EnumMember(Value = "character")]
        Character,

        [EnumMember(Value = "corporation")]
        Corporation,

        [EnumMember(Value = "mailing_list")]
        MailingList
    }
}