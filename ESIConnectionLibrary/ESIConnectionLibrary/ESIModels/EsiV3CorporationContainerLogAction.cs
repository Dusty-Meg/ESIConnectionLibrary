using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV3CorporationContainerLogAction
    {
        [EnumMember(Value = "add")]
        Add,

        [EnumMember(Value = "assemble")]
        Assemble,

        [EnumMember(Value = "configure")]
        Configure,

        [EnumMember(Value = "enter_password")]
        EnterPassword,

        [EnumMember(Value = "lock")]
        Lock,

        [EnumMember(Value = "move")]
        Move,

        [EnumMember(Value = "repackage")]
        Repackage,

        [EnumMember(Value = "set_name")]
        SetName,

        [EnumMember(Value = "set_password")]
        SetPassword,

        [EnumMember(Value = "unlock")]
        Unlock
    }
}