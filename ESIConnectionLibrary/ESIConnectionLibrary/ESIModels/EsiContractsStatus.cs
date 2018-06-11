using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiContractsStatus
    {
        [EnumMember(Value = "outstanding")]
        Outstanding,

        [EnumMember(Value = "in_progress")]
        InProgress,

        [EnumMember(Value = "finished_issuer")]
        FinishedIssuer,

        [EnumMember(Value = "finished_contractor")]
        FinishedContractor,

        [EnumMember(Value = "finished")]
        Finished,

        [EnumMember(Value = "cancelled")]
        Cancelled,

        [EnumMember(Value = "rejected")]
        Rejected,

        [EnumMember(Value = "failed")]
        Failed,

        [EnumMember(Value = "deleted")]
        Deleted,

        [EnumMember(Value = "reversed")]
        Reversed
    }
}