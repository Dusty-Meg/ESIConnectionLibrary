using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV1ContractsPublicType
    {
        [EnumMember(Value = "unknown")]
        Unknown,

        [EnumMember(Value = "item_exchange")]
        ItemExchange,

        [EnumMember(Value = "auction")]
        Auction,

        [EnumMember(Value = "courier")]
        Courier,

        [EnumMember(Value = "loan")]
        Loan
    }
}