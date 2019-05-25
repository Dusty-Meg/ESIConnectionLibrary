using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV6WalletCharacterJournalRefType
    {
        [EnumMember(Value = "acceleration_gate_fee")]
        AccelerationGateFee,

        [EnumMember(Value = "advertisement_listing_fee")]
        AdvertisementListingFee,

        [EnumMember(Value = "agent_donation")]
        AgentDonation,

        [EnumMember(Value = "agent_location_services")]
        AgentLocationServices,

        [EnumMember(Value = "agent_miscellaneous")]
        AgentMiscellaneous,

        [EnumMember(Value = "agent_mission_collateral_paid")]
        AgentMissionCollateralPaid,

        [EnumMember(Value = "agent_mission_collateral_refunded")]
        AgentMissionCollateralRefunded,

        [EnumMember(Value = "agent_mission_reward")]
        AgentMissionReward,

        [EnumMember(Value = "agent_mission_reward_corporation_tax")]
        AgentMissionRewardCorporationTax,

        [EnumMember(Value = "agent_mission_time_bonus_reward")]
        AgentMissionTimeBonusReward,

        [EnumMember(Value = "agent_mission_time_bonus_reward_corporation_tax")]
        AgentMissionTimeBonusRewardCorporationTax,

        [EnumMember(Value = "agent_security_services")]
        AgentSecurityServices,

        [EnumMember(Value = "agent_services_rendered")]
        AgentServicesRendered,

        [EnumMember(Value = "agents_preward")]
        AgentsPreward,

        [EnumMember(Value = "alliance_maintainance_fee")]
        AllianceMaintainanceFee,

        [EnumMember(Value = "alliance_registration_fee")]
        AllianceRegistrationFee,

        [EnumMember(Value = "asset_safety_recovery_tax")]
        AssetSafetyRecoveryTax,

        [EnumMember(Value = "bounty")]
        Bounty,

        [EnumMember(Value = "bounty_prize")]
        BountyPrize,

        [EnumMember(Value = "bounty_prize_corporation_tax")]
        BountyPrizeCorporationTax,

        [EnumMember(Value = "bounty_prizes")]
        BountyPrizes,

        [EnumMember(Value = "bounty_reimbursement")]
        BountyReimbursement,

        [EnumMember(Value = "bounty_surcharge")]
        BountySurcharge,

        [EnumMember(Value = "brokers_fee")]
        BrokersFee,

        [EnumMember(Value = "clone_activation")]
        CloneActivation,

        [EnumMember(Value = "clone_transfer")]
        CloneTransfer,

        [EnumMember(Value = "contraband_fine")]
        ContrabandFine,

        [EnumMember(Value = "contract_auction_bid")]
        ContractAuctionBid,

        [EnumMember(Value = "contract_auction_bid_corp")]
        ContractAuctionBidCorp,

        [EnumMember(Value = "contract_auction_bid_refund")]
        ContractAuctionBidRefund,

        [EnumMember(Value = "contract_auction_sold")]
        ContractAuctionSold,

        [EnumMember(Value = "contract_brokers_fee")]
        ContractBrokersFee,

        [EnumMember(Value = "contract_brokers_fee_corp")]
        ContractBrokersFeeCorp,

        [EnumMember(Value = "contract_collateral")]
        ContractCollateral,

        [EnumMember(Value = "contract_collateral_deposited_corp")]
        ContractCollateralDepositedCorp,

        [EnumMember(Value = "contract_collateral_payout")]
        ContractCollateralPayout,

        [EnumMember(Value = "contract_collateral_refund")]
        ContractCollateralRefund,

        [EnumMember(Value = "contract_deposit")]
        ContractDeposit,

        [EnumMember(Value = "contract_deposit_corp")]
        ContractDepositCorp,

        [EnumMember(Value = "contract_deposit_refund")]
        ContractDepositRefund,

        [EnumMember(Value = "contract_deposit_sales_tax")]
        ContractDepositSalesTax,

        [EnumMember(Value = "contract_price")]
        ContractPrice,

        [EnumMember(Value = "contract_price_payment_corp")]
        ContractPricePaymentCorp,

        [EnumMember(Value = "contract_reversal")]
        ContractReversal,

        [EnumMember(Value = "contract_reward")]
        ContractReward,

        [EnumMember(Value = "contract_reward_deposited")]
        ContractRewardDeposited,

        [EnumMember(Value = "contract_reward_deposited_corp")]
        ContractRewardDepositedCorp,

        [EnumMember(Value = "contract_reward_refund")]
        ContractRewardRefund,

        [EnumMember(Value = "contract_sales_tax")]
        ContractSalesTax,

        [EnumMember(Value = "copying")]
        Copying,

        [EnumMember(Value = "corporate_reward_payout")]
        CorporateRewardPayout,

        [EnumMember(Value = "corporate_reward_tax")]
        CorporateRewardTax,

        [EnumMember(Value = "corporation_account_withdrawal")]
        CorporationAccountWithdrawal,

        [EnumMember(Value = "corporation_bulk_payment")]
        CorporationBulkPayment,

        [EnumMember(Value = "corporation_dividend_payment")]
        CorporationDividendPayment,

        [EnumMember(Value = "corporation_liquidation")]
        CorporationLiquidation,

        [EnumMember(Value = "corporation_logo_change_cost")]
        CorporationLogoChangeCost,

        [EnumMember(Value = "corporation_payment")]
        CorporationPayment,

        [EnumMember(Value = "corporation_registration_fee")]
        CorporationRegistrationFee,

        [EnumMember(Value = "courier_mission_escrow")]
        CourierMissionEscrow,

        [EnumMember(Value = "cspa")]
        Cspa,

        [EnumMember(Value = "cspaofflinerefund")]
        Cspaofflinerefund,

        [EnumMember(Value = "datacore_fee")]
        DatacoreFee,

        [EnumMember(Value = "dna_modification_fee")]
        DnaModificationFee,

        [EnumMember(Value = "docking_fee")]
        DockingFee,

        [EnumMember(Value = "duel_wager_escrow")]
        DuelWagerEscrow,

        [EnumMember(Value = "duel_wager_payment")]
        DuelWagerPayment,

        [EnumMember(Value = "duel_wager_refund")]
        DuelWagerRefund,

        [EnumMember(Value = "factory_slot_rental_fee")]
        FactorySlotRentalFee,

        [EnumMember(Value = "gm_cash_transfer")]
        GmCashTransfer,

        [EnumMember(Value = "industry_job_tax")]
        IndustryJobTax,

        [EnumMember(Value = "infrastructure_hub_maintenance")]
        InfrastructureHubMaintenance,

        [EnumMember(Value = "inheritance")]
        Inheritance,

        [EnumMember(Value = "insurance")]
        Insurance,

        [EnumMember(Value = "item_trader_payment")]
        ItemTraderPayment,

        [EnumMember(Value = "jump_clone_activation_fee")]
        JumpCloneActivationFee,

        [EnumMember(Value = "jump_clone_installation_fee")]
        JumpCloneInstallationFee,

        [EnumMember(Value = "kill_right_fee")]
        KillRightFee,

        [EnumMember(Value = "lp_store")]
        LpStore,

        [EnumMember(Value = "manufacturing")]
        Manufacturing,

        [EnumMember(Value = "market_escrow")]
        MarketEscrow,

        [EnumMember(Value = "market_fine_paid")]
        MarketFinePaid,

        [EnumMember(Value = "market_transaction")]
        MarketTransaction,

        [EnumMember(Value = "medal_creation")]
        MedalCreation,

        [EnumMember(Value = "medal_issued")]
        MedalIssued,

        [EnumMember(Value = "mission_completion")]
        MissionCompletion,

        [EnumMember(Value = "mission_cost")]
        MissionCost,

        [EnumMember(Value = "mission_expiration")]
        MissionExpiration,

        [EnumMember(Value = "mission_reward")]
        MissionReward,

        [EnumMember(Value = "office_rental_fee")]
        OfficeRentalFee,

        [EnumMember(Value = "operation_bonus")]
        OperationBonus,

        [EnumMember(Value = "opportunity_reward")]
        OpportunityReward,

        [EnumMember(Value = "planetary_construction")]
        PlanetaryConstruction,

        [EnumMember(Value = "planetary_export_tax")]
        PlanetaryExportTax,

        [EnumMember(Value = "planetary_import_tax")]
        PlanetaryImportTax,

        [EnumMember(Value = "player_donation")]
        PlayerDonation,

        [EnumMember(Value = "player_trading")]
        PlayerTrading,

        [EnumMember(Value = "project_discovery_reward")]
        ProjectDiscoveryReward,

        [EnumMember(Value = "project_discovery_tax")]
        ProjectDiscoveryTax,

        [EnumMember(Value = "reaction")]
        Reaction,

        [EnumMember(Value = "release_of_impounded_property")]
        ReleaseOfImpoundedProperty,

        [EnumMember(Value = "repair_bill")]
        RepairBill,

        [EnumMember(Value = "reprocessing_tax")]
        ReprocessingTax,

        [EnumMember(Value = "researching_material_productivity")]
        ResearchingMaterialProductivity,

        [EnumMember(Value = "researching_technology")]
        ResearchingTechnology,

        [EnumMember(Value = "researching_time_productivity")]
        ResearchingTimeProductivity,

        [EnumMember(Value = "resource_wars_reward")]
        ResourceWarsReward,

        [EnumMember(Value = "reverse_engineering")]
        ReverseEngineering,

        [EnumMember(Value = "security_processing_fee")]
        SecurityProcessingFee,

        [EnumMember(Value = "shares")]
        Shares,

        [EnumMember(Value = "skill_purchase")]
        SkillPurchase,

        [EnumMember(Value = "sovereignity_bill")]
        SovereignityBill,

        [EnumMember(Value = "store_purchase")]
        StorePurchase,

        [EnumMember(Value = "store_purchase_refund")]
        StorePurchaseRefund,

        [EnumMember(Value = "structure_gate_jump")]
        StructureGateJump,

        [EnumMember(Value = "transaction_tax")]
        TransactionTax,

        [EnumMember(Value = "upkeep_adjustment_fee")]
        UpkeepAdjustmentFee,

        [EnumMember(Value = "war_ally_contract")]
        WarAllyContract,

        [EnumMember(Value = "war_fee")]
        WarFee,

        [EnumMember(Value = "war_fee_surrender")]
        WarFeeSurrender
    }
}