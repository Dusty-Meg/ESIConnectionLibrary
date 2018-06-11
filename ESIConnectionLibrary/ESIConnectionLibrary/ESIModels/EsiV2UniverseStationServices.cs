using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV2UniverseStationServices
    {
        [EnumMember(Value = "bounty-missions")]
        BountyMissions,
        [EnumMember(Value = "assasination-missions")]
        AssasinationMissions,
        [EnumMember(Value = "courier-missions")]
        CourierMissions,
        [EnumMember(Value = "interbus")]
        Interbus,
        [EnumMember(Value = "reprocessing-plant")]
        ReprocessingPlant,
        [EnumMember(Value = "refinery")]
        Refinery,
        [EnumMember(Value = "market")]
        Market,
        [EnumMember(Value = "black-market")]
        BlackMarket,
        [EnumMember(Value = "stock-exchange")]
        StockExchange,
        [EnumMember(Value = "cloning")]
        Cloning,
        [EnumMember(Value = "surgery")]
        Surgery,
        [EnumMember(Value = "dna-therapy")]
        DnaTherapy,
        [EnumMember(Value = "repair-facilities")]
        RepairFacilities,
        [EnumMember(Value = "factory")]
        Factory,
        [EnumMember(Value = "labratory")]
        Labratory,
        [EnumMember(Value = "gambling")]
        Gambling,
        [EnumMember(Value = "fitting")]
        Fitting,
        [EnumMember(Value = "paintshop")]
        Paintshop,
        [EnumMember(Value = "news")]
        News,
        [EnumMember(Value = "storage")]
        Storage,
        [EnumMember(Value = "insurance")]
        Insurance,
        [EnumMember(Value = "docking")]
        Docking,
        [EnumMember(Value = "office-rental")]
        OfficeRental,
        [EnumMember(Value = "jump-clone-facility")]
        JumpCloneFacility,
        [EnumMember(Value = "loyalty-point-store")]
        LoyaltyPointStore,
        [EnumMember(Value = "navy-offices")]
        NavyOffices,
        [EnumMember(Value = "security-offices")]
        SecurityOffices
    }
}