using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV6WalletCharacterJournalContextIdType
    {
        [EnumMember(Value = "structure_id")]
        StructureId,

        [EnumMember(Value = "station_id")]
        StationId,

        [EnumMember(Value = "market_transaction_id")]
        MarketTransactionId,

        [EnumMember(Value = "character_id")]
        CharacterId,

        [EnumMember(Value = "corporation_id")]
        CorporationId,

        [EnumMember(Value = "alliance_id")]
        AllianceId,

        [EnumMember(Value = "eve_system")]
        EveSystem,

        [EnumMember(Value = "industry_job_id")]
        IndustryJobId,

        [EnumMember(Value = "contract_id")]
        ContractId,

        [EnumMember(Value = "planet_id")]
        PlanetId,

        [EnumMember(Value = "system_id")]
        SystemId,

        [EnumMember(Value = "type_id")]
        TypeId
    }
}