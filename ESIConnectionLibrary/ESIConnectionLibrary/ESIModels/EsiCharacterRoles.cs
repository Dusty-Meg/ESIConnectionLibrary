using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiCharacterRoles
    {
        [EnumMember(Value = "Account_Take_1")]
        AccountTake1,

        [EnumMember(Value = "Account_Take_2")]
        AccountTake2,

        [EnumMember(Value = "Account_Take_3")]
        AccountTake3,

        [EnumMember(Value = "Account_Take_4")]
        AccountTake4,

        [EnumMember(Value = "Account_Take_5")]
        AccountTake5,

        [EnumMember(Value = "Account_Take_6")]
        AccountTake6,

        [EnumMember(Value = "Account_Take_7")]
        AccountTake7,

        [EnumMember(Value = "Accountant")]
        Accountant,

        [EnumMember(Value = "Auditor")]
        Auditor,

        [EnumMember(Value = "Communications_Officer")]
        CommunicationsOfficer,

        [EnumMember(Value = "Config_Equipment")]
        ConfigEquipment,

        [EnumMember(Value = "Config_Starbase_Equipment")]
        ConfigStarbaseEquipment,

        [EnumMember(Value = "Container_Take_1")]
        ContainerTake1,

        [EnumMember(Value = "Container_Take_2")]
        ContainerTake2,

        [EnumMember(Value = "Container_Take_3")]
        ContainerTake3,

        [EnumMember(Value = "Container_Take_4")]
        ContainerTake4,

        [EnumMember(Value = "Container_Take_5")]
        ContainerTake5,

        [EnumMember(Value = "Container_Take_6")]
        ContainerTake6,

        [EnumMember(Value = "Container_Take_7")]
        ContainerTake7,

        [EnumMember(Value = "Contract_Manager")]
        ContractManager,

        [EnumMember(Value = "Diplomat")]
        Diplomat,

        [EnumMember(Value = "Director")]
        Director,

        [EnumMember(Value = "Factory_Manager")]
        FactoryManager,

        [EnumMember(Value = "Fitting_Manager")]
        FittingManager,

        [EnumMember(Value = "Hangar_Query_1")]
        HangarQuery1,

        [EnumMember(Value = "Hangar_Query_2")]
        HangarQuery2,

        [EnumMember(Value = "Hangar_Query_3")]
        HangarQuery3,

        [EnumMember(Value = "Hangar_Query_4")]
        HangarQuery4,

        [EnumMember(Value = "Hangar_Query_5")]
        HangarQuery5,

        [EnumMember(Value = "Hangar_Query_6")]
        HangarQuery6,

        [EnumMember(Value = "Hangar_Query_7")]
        HangarQuery7,

        [EnumMember(Value = "Hangar_Take_1")]
        HangarTake1,

        [EnumMember(Value = "Hangar_Take_2")]
        HangarTake2,

        [EnumMember(Value = "Hangar_Take_3")]
        HangarTake3,

        [EnumMember(Value = "Hangar_Take_4")]
        HangarTake4,

        [EnumMember(Value = "Hangar_Take_5")]
        HangarTake5,

        [EnumMember(Value = "Hangar_Take_6")]
        HangarTake6,

        [EnumMember(Value = "Hangar_Take_7")]
        HangarTake7,

        [EnumMember(Value = "Junior_Accountant")]
        JuniorAccountant,

        [EnumMember(Value = "Personnel_Manager")]
        PersonnelManager,

        [EnumMember(Value = "Rent_Factory_Facility")]
        RentFactoryFacility,

        [EnumMember(Value = "Rent_Office")]
        RentOffice,

        [EnumMember(Value = "Rent_Research_Facility")]
        RentResearchFacility,

        [EnumMember(Value = "Security_Officer")]
        SecurityOfficer,

        [EnumMember(Value = "Starbase_Defense_Operator")]
        StarbaseDefenseOperator,

        [EnumMember(Value = "Starbase_Fuel_Technician")]
        StarbaseFuelTechnician,

        [EnumMember(Value = "Station_Manager")]
        StationManager,

        [EnumMember(Value = "Terrestrial_Combat_Officer")]
        TerrestrialCombatOfficer,

        [EnumMember(Value = "Terrestrial_Logistics_Officer")]
        TerrestrialLogisticsOfficer,

        [EnumMember(Value = "Trader")]
        Trader
    }
}