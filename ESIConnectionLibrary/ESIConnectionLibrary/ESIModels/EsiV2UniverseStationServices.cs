using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV2UniverseStationServices
    {
        [EnumMember(Value = "bounty-missions")]
        bountyMissions,
        [EnumMember(Value = "assasination-missions")]
        assasinationMissions,
        [EnumMember(Value = "courier-missions")]
        courierMissions,
        [EnumMember(Value = "interbus")]
        interbus,
        [EnumMember(Value = "reprocessing-plant")]
        reprocessingPlant,
        [EnumMember(Value = "refinery")]
        refinery,
        [EnumMember(Value = "market")]
        market,
        [EnumMember(Value = "black-market")]
        blackMarket,
        [EnumMember(Value = "stock-exchange")]
        stockExchange,
        [EnumMember(Value = "cloning")]
        cloning,
        [EnumMember(Value = "surgery")]
        surgery,
        [EnumMember(Value = "dna-therapy")]
        dnaTherapy,
        [EnumMember(Value = "repair-facilities")]
        repairFacilities,
        [EnumMember(Value = "factory")]
        factory,
        [EnumMember(Value = "labratory")]
        labratory,
        [EnumMember(Value = "gambling")]
        gambling,
        [EnumMember(Value = "fitting")]
        fitting,
        [EnumMember(Value = "paintshop")]
        paintshop,
        [EnumMember(Value = "news")]
        news,
        [EnumMember(Value = "storage")]
        storage,
        [EnumMember(Value = "insurance")]
        insurance,
        [EnumMember(Value = "docking")]
        docking,
        [EnumMember(Value = "office-rental")]
        officeRental,
        [EnumMember(Value = "jump-clone-facility")]
        jumpCloneFacility,
        [EnumMember(Value = "loyalty-point-store")]
        loyaltyPointStore,
        [EnumMember(Value = "navy-offices")]
        navyOffices,
        [EnumMember(Value = "security-offices")]
        securityOffices
    }
}