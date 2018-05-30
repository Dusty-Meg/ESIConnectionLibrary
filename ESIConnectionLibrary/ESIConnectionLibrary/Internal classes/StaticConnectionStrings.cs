using System.Collections.Generic;
using System.Linq;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class StaticConnectionStrings
    {
        private static string UrlBuilder(string rawUrl, params string[] urls)
        {
            int count = urls.Length;
            string urlBuilder = rawUrl;

            for (int i = 0; i < count; i += 2)
            {
                urlBuilder = urlBuilder.Replace(urls[i], urls[i + 1]);
            }

            return EsiBaseUrl + urlBuilder;
        }

        private static string UrlBuilder(string rawUrl, string prefix, IList<string> variables)
        {
            string urlBuilder = rawUrl + "?" + prefix + "=";

            for (int i = 0; i < variables.Count; i++)
            {
                if (i != 0)
                {
                    urlBuilder = urlBuilder + ",";
                }

                urlBuilder = urlBuilder + variables[i];
            }

            return urlBuilder;
        }

        private static string EsiBaseUrl => "https://esi.evetech.net";

        #region Authentication

        private static string AuthenticationVerifyRaw => "/verify/";

        public static string AuthenticationVerify()
        {
            return UrlBuilder(AuthenticationVerifyRaw);
        }

        #endregion

        #region Alliances

        private static string AllianceV1GetActiveAllianceRaw => "/v1/alliances/";
        private static string AllianceV3GetAlliancePublicInfoRaw => "/v3/alliances/{alliance_id}/";
        private static string AllianceV1GetAllianceCorporationsRaw => "/v1/alliances/{alliance_id}/corporations/";
        private static string AllianceV1GetAllianceIconsRaw => "/v1/alliances/{alliance_id}/icons/";
        private static string AllianceV2IdsToNamesRaw => "/v2/alliances/names/";

        public static string AlianceV1GetActiveAlliance()
        {
            return UrlBuilder(AllianceV1GetActiveAllianceRaw);
        }

        public static string AllianceV3GetAlliancePublicInfo(int allianceId)
        {
            return UrlBuilder(AllianceV3GetAlliancePublicInfoRaw, "{alliance_id}", allianceId.ToString());
        }

        public static string AllianceV1GetAllianceCorporations(int allianceId)
        {
            return UrlBuilder(AllianceV1GetAllianceCorporationsRaw, "{alliance_id}", allianceId.ToString());
        }

        public static string AllianceV1GetAllianceIcons(int allianceId)
        {
            return UrlBuilder(AllianceV1GetAllianceIconsRaw, "{alliance_id}", allianceId.ToString());
        }

        public static string AllianceV2IdsToNames(IList<int> allianceIds)
        {
            return UrlBuilder(AllianceV2IdsToNamesRaw, "alliance_ids", allianceIds.Select(x => x.ToString()).ToList());
        }

        #endregion

        #region Assets

        private static string AssetsV3GetCharactersAssetsRaw => "/v3/characters/{character_id}/assets/";
        private static string AssetsV2GetCharactersAssetsLocationsRaw => "/v2/characters/{character_id}/assets/locations/";
        private static string AssetsV1GetCharactersAssetsNamesRaw => "/v1/characters/{character_id}/assets/names/";
        private static string AssetsV3GetCorporationsAssetsRaw => "/v3/corporations/{corporation_id}/assets/";
        private static string AssetsV2GetCorporationsAssetsLocationsRaw => "/v2/corporations/{corporation_id}/assets/locations/";
        private static string AssetsV1GetCorporationsAssetsNamesRaw => "/v1/corporations/{corporation_id}/assets/names/";

        public static string AssetsV3GetCharactersAssets(int characterId, int page)
        {
            return UrlBuilder(AssetsV3GetCharactersAssetsRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        public static string AssetsV2GetCharactersAssetsLocations(int characterId)
        {
            return UrlBuilder(AssetsV2GetCharactersAssetsLocationsRaw, "{character_id}", characterId.ToString());
        }

        public static string AssetsV1GetCharactersAssetsNames(int characterId)
        {
            return UrlBuilder(AssetsV1GetCharactersAssetsNamesRaw, "{character_id}", characterId.ToString());
        }

        public static string AssetsV3GetCorporationsAssets(int corporationId, int page)
        {
            return UrlBuilder(AssetsV3GetCorporationsAssetsRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string AssetsV2GetCorporationsAssetsLocations(int corporationId)
        {
            return UrlBuilder(AssetsV2GetCorporationsAssetsLocationsRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string AssetsV1GetCorporationsAssetsNames(int corporationId)
        {
            return UrlBuilder(AssetsV1GetCorporationsAssetsNamesRaw, "{corporation_id}", corporationId.ToString());
        }

        #endregion

        #region Character

        private static string EsiV4CharactersPublicInfoRaw => "/v4/characters/{character_id}/";
        private static string EsiV1CharactersResearchAgentsRaw => "/v1/characters/{character_id}/agents_research/";
        private static string EsiV2CharactersBlueprintsRaw => "/v2/characters/{character_id}/blueprints/";
        private static string EsiV1CharactersChatChannelsRaw => "/v1/characters/{character_id}/chat_channels/";
        private static string EsiV1CharactersCorporationHistoryRaw => "/v1/characters/{character_id}/corporationhistory/";
        private static string EsiV4CharactersCspaRaw => "/v4/characters/{character_id}/cspa/";
        private static string EsiV1CharactersFatigueRaw => "/v1/characters/{character_id}/fatigue/";
        private static string EsiV1CharactersMedalsRaw => "/v1/characters/{character_id}/medals/";
        private static string EsiV2CharactersNotificationsRaw => "/v2/characters/{character_id}/notifications/";
        private static string EsiV1CharactersNotificationsContactsRaw => "/v1/characters/{character_id}/notifications/contacts/";
        private static string EsiV2CharactersPortraitRaw => "/v2/characters/{character_id}/portrait/";
        private static string EsiV2CharacterRolesRaw => "/v2/characters/{character_id}/roles/";
        private static string EsiV2CharactersStandingsRaw => "/v1/characters/{character_id}/standings/";
        private static string EsiV2CharactersStatsRaw => "/v2/characters/{character_id}/stats/";
        private static string EsiV1CharacterTitlesRaw => "/v1/characters/{character_id}/titles/";
        private static string EsiV1CharacterAffiliationsRaw => "/v1/characters/affiliation/";
        private static string EsiV1CharactersNamesRaw => "/v1/characters/names/";

        public static string EsiV4CharactersPublicInfo(int characterId)
        {
            return UrlBuilder(EsiV4CharactersPublicInfoRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharactersResearchAgents(int characterId)
        {
            return UrlBuilder(EsiV1CharactersResearchAgentsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV2CharactersBlueprints(int characterId)
        {
            return UrlBuilder(EsiV2CharactersBlueprintsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharactersChatChannels(int characterId)
        {
            return UrlBuilder(EsiV1CharactersChatChannelsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharactersCorporationHistory(int characterId)
        {
            return UrlBuilder(EsiV1CharactersCorporationHistoryRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV4CharactersCspa(int characterId)
        {
            return UrlBuilder(EsiV4CharactersCspaRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharactersFatigue(int characterId)
        {
            return UrlBuilder(EsiV1CharactersFatigueRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharactersMedals(int characterId)
        {
            return UrlBuilder(EsiV1CharactersMedalsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV2CharactersNotifications(int characterId)
        {
            return UrlBuilder(EsiV2CharactersNotificationsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharactersNotificationsContacts(int characterId)
        {
            return UrlBuilder(EsiV1CharactersNotificationsContactsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV2CharactersPortrait(int characterId)
        {
            return UrlBuilder(EsiV2CharactersPortraitRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV2CharacterRoles(int characterId)
        {
            return UrlBuilder(EsiV2CharacterRolesRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV2CharactersStandings(int characterId)
        {
            return UrlBuilder(EsiV2CharactersStandingsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV2CharactersStats(int characterId)
        {
            return UrlBuilder(EsiV2CharactersStatsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharacterTitles(int characterId)
        {
            return UrlBuilder(EsiV1CharacterTitlesRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharacterAffiliations()
        {
            return UrlBuilder(EsiV1CharacterAffiliationsRaw);
        }

        public static string EsiV1CharactersNames(IList<int> characterIds)
        {
            return UrlBuilder(EsiV1CharactersNamesRaw, "character_ids", characterIds.Select(x => x.ToString()).ToList());
        }

        #endregion

        #region Clones

        private static string ClonesV3GetCharactersClonesRaw => "/v3/characters/{character_id}/clones/";
        private static string ClonesV3GetCharactersActiveImplantsRaw => "/v1/characters/{character_id}/implants/";

        public static string ClonesV3GetCharactersClones(int characterId)
        {
            return UrlBuilder(ClonesV3GetCharactersClonesRaw, "{character_id}", characterId.ToString());
        }

        public static string ClonesV3GetCharactersActiveImplants(int characterId)
        {
            return UrlBuilder(ClonesV3GetCharactersActiveImplantsRaw, "{character_id}", characterId.ToString());
        }

        #endregion 

        #region Contacts

        private static string ContactsV1GetCharactersContactsRaw => "/v1/characters/{character_id}/contacts/";

        public static string ContactsV1GetCharactersContacts(int characterId, int page)
        {
            return UrlBuilder(ContactsV1GetCharactersContactsRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        #endregion

        #region Contracts

        private static string ContractsV1GetCharactersContractsRaw => "/v1/characters/{character_id}/contracts/";

        public static string ContractsV1GetCharactersContracts(int characterId, int page)
        {
            return UrlBuilder(ContractsV1GetCharactersContractsRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        #endregion

        #region Corporations

        private static string CorporationV1CorporationMemberTitlesRaw => "/v1/corporations/{corporation_id}/members/titles/";
        private static string CorporationV1CorporationRolesRaw => "/v1/corporations/{corporation_id}/roles/";
        private static string CorporationV1CorporationTitlesRaw => "/v1/corporations/{corporation_id}/titles/";

        public static string CorporationV1CorporationMemberTitles(long corporationId)
        {
            return UrlBuilder(CorporationV1CorporationMemberTitlesRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string CorporationV1CorporationRoles(long corporationId)
        {
            return UrlBuilder(CorporationV1CorporationRolesRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string CorporationV1CorporationTitles(long corporationId)
        {
            return UrlBuilder(CorporationV1CorporationTitlesRaw, "{corporation_id}", corporationId.ToString());
        }

        #endregion

        #region Fleets

        private static string FleetsGetFleetRaw => "/v1/fleets/{fleet_id}/";

        public static string FleetsGetFleet(long fleetId)
        {
            return UrlBuilder(FleetsGetFleetRaw, "{fleet_id}", fleetId.ToString());
        }

        #endregion

        #region Industry

        private static string IndustryCharacterJobsRaw => "/v1/characters/{character_id}/industry/jobs/";

        public static string IndustryCharacterJobs(int characterId, bool includeCompletedJobs)
        {
            return $"{UrlBuilder(IndustryCharacterJobsRaw, "{character_id}", characterId.ToString())}?include_completed={includeCompletedJobs}";
        }

        #endregion

        #region Insurance

        private static string InsuranceGetPricesRaw => "/v1/insurance/prices/";

        public static string InsuranceGetPrices()
        {
            return UrlBuilder(InsuranceGetPricesRaw);
        }

        #endregion

        #region Killmails

        private static string KillmailsGetSingleKillmailRaw => "/v1/killmails/{killmail_id}/{killmail_hash}/";

        public static string KillmailsGetSingleKillmail(int killmailId, string killmailHash)
        {
            return UrlBuilder(KillmailsGetSingleKillmailRaw, "{killmail_id}", killmailId.ToString(), "{killmail_hash}", killmailHash);
        }

        #endregion

        #region location

        private static string LocationV1LocationCharacterLocationRaw => "/v1/characters/{character_id}/location/";
        private static string LocationV2LocationCharacterOnlineRaw => "/v2/characters/{character_id}/online/";
        private static string LocationV1LocationCharacterShipRaw => "/v1/characters/{character_id}/ship/";

        public static string LocationV1LocationCharacterLocation(int characterId)
        {
            return UrlBuilder(LocationV1LocationCharacterLocationRaw, "{character_id}", characterId.ToString());
        }

        public static string LocationV2LocationCharacterOnline(int characterId)
        {
            return UrlBuilder(LocationV2LocationCharacterOnlineRaw, "{character_id}", characterId.ToString());
        }

        public static string LocationV1LocationCharacterShip(int characterId)
        {
            return UrlBuilder(LocationV1LocationCharacterShipRaw, "{character_id}", characterId.ToString());
        }

        #endregion

        #region Mail

        private static string MailV1MailGetCharactersMailRaw => "/v1/characters/{character_id}/mail/";
        private static string MailV1MailGetMailRaw => "/v1/characters/{character_id}/mail/{mail_id}/";

        public static string MailV1MailGetCharactersMail(int characterId, int lastMailId)
        {
            if (lastMailId == 0)
            {
                return UrlBuilder(MailV1MailGetCharactersMailRaw, "{character_id}", characterId.ToString());
            }
            return UrlBuilder(MailV1MailGetCharactersMailRaw, "{character_id}", characterId.ToString()) + $"?last_mail_id={lastMailId}";
        }

        public static string MailV1MailGetMail(int characterId, int mailId)
        {
            return UrlBuilder(MailV1MailGetMailRaw, "{character_id}", characterId.ToString(), "{mail_id}", mailId.ToString());
        }

        #endregion 

        #region Market

        private static string MarketV2MarketCharactersOrdersRaw => "/v2/characters/{character_id}/orders/";
        private static string MarketV1MarketCharactersHistoricOrdersRaw => "/v1/characters/{character_id}/orders/history/";
        private static string MarketV1GetMarketGroupInformationRaw => "/v1/markets/groups/{market_group_id}/";

        public static string MarketV2MarketCharactersOrders(int characterId)
        {
            return UrlBuilder(MarketV2MarketCharactersOrdersRaw, "{character_id}", characterId.ToString());
        }

        public static string MarketV1MarketCharactersHistoricOrders(int characterId, int page)
        {
            return UrlBuilder(MarketV1MarketCharactersHistoricOrdersRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        public static string MarketV1GetMarketGroupInformation(int marketGroupId)
        {
            return UrlBuilder(MarketV1GetMarketGroupInformationRaw, "{market_group_id}", marketGroupId.ToString());
        }

        #endregion

        #region PlanetaryInteraction

        private static string PlanetaryInteractionV1CharactersPlanetsRaw => "/v1/characters/{character_id}/planets/";
        private static string PlanetaryInteractionV3CharactersPlanetRaw => "/v3/characters/{character_id}/planets/{planet_id}/";
        private static string PlanetaryInteractionV1CorporationsCustomsOfficesRaw => "/v1/corporations/{corporation_id}/customs_offices/";
        private static string PlanetaryInteractionV1SchematicsRaw => "/v1/universe/schematics/{schematic_id}/";

        public static string PlanetaryInteractionV1CharactersPlanets(int characterId)
        {
            return UrlBuilder(PlanetaryInteractionV1CharactersPlanetsRaw, "{character_id}", characterId.ToString());
        }

        public static string PlanetaryInteractionV3CharactersPlanet(int characterId, int planetId)
        {
            return UrlBuilder(PlanetaryInteractionV3CharactersPlanetRaw, "{character_id}", characterId.ToString(), "{planet_id}", planetId.ToString());
        }

        public static string PlanetaryInteractionV1CorporationsCustomsOffices(int corporationId, int page)
        {
            return UrlBuilder(PlanetaryInteractionV1CorporationsCustomsOfficesRaw, "{corporation_id}", corporationId + $"?page={page}");
        }

        public static string PlanetaryInteractionV1Schematics(int schematicId)
        {
            return UrlBuilder(PlanetaryInteractionV1SchematicsRaw, "{schematic_id}", schematicId.ToString());
        }

        #endregion

        #region Skills

        private static string SkillsSkillsRaw => "/v4/characters/{character_id}/skills/";
        private static string SkillsAttributesRaw => "/v1/characters/{character_id}/attributes/";
        private static string SkillsSkillQueueRaw => "/v2/characters/{character_id}/skillqueue/";

        public static string SkillsSkills(int characterId)
        {
            return UrlBuilder(SkillsSkillsRaw, "{character_id}", characterId.ToString());
        }

        public static string SkillsAttributes(int characterId)
        {
            return UrlBuilder(SkillsAttributesRaw, "{character_id}", characterId.ToString());
        }

        public static string SkillsSkillQueue(int characterId)
        {
            return UrlBuilder(SkillsSkillQueueRaw, "{character_id}", characterId.ToString());
        }

        #endregion

        #region Universe

        private static string UniverseNamesRaw => "/v2/universe/names/";
        private static string UniverseGetTypeRaw => "/v3/universe/types/{type_id}/";

        public static string UniverseNames()
        {
            return UrlBuilder(UniverseNamesRaw);
        }

        public static string UniverseGetType(long typeId)
        {
            return UrlBuilder(UniverseGetTypeRaw, "{type_id}", typeId.ToString());
        }

        #endregion

        #region Ui

        private static string UiV2AddWaypointRaw => "/v2/ui/autopilot/waypoint/";
        private static string UiV1OpenContractWindowRaw => "/v1/ui/openwindow/contract/";
        private static string UiV1OpenInformationWindowRaw => "/v1/ui/openwindow/information/";
        private static string UiV1OpenMarketDataWindowRaw => "/v1/ui/openwindow/marketdetails/";
        private static string UiV1OpenNewMailWindowRaw => "/v1/ui/openwindow/newmail/";

        public static string UiV2AddWaypoint(bool addToBeginning, bool clearOtherWaypoints, int destinationId)
        {
            return UrlBuilder(UiV2AddWaypointRaw) + $"?add_to_beginning={addToBeginning}&clear_other_waypoints={clearOtherWaypoints}&destination_id={destinationId}";
        }

        public static string UiV1OpenContractWindow(int contractId)
        {
            return UrlBuilder(UiV1OpenContractWindowRaw) + $"?contract_id={contractId}";
        }

        public static string UiV1OpenInformationWindow(int targetId)
        {
            return UrlBuilder(UiV1OpenInformationWindowRaw) + $"?target_id={targetId}";
        }

        public static string UiV1OpenMarketDataWindow(int typeId)
        {
            return UrlBuilder(UiV1OpenMarketDataWindowRaw) + $"?type_id={typeId}";
        }

        public static string UiV1OpenNewMailWindow()
        {
            return UrlBuilder(UiV1OpenNewMailWindowRaw);
        }

        #endregion 

        #region Wallet

        private static string WalletV1CharactersWalletRaw => "/v1/characters/{character_id}/wallet/";
        private static string WalletV4CharactersWalletJournalRaw => "/v4/characters/{character_id}/wallet/journal/";
        private static string WalletV4CharactersWalletTransactionRaw => "/v1/characters/{character_id}/wallet/transactions/";
        private static string WalletV1CorporationWalletsRaw => "/v1/corporations/{corporation_id}/wallets/";
        private static string WalletV3CorporationDivisionsJournalRaw => "/v3/corporations/{corporation_id}/wallets/{division}/journal/";
        private static string WalletV1CorporationDivisionsTransactionsRaw => "/v1/corporations/{corporation_id}/wallets/{division}/transactions/";

        public static string WalletV1CharactersWallet(int characterId)
        {
            return UrlBuilder(WalletV1CharactersWalletRaw, "{character_id}", characterId.ToString());
        }

        public static string WalletV4CharactersWalletJournal(int characterId, int page)
        {
            return UrlBuilder(WalletV4CharactersWalletJournalRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        public static string WalletV4CharactersWalletTransaction(int characterId, int lastTransactionId)
        {
            if (lastTransactionId == 0)
            {
                return UrlBuilder(WalletV4CharactersWalletTransactionRaw, "{character_id}", characterId.ToString());
            }
            return UrlBuilder(WalletV4CharactersWalletTransactionRaw, "{character_id}", characterId.ToString()) + $"?from_id={lastTransactionId}";
        }

        public static string WalletV1CorporationWallets(int corporationId)
        {
            return UrlBuilder(WalletV1CorporationWalletsRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string WalletV3CorporationDivisionsJournal(int corporationId, int division, int page)
        {
            return UrlBuilder(WalletV3CorporationDivisionsJournalRaw, "{corporation_id}", corporationId.ToString(), "{division}", division.ToString()) + $"?page={page}";
        }

        public static string WalletV1CorporationDivisionsTransactions(int corporationId, int division, int lastTransactionId)
        {
            if (lastTransactionId == 0)
            {
                return UrlBuilder(WalletV1CorporationDivisionsTransactionsRaw, "{corporation_id}", corporationId.ToString(), "{division}", division.ToString());
            }
            return UrlBuilder(WalletV1CorporationDivisionsTransactionsRaw, "{corporation_id}", corporationId.ToString(), "{division}", division.ToString()) + $"?from_id={lastTransactionId}";
        }

        #endregion 

        #region Wars

        private static string WarsV1WarsRaw => "/v1/wars/";
        private static string WarsV1WarRaw => "/v1/wars/{war_id}/";
        private static string WarsV1WarKillmailsRaw => "/v1/wars/{war_id}/killmails/";

        public static string WarsV1Wars(int maxWarId)
        {
            if (maxWarId == 0)
            {
                return UrlBuilder(WarsV1WarsRaw);
            }

            return UrlBuilder(WarsV1WarsRaw) + $"?max_war_id={maxWarId}";
        }

        public static string WarsV1War(int warId)
        {
            return UrlBuilder(WarsV1WarRaw, "{war_id}", warId.ToString());
        }

        public static string WarsV1WarKillmails(int warId)
        {
            return UrlBuilder(WarsV1WarKillmailsRaw, "{war_id}", warId.ToString());
        }

        #endregion 
    }
}