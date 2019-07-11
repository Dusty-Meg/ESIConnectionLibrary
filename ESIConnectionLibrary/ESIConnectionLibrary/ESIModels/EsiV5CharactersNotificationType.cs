using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV5CharactersNotificationType
    {
        AcceptedAlly,
        AcceptedSurrender,
        AllAnchoringMsg,
        AllMaintenanceBillMsg,
        AllStrucInvulnerableMsg,
        AllStructVulnerableMsg,
        AllWarCorpJoinedAllianceMsg,
        AllWarDeclaredMsg,
        AllWarInvalidatedMsg,
        AllWarRetractedMsg,
        AllWarSurrenderMsg,
        AllianceCapitalChanged,
        AllianceWarDeclaredV2,
        AllyContractCancelled,
        AllyJoinedWarAggressorMsg,
        AllyJoinedWarAllyMsg,
        AllyJoinedWarDefenderMsg,
        BattlePunishFriendlyFire,
        BillOutOfMoneyMsg,
        BillPaidCorpAllMsg,
        BountyClaimMsg,

        [EnumMember(Value = "BountyESSShared")]
        BountyEssShared,

        [EnumMember(Value = "BountyESSTaken")]
        BountyEssTaken,
        BountyPlacedAlliance,
        BountyPlacedChar,
        BountyPlacedCorp,
        BountyYourBountyClaimed,
        BuddyConnectContactAdd,
        CharAppAcceptMsg,
        CharAppRejectMsg,
        CharAppWithdrawMsg,
        CharLeftCorpMsg,
        CharMedalMsg,
        CharTerminationMsg,
        CloneActivationMsg,
        CloneActivationMsg2,
        CloneMovedMsg,
        CloneRevokedMsg1,
        CloneRevokedMsg2,
        CombatOperationFinished,
        ContactAdd,
        ContactEdit,
        ContainerPasswordMsg,
        CorpAllBillMsg,
        CorpAppAcceptMsg,
        CorpAppInvitedMsg,
        CorpAppNewMsg,
        CorpAppRejectCustomMsg,
        CorpAppRejectMsg,
        CorpBecameWarEligible,
        CorpDividendMsg,
        CorpFriendlyFireDisableTimerCompleted,
        CorpFriendlyFireDisableTimerStarted,
        CorpFriendlyFireEnableTimerCompleted,
        CorpFriendlyFireEnableTimerStarted,
        CorpKicked,
        CorpLiquidationMsg,

        [EnumMember(Value = "CorpNewCEOMsg")]
        CorpNewCeoMsg,
        CorpNewsMsg,
        CorpNoLongerWarEligible,
        CorpOfficeExpirationMsg,
        CorpStructLostMsg,
        CorpTaxChangeMsg,

        [EnumMember(Value = "CorpVoteCEORevokedMsg")]
        CorpVoteCeoRevokedMsg,
        CorpVoteMsg,
        CorpWarDeclaredMsg,
        CorpWarDeclaredV2,
        CorpWarFightingLegalMsg,
        CorpWarInvalidatedMsg,
        CorpWarRetractedMsg,
        CorpWarSurrenderMsg,
        CustomsMsg,
        DeclareWar,
        DistrictAttacked,
        DustAppAcceptedMsg,
        EntosisCaptureStarted,

        [EnumMember(Value = "FWAllianceKickMsg")]
        FwAllianceKickMsg,

        [EnumMember(Value = "FWAllianceWarningMsg")]
        FwAllianceWarningMsg,

        [EnumMember(Value = "FWCharKickMsg")]
        FwCharKickMsg,

        [EnumMember(Value = "FWCharRankGainMsg")]
        FwCharRankGainMsg,

        [EnumMember(Value = "FWCharRankLossMsg")]
        FwCharRankLossMsg,

        [EnumMember(Value = "FWCharWarningMsg")]
        FwCharWarningMsg,

        [EnumMember(Value = "FWCorpJoinMsg")]
        FwCorpJoinMsg,

        [EnumMember(Value = "FWCorpKickMsg")]
        FwCorpKickMsg,

        [EnumMember(Value = "FWCorpLeaveMsg")]
        FwCorpLeaveMsg,

        [EnumMember(Value = "FWCorpWarningMsg")]
        FwCorpWarningMsg,
        FacWarCorpJoinRequestMsg,
        FacWarCorpJoinWithdrawMsg,
        FacWarCorpLeaveRequestMsg,
        FacWarCorpLeaveWithdrawMsg,

        [EnumMember(Value = "FacWarLPDisqualifiedEvent")]
        FacWarLpDisqualifiedEvent,

        [EnumMember(Value = "FacWarLPDisqualifiedKill")]
        FacWarLpDisqualifiedKill,

        [EnumMember(Value = "FacWarLPPayoutEvent")]
        FacWarLpPayoutEvent,

        [EnumMember(Value = "FacWarLPPayoutKill")]
        FacWarLpPayoutKill,
        GameTimeAdded,
        GameTimeReceived,
        GameTimeSent,
        GiftReceived,

        [EnumMember(Value = "IHubDestroyedByBillFailure")]
        HubDestroyedByBillFailure,
        IncursionCompletedMsg,
        IndustryOperationFinished,
        IndustryTeamAuctionLost,
        IndustryTeamAuctionWon,
        InfrastructureHubBillAboutToExpire,
        InsuranceExpirationMsg,
        InsuranceFirstShipMsg,
        InsuranceInvalidatedMsg,
        InsuranceIssuedMsg,
        InsurancePayoutMsg,
        InvasionSystemLogin,
        JumpCloneDeletedMsg1,
        JumpCloneDeletedMsg2,
        KillReportFinalBlow,
        KillReportVictim,
        KillRightAvailable,
        KillRightAvailableOpen,
        KillRightEarned,
        KillRightUnavailable,
        KillRightUnavailableOpen,
        KillRightUsed,
        LocateCharMsg,
        MadeWarMutual,
        MercOfferedNegotiationMsg,
        MissionOfferExpirationMsg,
        MissionTimeoutMsg,
        MoonminingAutomaticFracture,
        MoonminingExtractionCancelled,
        MoonminingExtractionFinished,
        MoonminingExtractionStarted,
        MoonminingLaserFired,
        MutualWarExpired,
        MutualWarInviteAccepted,
        MutualWarInviteRejected,
        MutualWarInviteSent,

        [EnumMember(Value = "NPCStandingsGained")]
        NpcStandingsGained,

        [EnumMember(Value = "NPCStandingsLost")]
        NpcStandingsLost,
        OfferedSurrender,
        OfferedToAlly,
        OldLscMessages,
        OperationFinished,
        OrbitalAttacked,
        OrbitalReinforced,
        OwnershipTransferred,
        ReimbursementMsg,
        ResearchMissionAvailableMsg,
        RetractsWar,
        SeasonalChallengeCompleted,
        SovAllClaimAquiredMsg,
        SovAllClaimLostMsg,
        SovCommandNodeEventStarted,
        SovCorpBillLateMsg,
        SovCorpClaimFailMsg,
        SovDisruptorMsg,
        SovStationEnteredFreeport,
        SovStructureDestroyed,
        SovStructureReinforced,
        SovStructureSelfDestructCancel,
        SovStructureSelfDestructFinished,
        SovStructureSelfDestructRequested,

        [EnumMember(Value = "SovereigntyIHDamageMsg")]
        SovereigntyIhDamageMsg,

        [EnumMember(Value = "SovereigntySBUDamageMsg")]
        SovereigntySbuDamageMsg,

        [EnumMember(Value = "SovereigntyTCUDamageMsg")]
        SovereigntyTcuDamageMsg,
        StationAggressionMsg1,
        StationAggressionMsg2,
        StationConquerMsg,
        StationServiceDisabled,
        StationServiceEnabled,
        StationStateChangeMsg,
        StoryLineMissionAvailableMsg,
        StructureAnchoring,
        StructureCourierContractChanged,
        StructureDestroyed,
        StructureFuelAlert,
        StructureItemsDelivered,
        StructureItemsMovedToSafety,
        StructureLostArmor,
        StructureLostShields,
        StructureOnline,
        StructureServicesOffline,
        StructureUnanchoring,
        StructureUnderAttack,
        StructureWentHighPower,
        StructureWentLowPower,
        StructuresJobsCancelled,
        StructuresJobsPaused,
        StructuresReinforcementChanged,
        TowerAlertMsg,
        TowerResourceAlertMsg,
        TransactionReversalMsg,
        TutorialMsg,
        WarAdopted,
        WarAllyInherited,
        WarAllyOfferDeclinedMsg,
        WarSurrenderDeclinedMsg,
        WarConcordInvalidates,
        WarDeclared,
        WarHQRemovedFromSpace,
        WarInherited,
        WarInvalid,
        WarRetracted,
        WarRetractedByConcord,
        WarSurrenderOfferMsg
    }
}