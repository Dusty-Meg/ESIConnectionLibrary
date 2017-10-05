using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESIConnectionLibrary.PublicModels
{
    public class GetSingleKillmail
    {
        public IList<GetSingleKillmailAttacker> Attackers { get; set; }
        public int KillmailId { get; set; }
        public DateTime KillmailTime { get; set; }
        public int? MoonId { get; set; }
        public int SolarSystemId { get; set; }
        public GetSingleKillmailVictim Victim { get; set; }
        public int? WarId { get; set; }
    }

    public class GetSingleKillmailVictim
    {
        public int? AllianceId { get; set; }
        public int? CharacterId { get; set; }
        public int? CorporationId { get; set; }
        public int DamageTaken { get; set; }
        public int? FactionId { get; set; }
        public IList<GetSingleKillmailItem> Items { get; set; }
        public GetSingleKillmailPosition Position { get; set; }
        public int ShipTypeId { get; set; }
    }

    public class GetSingleKillmailPosition
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }

    public class GetSingleKillmailItem
    {
        public int Flag { get; set; }
        public int ItemTypeId { get; set; }
        public IList<GetSingleKillmailItem> Items { get; set; }
        public int? QuantityDestroyed { get; set; }
        public int? QuantityDropped { get; set; }
        public int Singleton { get; set; }
        public InvFlags ItemFlag => (InvFlags)Flag;
    }

    public class GetSingleKillmailAttacker
    {
        public int? AllianceId { get; set; }
        public int? CharacterId { get; set; }
        public int? CorporationId { get; set; }
        public int DamageDone { get; set; }
        public int? FactionId { get; set; }
        public bool FinalBlow { get; set; }
        public float SecurityStatus { get; set; }
        public int? ShipTypeId { get; set; }
        public int? WeaponTypeId { get; set; }
    }

    public enum InvFlags
    {
        None = 0,
        Wallet = 1,
        Offices = 2,
        Wardrobe = 3,
        Hangar = 4,
        Cargo = 5,
        OfficeImpound = 6,
        Skill = 7,
        Reward = 8,
        LoSlot0 = 11,
        LoSlot1 = 12,
        LoSlot2 = 13,
        LoSlot3 = 14,
        LoSlot4 = 15,
        LoSlot5 = 16,
        LoSlot6 = 17,
        LoSlot7 = 18,
        MedSlot0 = 19,
        MedSlot1 = 20,
        MedSlot2 = 21,
        MedSlot3 = 22,
        MedSlot4 = 23,
        MedSlot5 = 24,
        MedSlot6 = 25,
        MedSlot7 = 26,
        HiSlot0 = 27,
        HiSlot1 = 28,
        HiSlot2 = 29,
        HiSlot3 = 30,
        HiSlot4 = 31,
        HiSlot5 = 32,
        HiSlot6 = 33,
        HiSlot7 = 34,
        Fixed_Slot = 35,
        AssetSafety = 36,
        Capsule = 56,
        Pilot = 57,
        Skill_In_Training = 61,
        CorpMarket = 62,
        Locked = 63,
        Unlocked = 64,
        Office_Slot_1 = 70,
        Office_Slot_2 = 71,
        Office_Slot_3 = 72,
        Office_Slot_4 = 73,
        Office_Slot_5 = 74,
        Office_Slot_6 = 75,
        Office_Slot_7 = 76,
        Office_Slot_8 = 77,
        Office_Slot_9 = 78,
        Office_Slot_10 = 79,
        Office_Slot_11 = 80,
        Office_Slot_12 = 81,
        Office_Slot_13 = 82,
        Office_Slot_14 = 83,
        Office_Slot_15 = 84,
        Office_Slot_16 = 85,
        Bonus = 86,
        DroneBay = 87,
        Booster = 88,
        Implant = 89,
        ShipHangar = 90,
        ShipOffline = 91,
        RigSlot0 = 92,
        RigSlot1 = 93,
        RigSlot2 = 94,
        RigSlot3 = 95,
        RigSlot4 = 96,
        RigSlot5 = 97,
        RigSlot6 = 98,
        RigSlot7 = 99,
        CorpSAG1 = 115,
        CorpSAG2 = 116,
        CorpSAG3 = 117,
        CorpSAG4 = 118,
        CorpSAG5 = 119,
        CorpSAG6 = 120,
        CorpSAG7 = 121,
        SecondaryStorage = 122,
        SubSystem0 = 125,
        SubSystem1 = 126,
        SubSystem2 = 127,
        SubSystem3 = 128,
        SubSystem4 = 129,
        SubSystem5 = 130,
        SubSystem6 = 131,
        SubSystem7 = 132,
        SpecializedFuelBay = 133,
        SpecializedOreHold = 134,
        SpecializedGasHold = 135,
        SpecializedMineralHold = 136,
        SpecializedSalvageHold = 137,
        SpecializedShipHold = 138,
        SpecializedSmallShipHold = 139,
        SpecializedMediumShipHold = 140,
        SpecializedLargeShipHold = 141,
        SpecializedIndustrialShipHold = 142,
        SpecializedAmmoHold = 143,
        StructureActive = 144,
        StructureInactive = 145,
        JunkyardReprocessed = 146,
        JunkyardTrashed = 147,
        SpecializedCommandCenterHold = 148,
        SpecializedPlanetaryCommoditiesHold = 149,
        PlanetSurface = 150,
        SpecializedMaterialBay = 151,
        DustCharacterDatabank = 152,
        DustCharacterBattle = 153,
        QuafeBay = 154,
        FleetHangar = 155,
        HiddenModifiers = 156,
        StructureOffline = 157,
        FighterBay = 158,
        FighterTube0 = 159,
        FighterTube1 = 160,
        FighterTube2 = 161,
        FighterTube3 = 162,
        FighterTube4 = 163,
        StructureServiceSlot0 = 164,
        StructureServiceSlot1 = 165,
        StructureServiceSlot2 = 166,
        StructureServiceSlot3 = 167,
        StructureServiceSlot4 = 168,
        StructureServiceSlot5 = 169,
        StructureServiceSlot6 = 170,
        StructureServiceSlot7 = 171,
        StructureFuel = 172,
        Deliveries = 173,
        CrateLoot = 174,
        BoosterBay = 176,
        SubsystemBay = 177
    }

}
