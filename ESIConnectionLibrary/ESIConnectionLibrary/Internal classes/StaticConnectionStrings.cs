using System;
using System.Linq;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

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

        public static string CheckTestingUrl(string url, bool testing)
        {
            return testing ? url.Replace(EsiBaseUrl, TestEsiBaseUrl) : url;
        }

        private static string EsiBaseUrl => "https://esi.evetech.net";
        private static string TestEsiBaseUrl => "http://127.0.0.1:8080";

        #region Authentication

        private static string AuthenticationVerifyRaw => "/verify/";

        public static string AuthenticationVerify()
        {
            return UrlBuilder(AuthenticationVerifyRaw);
        }

        #endregion

        #region Alliances

        private static string AllianceV1AlliancesRaw => "/v1/alliances/";
        private static string AllianceV3PublicInfoRaw => "/v3/alliances/{alliance_id}/";
        private static string AllianceV1CorporationsRaw => "/v1/alliances/{alliance_id}/corporations/";
        private static string AllianceV1IconsRaw => "/v1/alliances/{alliance_id}/icons/";

        public static string AllianceV1Alliance()
        {
            return UrlBuilder(AllianceV1AlliancesRaw);
        }

        public static string AllianceV3PublicInfo(int allianceId)
        {
            return UrlBuilder(AllianceV3PublicInfoRaw, "{alliance_id}", allianceId.ToString());
        }

        public static string AllianceV1Corporations(int allianceId)
        {
            return UrlBuilder(AllianceV1CorporationsRaw, "{alliance_id}", allianceId.ToString());
        }

        public static string AllianceV1Icons(int allianceId)
        {
            return UrlBuilder(AllianceV1IconsRaw, "{alliance_id}", allianceId.ToString());
        }

        #endregion

        #region Assets

        private static string AssetsV5CharactersRaw => "/v5/characters/{character_id}/assets/";
        private static string AssetsV2CharacterLocationsRaw => "/v2/characters/{character_id}/assets/locations/";
        private static string AssetsV1CharacterNamesRaw => "/v1/characters/{character_id}/assets/names/";
        private static string AssetsV5CorporationsRaw => "/v5/corporations/{corporation_id}/assets/";
        private static string AssetsV2CorporationLocationsRaw => "/v2/corporations/{corporation_id}/assets/locations/";
        private static string AssetsV1CorporationNamesRaw => "/v1/corporations/{corporation_id}/assets/names/";

        public static string AssetsV5Characters(int characterId, int page)
        {
            return UrlBuilder(AssetsV5CharactersRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        public static string AssetsV2CharacterLocations(int characterId)
        {
            return UrlBuilder(AssetsV2CharacterLocationsRaw, "{character_id}", characterId.ToString());
        }

        public static string AssetsV1CharacterNames(int characterId)
        {
            return UrlBuilder(AssetsV1CharacterNamesRaw, "{character_id}", characterId.ToString());
        }

        public static string AssetsV5Corporations(int corporationId, int page)
        {
            return UrlBuilder(AssetsV5CorporationsRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string AssetsV2CorporationLocations(int corporationId)
        {
            return UrlBuilder(AssetsV2CorporationLocationsRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string AssetsV1CorporationNames(int corporationId)
        {
            return UrlBuilder(AssetsV1CorporationNamesRaw, "{corporation_id}", corporationId.ToString());
        }

        #endregion

        #region Bookmarks

        private static string BookmarksV2CharactersRaw => "/v2/characters/{character_id}/bookmarks/";
        private static string BookmarksV2CharactersFoldersRaw => "/v2/characters/{character_id}/bookmarks/folders/";
        private static string BookmarksV1CorporationsRaw => "/v1/corporations/{corporation_id}/bookmarks/";
        private static string BookmarksV1CorporationsFoldersRaw => "/v1/corporations/{corporation_id}/bookmarks/folders/";

        public static string BookmarksV2Characters(int characterId, int page)
        {
            return UrlBuilder(BookmarksV2CharactersRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        public static string BookmarksV2CharactersFolders(int characterId, int page)
        {
            return UrlBuilder(BookmarksV2CharactersFoldersRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        public static string BookmarksV1Corporations(int corporationId, int page)
        {
            return UrlBuilder(BookmarksV1CorporationsRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string BookmarksV1CorporationsFolders(int corporationId, int page)
        {
            return UrlBuilder(BookmarksV1CorporationsFoldersRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        #endregion

        #region Calendar

        private static string CalendarV1SummariesRaw => "/v1/characters/{character_id}/calendar/";
        private static string CalendarV3EventRaw => "/v3/characters/{character_id}/calendar/{event_id}/";
        private static string CalendarV3EventResponseRaw => "/v3/characters/{character_id}/calendar/{event_id}/";
        private static string CalendarV1EventAttendeesRaw => "/v1/characters/{character_id}/calendar/{event_id}/attendees/";

        public static string CalendarV1Summaries(int characterId, int fromEvent)
        {
            if (fromEvent == 0)
            {
                return UrlBuilder(CalendarV1SummariesRaw, "{character_id}", characterId.ToString());
            }

            return UrlBuilder(CalendarV1SummariesRaw, "{character_id}", characterId.ToString()) + $"?from_event={fromEvent}";
        }

        public static string CalendarV3Event(int characterId, int eventId)
        {
            return UrlBuilder(CalendarV3EventRaw, "{character_id}", characterId.ToString(), "{event_id}", eventId.ToString());
        }

        public static string CalendarV3EventResponse(int characterId, int eventId)
        {
            return UrlBuilder(CalendarV3EventResponseRaw, "{character_id}", characterId.ToString(), "{event_id}", eventId.ToString());
        }

        public static string CalendarV1EventAttendees(int characterId, int eventId)
        {
            return UrlBuilder(CalendarV1EventAttendeesRaw, "{character_id}", characterId.ToString(), "{event_id}", eventId.ToString());
        }

        #endregion

        #region Character

        private static string EsiV4CharactersPublicInfoRaw => "/v4/characters/{character_id}/";
        private static string EsiV1CharactersResearchAgentsRaw => "/v1/characters/{character_id}/agents_research/";
        private static string EsiV2CharactersBlueprintsRaw => "/v2/characters/{character_id}/blueprints/";
        private static string EsiV1CharactersCorporationHistoryRaw => "/v1/characters/{character_id}/corporationhistory/";
        private static string EsiV4CharactersCspaRaw => "/v4/characters/{character_id}/cspa/";
        private static string EsiV1CharactersFatigueRaw => "/v1/characters/{character_id}/fatigue/";
        private static string EsiV1CharactersMedalsRaw => "/v1/characters/{character_id}/medals/";
        private static string EsiV5CharactersNotificationsRaw => "/v5/characters/{character_id}/notifications/";
        private static string EsiV1CharactersNotificationsContactsRaw => "/v1/characters/{character_id}/notifications/contacts/";
        private static string EsiV2CharactersPortraitRaw => "/v2/characters/{character_id}/portrait/";
        private static string EsiV2CharacterRolesRaw => "/v2/characters/{character_id}/roles/";
        private static string EsiV2CharactersStandingsRaw => "/v1/characters/{character_id}/standings/";
        private static string EsiV1CharacterTitlesRaw => "/v1/characters/{character_id}/titles/";
        private static string EsiV1CharacterAffiliationsRaw => "/v1/characters/affiliation/";

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

        public static string EsiV5CharactersNotifications(int characterId)
        {
            return UrlBuilder(EsiV5CharactersNotificationsRaw, "{character_id}", characterId.ToString());
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

        public static string EsiV1CharacterTitles(int characterId)
        {
            return UrlBuilder(EsiV1CharacterTitlesRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharacterAffiliations()
        {
            return UrlBuilder(EsiV1CharacterAffiliationsRaw);
        }

        #endregion

        #region Clones

        private static string ClonesV3ClonesRaw => "/v3/characters/{character_id}/clones/";
        private static string ClonesV3ActiveImplantsRaw => "/v1/characters/{character_id}/implants/";

        public static string ClonesV3Clones(int characterId)
        {
            return UrlBuilder(ClonesV3ClonesRaw, "{character_id}", characterId.ToString());
        }

        public static string ClonesV3ActiveImplants(int characterId)
        {
            return UrlBuilder(ClonesV3ActiveImplantsRaw, "{character_id}", characterId.ToString());
        }

        #endregion 

        #region Contacts

        private static string ContactsV2AllianceRaw => "/v2/alliances/{alliance_id}/contacts/";
        private static string ContactsV1AllianceLabelsRaw => "/v1/alliances/{alliance_id}/contacts/labels/";
        private static string ContactsV2CharacterDeleteRaw => "/v2/characters/{character_id}/contacts/";
        private static string ContactsV2CharacterRaw => "/v2/characters/{character_id}/contacts/";
        private static string ContactsV2CharacterAddRaw => "/v2/characters/{character_id}/contacts/";
        private static string ContactsV2CharacterEditRaw => "/v2/characters/{character_id}/contacts/";
        private static string ContactsV1CharacterLabelsRaw => "/v1/characters/{character_id}/contacts/labels/";
        private static string ContactsV2CorporationRaw => "/v2/corporations/{corporation_id}/contacts/";
        private static string ContactsV1CorporationLabelsRaw => "/v1/corporations/{corporation_id}/contacts/labels/";

        public static string ContactsV2Alliance(int allianceId, int page)
        {
            return UrlBuilder(ContactsV2AllianceRaw, "{alliance_id}", allianceId.ToString()) + $"?page={page}";
        }

        public static string ContactsV1AllianceLabels(int allianceId)
        {
            return UrlBuilder(ContactsV1AllianceLabelsRaw, "{alliance_id}", allianceId.ToString());
        }

        public static string ContactsV2CharacterDelete(int characterId)
        {
            return UrlBuilder(ContactsV2CharacterDeleteRaw, "{character_id}", characterId.ToString());
        }

        public static string ContactsV2Character(int characterId, int page)
        {
            return UrlBuilder(ContactsV2CharacterRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        public static string ContactsV2CharacterAdd(int characterId, V2ContactCharacterAdd model)
        {
            string url = UrlBuilder(ContactsV2CharacterAddRaw, "{character_id}", characterId.ToString()) + $"?standing={model.Standing}";

            if (model.LabelIds != null && model.LabelIds.Any())
            {
                url = url + $"&label_ids={JsonConvert.SerializeObject(model.LabelIds)}";
            }

            if (model.Watched.HasValue)
            {
                url = url + $"&watched={model.Watched}";
            }

            return url;
        }

        public static string ContactsV2CharacterEdit(int characterId, V2ContactCharacterEdit model)
        {
            string url = UrlBuilder(ContactsV2CharacterEditRaw, "{character_id}", characterId.ToString()) + $"?standing={model.Standing}";

            if (model.LabelIds != null && model.LabelIds.Any())
            {
                url = url + $"&label_ids={JsonConvert.SerializeObject(model.LabelIds)}";
            }

            if (model.Watched.HasValue)
            {
                url = url + $"&watched={model.Watched}";
            }

            return url;
        }

        public static string ContactsV1CharacterLabels(int characterId)
        {
            return UrlBuilder(ContactsV1CharacterLabelsRaw, "{character_id}", characterId.ToString());
        }

        public static string ContactsV2Corporation(int corporationId, int page)
        {
            return UrlBuilder(ContactsV2CorporationRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string ContactsV1CorporationLabels(int corporationId)
        {
            return UrlBuilder(ContactsV1CorporationLabelsRaw, "{corporation_id}", corporationId.ToString());
        }

        #endregion

        #region Contracts

        private static string ContractsV1CharacterRaw => "/v1/characters/{character_id}/contracts/";
        private static string ContractsV1CharacterBidsRaw => "/v1/characters/{character_id}/contracts/{contract_id}/bids/";
        private static string ContractsV1CharacterItemsRaw => "/v1/characters/{character_id}/contracts/{contract_id}/items/";
        private static string ContractsV1CorporationRaw => "/v1/corporations/{corporation_id}/contracts/";
        private static string ContractsV1CorporationBidsRaw => "/v1/corporations/{corporation_id}/contracts/{contract_id}/bids/";
        private static string ContractsV1CorporationItemsRaw => "/v1/corporations/{corporation_id}/contracts/{contract_id}/items/";
        private static string ContractsV1PublicRaw => "/v1/contracts/public/{region_id}/";
        private static string ContractsV1PublicBidsRaw => "/v1/contracts/public/bids/{contract_id}/";
        private static string ContractsV1PublicItemsRaw => "/v1/contracts/public/items/{contract_id}/";

        public static string ContractsV1Character(int characterId, int page)
        {
            return UrlBuilder(ContractsV1CharacterRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        public static string ContractsV1CharacterBids(int characterId, int contractId)
        {
            return UrlBuilder(ContractsV1CharacterBidsRaw, "{character_id}", characterId.ToString(), "{contract_id}", contractId.ToString());
        }

        public static string ContractsV1CharacterItems(int characterId, int contractId)
        {
            return UrlBuilder(ContractsV1CharacterItemsRaw, "{character_id}", characterId.ToString(), "{contract_id}", contractId.ToString());
        }

        public static string ContractsV1Corporation(int corporationId, int page)
        {
            return UrlBuilder(ContractsV1CorporationRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string ContractsV1CorporationBids(int corporationId, int contractId)
        {
            return UrlBuilder(ContractsV1CorporationBidsRaw, "{corporation_id}", corporationId.ToString(), "{contract_id}", contractId.ToString());
        }

        public static string ContractsV1CorporationItems(int corporationId, int contractId)
        {
            return UrlBuilder(ContractsV1CorporationItemsRaw, "{corporation_id}", corporationId.ToString(), "{contract_id}", contractId.ToString());
        }

        public static string ContractsV1Public(int regionId, int page)
        {
            return UrlBuilder(ContractsV1PublicRaw, "{region_id}", regionId.ToString()) + $"?page={page}";
        }

        public static string ContractsV1PublicBids(int contractId, int page)
        {
            return UrlBuilder(ContractsV1PublicBidsRaw, "{contract_id}", contractId.ToString()) + $"?page={page}";
        }

        public static string ContractsV1PublicItems(int contractId, int page)
        {
            return UrlBuilder(ContractsV1PublicItemsRaw, "{contract_id}", contractId.ToString()) + $"?page={page}";
        }

        #endregion

        #region Corporations

        private static string CorporationV4PublicInfoRaw => "/v4/corporations/{corporation_id}/";
        private static string CorporationV2AllianceHistoryRaw => "/v2/corporations/{corporation_id}/alliancehistory/";
        private static string CorporationV2BluepintsRaw => "/v2/corporations/{corporation_id}/blueprints/";
        private static string CorporationV3ContainersLogsRaw => "/v3/corporations/{corporation_id}/containers/logs/";
        private static string CorporationV2DivisionsRaw => "/v2/corporations/{corporation_id}/divisions/";
        private static string CorporationV1FacilitiesRaw => "/v1/corporations/{corporation_id}/facilities/";
        private static string CorporationV1IconsRaw => "/v1/corporations/{corporation_id}/icons/";
        private static string CorporationV2MedalsRaw => "/v2/corporations/{corporation_id}/medals/";
        private static string CorporationV2MedalsIssuedRaw => "/v2/corporations/{corporation_id}/medals/issued/";
        private static string CorporationV4MembersRaw => "/v4/corporations/{corporation_id}/members/";
        private static string CorporationV2MembersLimitRaw => "/v2/corporations/{corporation_id}/members/limit/";
        private static string CorporationV1CorporationMemberTitlesRaw => "/v1/corporations/{corporation_id}/members/titles/";
        private static string CorporationV2MemberTrackingRaw => "/v2/corporations/{corporation_id}/membertracking/";
        private static string CorporationV1RolesRaw => "/v1/corporations/{corporation_id}/roles/";
        private static string CorporationV1RolesHistoryRaw => "/v1/corporations/{corporation_id}/roles/history/";
        private static string CorporationV1ShareHoldersRaw => "/v1/corporations/{corporation_id}/shareholders/";
        private static string CorporationV1StandingsRaw => "/v1/corporations/{corporation_id}/standings/";
        private static string CorporationV2StarbasesRaw => "/v2/corporations/{corporation_id}/starbases/";
        private static string CorporationV2StarbaseRaw => "/v2/corporations/{corporation_id}/starbases/{starbase_id}/";
        private static string CorporationV4StructuresRaw => "/v4/corporations/{corporation_id}/structures/";
        private static string CorporationV1CorporationTitlesRaw => "/v1/corporations/{corporation_id}/titles/";
        private static string CorporationV2NpcCorpsRaw => "/v2/corporations/npccorps/";

        public static string CorporationV4PublicInfo(long corporationId)
        {
            return UrlBuilder(CorporationV4PublicInfoRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string CorporationV2AllianceHistory(long corporationId)
        {
            return UrlBuilder(CorporationV2AllianceHistoryRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string CorporationV2Bluepints(long corporationId, int page)
        {
            return UrlBuilder(CorporationV2BluepintsRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string CorporationV3ContainersLogs(long corporationId, int page)
        {
            return UrlBuilder(CorporationV3ContainersLogsRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string CorporationV2Divisions(long corporationId)
        {
            return UrlBuilder(CorporationV2DivisionsRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string CorporationV1Facilities(long corporationId)
        {
            return UrlBuilder(CorporationV1FacilitiesRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string CorporationV1Icons(long corporationId)
        {
            return UrlBuilder(CorporationV1IconsRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string CorporationV2Medals(long corporationId, int page)
        {
            return UrlBuilder(CorporationV2MedalsRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string CorporationV2MedalsIssued(long corporationId, int page)
        {
            return UrlBuilder(CorporationV2MedalsIssuedRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string CorporationV4Members(long corporationId)
        {
            return UrlBuilder(CorporationV4MembersRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string CorporationV2MembersLimit(long corporationId)
        {
            return UrlBuilder(CorporationV2MembersLimitRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string CorporationV1CorporationMemberTitles(long corporationId)
        {
            return UrlBuilder(CorporationV1CorporationMemberTitlesRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string CorporationV2MemberTracking(long corporationId)
        {
            return UrlBuilder(CorporationV2MemberTrackingRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string CorporationV1Roles(long corporationId)
        {
            return UrlBuilder(CorporationV1RolesRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string CorporationV1RolesHistory(long corporationId, int page)
        {
            return UrlBuilder(CorporationV1RolesHistoryRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string CorporationV1ShareHolders(long corporationId, int page)
        {
            return UrlBuilder(CorporationV1ShareHoldersRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string CorporationV1Standings(long corporationId, int page)
        {
            return UrlBuilder(CorporationV1StandingsRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string CorporationV2Starbases(long corporationId, int page)
        {
            return UrlBuilder(CorporationV2StarbasesRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string CorporationV2Starbase(long corporationId, long starbaseId)
        {
            return UrlBuilder(CorporationV2StarbaseRaw, "{corporation_id}", corporationId.ToString(), "{starbase_id}", starbaseId.ToString());
        }

        public static string CorporationV4Structures(long corporationId, int page)
        {
            return UrlBuilder(CorporationV4StructuresRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string CorporationV1CorporationTitles(long corporationId)
        {
            return UrlBuilder(CorporationV1CorporationTitlesRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string CorporationV2NpcCorps()
        {
            return UrlBuilder(CorporationV2NpcCorpsRaw);
        }

        #endregion

        #region Dogma

        private static string DogmaV1AttributesRaw => "/v1/dogma/attributes/";
        private static string DogmaV1AttributeRaw => "/v1/dogma/attributes/{attribute_id}/";
        private static string DogmaV1DynamicItemRaw => "/v1/dogma/dynamic/items/{type_id}/{item_id}/";
        private static string DogmaV1EffectsRaw => "/v1/dogma/effects/";
        private static string DogmaV2EffectRaw => "/v2/dogma/effects/{effect_id}/";

        public static string DogmaV1Attributes()
        {
            return UrlBuilder(DogmaV1AttributesRaw);
        }

        public static string DogmaV1Attribute(int attributeId)
        {
            return UrlBuilder(DogmaV1AttributeRaw, "{attribute_id}", attributeId.ToString());
        }

        public static string DogmaV1DynamicItem(int typeId, long itemId)
        {
            return UrlBuilder(DogmaV1DynamicItemRaw, "{type_id}", typeId.ToString(), "{item_id}", itemId.ToString());
        }

        public static string DogmaV1Effects()
        {
            return UrlBuilder(DogmaV1EffectsRaw);
        }

        public static string DogmaV2Effect(int effectId)
        {
            return UrlBuilder(DogmaV2EffectRaw, "{effect_id}", effectId.ToString());
        }

        #endregion

        #region FactionWarfare

        private static string FactionWarfareV1CharacterStatsRaw => "/v1/characters/{character_id}/fw/stats/";
        private static string FactionWarfareV1CorporationStatsRaw => "/v1/corporations/{corporation_id}/fw/stats/";
        private static string FactionWarfareV1FactionLeaderboardRaw => "/v1/fw/leaderboards/";
        private static string FactionWarfareV1CharacterLeaderboardRaw => "/v1/fw/leaderboards/characters/";
        private static string FactionWarfareV1CorporationLeaderboardRaw => "/v1/fw/leaderboards/corporations/";
        private static string FactionWarfareV1FactionStatsRaw => "/v1/fw/stats/";
        private static string FactionWarfareV2SystemsRaw => "/v2/fw/systems/";
        private static string FactionWarfareV1WarsRaw => "/v1/fw/wars/";

        public static string FactionWarfareV1CharacterStats(int characterId)
        {
            return UrlBuilder(FactionWarfareV1CharacterStatsRaw, "{character_id}", characterId.ToString());
        }

        public static string FactionWarfareV1CorporationStats(int corporationId)
        {
            return UrlBuilder(FactionWarfareV1CorporationStatsRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string FactionWarfareV1FactionLeaderboard()
        {
            return UrlBuilder(FactionWarfareV1FactionLeaderboardRaw);
        }

        public static string FactionWarfareV1CharacterLeaderboard()
        {
            return UrlBuilder(FactionWarfareV1CharacterLeaderboardRaw);
        }

        public static string FactionWarfareV1CorporationLeaderboard()
        {
            return UrlBuilder(FactionWarfareV1CorporationLeaderboardRaw);
        }

        public static string FactionWarfareV1FactionStats()
        {
            return UrlBuilder(FactionWarfareV1FactionStatsRaw);
        }

        public static string FactionWarfareV2Systems()
        {
            return UrlBuilder(FactionWarfareV2SystemsRaw);
        }

        public static string FactionWarfareV1Wars()
        {
            return UrlBuilder(FactionWarfareV1WarsRaw);
        }

        #endregion

        #region Fittings

        private static string FittingsV2CharacterGetRaw => "/v2/characters/{character_id}/fittings/";
        private static string FittingsV2CharacterUpdateRaw => "/v2/characters/{character_id}/fittings/";
        private static string FittingsV1CharacterDeleteRaw => "/v1/characters/{character_id}/fittings/{fitting_id}/";

        public static string FittingsV2CharacterGet(int characterId)
        {
            return UrlBuilder(FittingsV2CharacterGetRaw, "{character_id}", characterId.ToString());
        }

        public static string FittingsV2CharacterUpdate(int characterId)
        {
            return UrlBuilder(FittingsV2CharacterUpdateRaw, "{character_id}", characterId.ToString());
        }

        public static string FittingsV1CharacterDelete(int characterId, int fittingId)
        {
            return UrlBuilder(FittingsV1CharacterDeleteRaw, "{character_id}", characterId.ToString(), "{fitting_id}", fittingId.ToString());
        }

        #endregion 

        #region Fleets

        private static string FleetsV1CharacterFleetRaw => "/v1/characters/{character_id}/fleet/";
        private static string FleetsV1FleetGetRaw => "/v1/fleets/{fleet_id}/";
        private static string FleetsV1FleetUpdateRaw => "/v1/fleets/{fleet_id}/";
        private static string FleetsV1MembersGetRaw => "/v1/fleets/{fleet_id}/members/";
        private static string FleetsV1MembersInviteRaw => "/v1/fleets/{fleet_id}/members/";
        private static string FleetsV1MemberKickRaw => "/v1/fleets/{fleet_id}/members/{member_id}/";
        private static string FleetsV1MemberMoveRaw => "/v1/fleets/{fleet_id}/members/{member_id}/";
        private static string FleetsV1SquadDeleteRaw => "/v1/fleets/{fleet_id}/squads/{squad_id}/";
        private static string FleetsV1SquadRenameRaw => "/v1/fleets/{fleet_id}/squads/{squad_id}/";
        private static string FleetsV1WingsGetRaw => "/v1/fleets/{fleet_id}/wings/";
        private static string FleetsV1WingsCreateRaw => "/v1/fleets/{fleet_id}/wings/";
        private static string FleetsV1WingsDeleteRaw => "/v1/fleets/{fleet_id}/wings/{wing_id}/";
        private static string FleetsV1WingsRenameRaw => "/v1/fleets/{fleet_id}/wings/{wing_id}/";
        private static string FleetsV1SquadCreateRaw => "/v1/fleets/{fleet_id}/wings/{wing_id}/squads/";

        public static string FleetsV1CharacterFleet(int characterId)
        {
            return UrlBuilder(FleetsV1CharacterFleetRaw, "{character_id}", characterId.ToString());
        }

        public static string FleetsV1FleetGet(long fleetId)
        {
            return UrlBuilder(FleetsV1FleetGetRaw, "{fleet_id}", fleetId.ToString());
        }

        public static string FleetsV1FleetUpdate(long fleetId)
        {
            return UrlBuilder(FleetsV1FleetUpdateRaw, "{fleet_id}", fleetId.ToString());
        }

        public static string FleetsV1MembersGet(long fleetId)
        {
            return UrlBuilder(FleetsV1MembersGetRaw, "{fleet_id}", fleetId.ToString());
        }

        public static string FleetsV1MembersInvite(long fleetId)
        {
            return UrlBuilder(FleetsV1MembersInviteRaw, "{fleet_id}", fleetId.ToString());
        }

        public static string FleetsV1MemberKick(long fleetId, int characterId)
        {
            return UrlBuilder(FleetsV1MemberKickRaw, "{fleet_id}", fleetId.ToString(), "{member_id}", characterId.ToString());
        }

        public static string FleetsV1MemberMove(long fleetId, int characterId)
        {
            return UrlBuilder(FleetsV1MemberMoveRaw, "{fleet_id}", fleetId.ToString(), "{member_id}", characterId.ToString());
        }

        public static string FleetsV1SquadDelete(long fleetId, long squadId)
        {
            return UrlBuilder(FleetsV1SquadDeleteRaw, "{fleet_id}", fleetId.ToString(), "{squad_id}", squadId.ToString());
        }

        public static string FleetsV1SquadRename(long fleetId, long squadId)
        {
            return UrlBuilder(FleetsV1SquadRenameRaw, "{fleet_id}", fleetId.ToString(), "{squad_id}", squadId.ToString());
        }

        public static string FleetsV1WingsGet(long fleetId)
        {
            return UrlBuilder(FleetsV1WingsGetRaw, "{fleet_id}", fleetId.ToString());
        }

        public static string FleetsV1WingsCreate(long fleetId)
        {
            return UrlBuilder(FleetsV1WingsCreateRaw, "{fleet_id}", fleetId.ToString());
        }

        public static string FleetsV1WingsDelete(long fleetId, long wingId)
        {
            return UrlBuilder(FleetsV1WingsDeleteRaw, "{fleet_id}", fleetId.ToString(), "{wing_id}", wingId.ToString());
        }

        public static string FleetsV1WingsRename(long fleetId, long wingId)
        {
            return UrlBuilder(FleetsV1WingsRenameRaw, "{fleet_id}", fleetId.ToString(), "{wing_id}", wingId.ToString());
        }

        public static string FleetsV1SquadCreate(long fleetId, long wingId)
        {
            return UrlBuilder(FleetsV1SquadCreateRaw, "{fleet_id}", fleetId.ToString(), "{wing_id}", wingId.ToString());
        }

        #endregion

        #region Incursions

        private static string IncursionsV1IncursionsRaw => "/v1/incursions/";

        public static string IncursionsV1Incursions()
        {
            return UrlBuilder(IncursionsV1IncursionsRaw);
        }

        #endregion 

        #region Industry

        private static string IndustryV1CharacterJobsRaw => "/v1/characters/{character_id}/industry/jobs/";
        private static string IndustryV1CharacterMiningRaw => "/v1/characters/{character_id}/mining/";
        private static string IndustryV1CorporationExtractionsRaw => "/v1/corporation/{corporation_id}/mining/extractions/";
        private static string IndustryV1CorporationObserversRaw => "/v1/corporation/{corporation_id}/mining/observers/";
        private static string IndustryV1CorporationObserverRaw => "/v1/corporation/{corporation_id}/mining/observers/{observer_id}/";
        private static string IndustryV1CorporationJobsRaw => "/v1/corporations/{corporation_id}/industry/jobs/";
        private static string IndustryV1FacilitiesRaw => "/v1/industry/facilities/";
        private static string IndustryV1SystemsRaw => "/v1/industry/systems/";

        public static string IndustryV1CharacterJobs(int characterId, bool includeCompletedJobs)
        {
            return $"{UrlBuilder(IndustryV1CharacterJobsRaw, "{character_id}", characterId.ToString())}?include_completed={includeCompletedJobs}";
        }

        public static string IndustryV1CharacterMining(int characterId, int page)
        {
            return UrlBuilder(IndustryV1CharacterMiningRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        public static string IndustryV1CorporationExtractions(int corporationId, int page)
        {
            return UrlBuilder(IndustryV1CorporationExtractionsRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string IndustryV1CorporationObservers(int corporationId, int page)
        {
            return UrlBuilder(IndustryV1CorporationObserversRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string IndustryV1CorporationObserver(int corporationId, long observerId, int page)
        {
            return UrlBuilder(IndustryV1CorporationObserverRaw, "{corporation_id}", corporationId.ToString(), "{observer_id}", observerId.ToString()) + $"?page={page}";
        }

        public static string IndustryV1CorporationJobs(int corporationId, bool includeCompletedJobs, int page)
        {
            return UrlBuilder(IndustryV1CorporationJobsRaw, "{corporation_id}", corporationId.ToString()) + $"?include_completed={includeCompletedJobs}&page={page}";
        }

        public static string IndustryV1Facilities()
        {
            return UrlBuilder(IndustryV1FacilitiesRaw);
        }

        public static string IndustryV1Systems()
        {
            return UrlBuilder(IndustryV1SystemsRaw);
        }

        #endregion

        #region Insurance

        private static string InsuranceV1InsuranceRaw => "/v1/insurance/prices/";

        public static string InsuranceV1Insurance()
        {
            return UrlBuilder(InsuranceV1InsuranceRaw);
        }

        #endregion

        #region Killmails

        private static string KillmailsV1CharacterRaw => "/v1/characters/{character_id}/killmails/recent/";
        private static string KillmailsV1CorporationRaw => "/v1/corporations/{corporation_id}/killmails/recent/";
        private static string KillmailsV1KillmailRaw => "/v1/killmails/{killmail_id}/{killmail_hash}/";

        public static string KillmailsV1Character(int characterId, int page)
        {
            return UrlBuilder(KillmailsV1CharacterRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        public static string KillmailsV1Corporation(int corporationId, int page)
        {
            return UrlBuilder(KillmailsV1CorporationRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string KillmailsV1Killmail(int killmailId, string killmailHash)
        {
            return UrlBuilder(KillmailsV1KillmailRaw, "{killmail_id}", killmailId.ToString(), "{killmail_hash}", killmailHash);
        }

        #endregion

        #region Location

        private static string LocationV1LocationRaw => "/v1/characters/{character_id}/location/";
        private static string LocationV2LocationOnlineRaw => "/v2/characters/{character_id}/online/";
        private static string LocationV1LocationShipRaw => "/v1/characters/{character_id}/ship/";

        public static string LocationV1Location(int characterId)
        {
            return UrlBuilder(LocationV1LocationRaw, "{character_id}", characterId.ToString());
        }

        public static string LocationV2LocationOnline(int characterId)
        {
            return UrlBuilder(LocationV2LocationOnlineRaw, "{character_id}", characterId.ToString());
        }

        public static string LocationV1LocationShip(int characterId)
        {
            return UrlBuilder(LocationV1LocationShipRaw, "{character_id}", characterId.ToString());
        }

        #endregion

        #region Loyalty

        private static string LoyaltyV1PointsRaw => "/v1/characters/{character_id}/loyalty/points/";
        private static string LoyaltyV1OffersRaw => "/v1/loyalty/stores/{corporation_id}/offers/";

        public static string LoyaltyV1Points(int characterId)
        {
            return UrlBuilder(LoyaltyV1PointsRaw, "{character_id}", characterId.ToString());
        }

        public static string LoyaltyV1Offers(int corporationId)
        {
            return UrlBuilder(LoyaltyV1OffersRaw, "{corporation_id}", corporationId.ToString());
        }

        #endregion

        #region Mail

        private static string MailV1CharacterRaw => "/v1/characters/{character_id}/mail/";
        private static string MailV1SendRaw => "/v1/characters/{character_id}/mail/";
        private static string MailV1DeleteRaw => "/v1/characters/{character_id}/mail/{mail_id}/";
        private static string MailV1MailRaw => "/v1/characters/{character_id}/mail/{mail_id}/";
        private static string MailV1MetadataRaw => "/v1/characters/{character_id}/mail/{mail_id}/";
        private static string MailV3LabelsAndUnreadCountRaw => "/v3/characters/{character_id}/mail/labels/";
        private static string MailV2CreateLabelRaw => "/v2/characters/{character_id}/mail/labels/";
        private static string MailV1DeleteLabelRaw => "/v1/characters/{character_id}/mail/labels/{label_id}/";
        private static string MailV1MailingListRaw => "/v1/characters/{character_id}/mail/lists/";

        public static string MailV1Character(int characterId, int lastMailId)
        {
            if (lastMailId == 0)
            {
                return UrlBuilder(MailV1CharacterRaw, "{character_id}", characterId.ToString());
            }

            return UrlBuilder(MailV1CharacterRaw, "{character_id}", characterId.ToString()) + $"?last_mail_id={lastMailId}";
        }

        public static string MailV1Send(int characterId)
        {
            return UrlBuilder(MailV1SendRaw, "{character_id}", characterId.ToString());
        }

        public static string MailV1Delete(int characterId, int mailId)
        {
            return UrlBuilder(MailV1DeleteRaw, "{character_id}", characterId.ToString(), "{mail_id}", mailId.ToString());
        }

        public static string MailV1Mail(int characterId, int mailId)
        {
            return UrlBuilder(MailV1MailRaw, "{character_id}", characterId.ToString(), "{mail_id}", mailId.ToString());
        }

        public static string MailV1Metadata(int characterId, int mailId)
        {
            return UrlBuilder(MailV1MetadataRaw, "{character_id}", characterId.ToString(), "{mail_id}", mailId.ToString());
        }

        public static string MailV3LabelsAndUnreadCount(int characterId)
        {
            return UrlBuilder(MailV3LabelsAndUnreadCountRaw, "{character_id}", characterId.ToString());
        }

        public static string MailV2CreateLabel(int characterId)
        {
            return UrlBuilder(MailV2CreateLabelRaw, "{character_id}", characterId.ToString());
        }

        public static string MailV1DeleteLabel(int characterId, int mailId)
        {
            return UrlBuilder(MailV1DeleteLabelRaw, "{character_id}", characterId.ToString(), "{mail_id}", mailId.ToString());
        }

        public static string MailV1MailingList(int characterId)
        {
            return UrlBuilder(MailV1MailingListRaw, "{character_id}", characterId.ToString());
        }

        #endregion 

        #region Market

        private static string MarketV2CharacterOrdersRaw => "/v2/characters/{character_id}/orders/";
        private static string MarketV1CharacterOrdersHistoricRaw => "/v1/characters/{character_id}/orders/history/";
        private static string MarketV3CorporationOrdersRaw => "/v3/corporations/{corporation_id}/orders/";
        private static string MarketV2CorporationOrdersHistoricRaw => "/v2/corporations/{corporation_id}/orders/history/";
        private static string MarketV1HistoryRaw => "/v1/markets/{region_id}/history/";
        private static string MarketV1OrdersRaw => "/v1/markets/{region_id}/orders/";
        private static string MarketV1TypesRaw => "/v1/markets/{region_id}/types/";
        private static string MarketV1GroupsRaw => "/v1/markets/groups/";
        private static string MarketV1GroupRaw => "/v1/markets/groups/{market_group_id}/";
        private static string MarketV1PricesRaw => "/v1/markets/prices/";
        private static string MarketV1StructureRaw => "/v1/markets/structures/{structure_id}/";

        public static string MarketV2CharacterOrders(int characterId)
        {
            return UrlBuilder(MarketV2CharacterOrdersRaw, "{character_id}", characterId.ToString());
        }

        public static string MarketV1CharacterOrdersHistoric(int characterId, int page)
        {
            return UrlBuilder(MarketV1CharacterOrdersHistoricRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        public static string MarketV3CorporationOrders(int corporationId, int page)
        {
            return UrlBuilder(MarketV3CorporationOrdersRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string MarketV2CorporationOrdersHistoric(int corporationId, int page)
        {
            return UrlBuilder(MarketV2CorporationOrdersHistoricRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string MarketV1History(int regionId, int typeId)
        {
            return UrlBuilder(MarketV1HistoryRaw, "{region_id}", regionId.ToString()) + $"?type_id={typeId}";
        }

        public static string MarketV1Orders(int regionId, OrderType type, int page, int? typeId)
        {
            string typeString;

            switch (type)
            {
                case OrderType.All:
                    typeString = "all";
                    break;
                case OrderType.Buy:
                    typeString = "buy";
                    break;
                case OrderType.Sell:
                    typeString = "sell";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            string url = UrlBuilder(MarketV1OrdersRaw, "{region_id}", regionId.ToString()) + $"?order_type={typeString}&page={page}";

            if (typeId.HasValue)
            {
                url = url + $"&type_id={typeId}";
            }

            return url;
        }

        public static string MarketV1Types(int regionId, int page)
        {
            return UrlBuilder(MarketV1TypesRaw, "{region_id}", regionId.ToString()) + $"?page={page}";
        }

        public static string MarketV1Groups()
        {
            return UrlBuilder(MarketV1GroupsRaw);
        }

        public static string MarketV1Group(int marketGroupId)
        {
            return UrlBuilder(MarketV1GroupRaw, "{market_group_id}", marketGroupId.ToString());
        }

        public static string MarketV1Prices()
        {
            return UrlBuilder(MarketV1PricesRaw);
        }

        public static string MarketV1Structure(long structureId, int page)
        {
            return UrlBuilder(MarketV1StructureRaw, "{structure_id}", structureId.ToString()) + $"?page={page}";
        }

        #endregion

        #region Opportunities

        private static string OpportunitiesV1CharacterRaw => "/v1/characters/{character_id}/opportunities/";
        private static string OpportunitiesV1GroupsRaw => "/v1/opportunities/groups/";
        private static string OpportunitiesV1GroupRaw => "/v1/opportunities/groups/{group_id}/";
        private static string OpportunitiesV1TasksRaw => "/v1/opportunities/tasks/";
        private static string OpportunitiesV1TaskRaw => "/v1/opportunities/tasks/{task_id}/";

        public static string OpportunitiesV1Character(int characterId)
        {
            return UrlBuilder(OpportunitiesV1CharacterRaw, "{character_id}", characterId.ToString());
        }

        public static string OpportunitiesV1Groups()
        {
            return UrlBuilder(OpportunitiesV1GroupsRaw);
        }

        public static string OpportunitiesV1Group(int groupId)
        {
            return UrlBuilder(OpportunitiesV1GroupRaw, "{group_id}", groupId.ToString());
        }

        public static string OpportunitiesV1Tasks()
        {
            return UrlBuilder(OpportunitiesV1TasksRaw);
        }

        public static string OpportunitiesV1Task(int taskId)
        {
            return UrlBuilder(OpportunitiesV1TaskRaw, "{task_id}", taskId.ToString());
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
            return UrlBuilder(PlanetaryInteractionV1CorporationsCustomsOfficesRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string PlanetaryInteractionV1Schematics(int schematicId)
        {
            return UrlBuilder(PlanetaryInteractionV1SchematicsRaw, "{schematic_id}", schematicId.ToString());
        }

        #endregion

        #region Routes

        private static string RoutesV1RouteRaw => "/v1/route/{origin}/{destination}/";

        public static string RoutesV1Route(int origin, int destination, EsiV1RoutesFlag flag, string avoid, string connections)
        {
            string extension = $"?flag={flag.ToString()}";

            if (!string.IsNullOrEmpty(avoid) && avoid != "null")
            {
                extension = $"{extension}&avoid={avoid}";
            }

            if (!string.IsNullOrEmpty(connections) && connections != "null")
            {
                extension = $"{extension}&connections={connections}";
            }

            return UrlBuilder(RoutesV1RouteRaw, "{origin}", origin.ToString(), "{destination}", destination.ToString()) + extension;
        }

        #endregion 

        #region Search

        private static string SearchV3AuthSearchRaw => "/v3/characters/{character_id}/search/";
        private static string SearchV2SearchRaw => "/v2/search/";

        public static string SearchV3AuthSearch(int characterId, string search, bool strict, string categories)
        {
            return UrlBuilder(SearchV3AuthSearchRaw, "{character_id}", characterId.ToString()) + $"?categories={categories}&search={search}&strict={strict}";
        }

        public static string SearchV2Search(string search, bool strict, string categories)
        {
            return UrlBuilder(SearchV2SearchRaw) + $"?categories={categories}&search={search}&strict={strict}";
        }

        #endregion 

        #region Skills

        private static string SkillsV4SkillsRaw => "/v4/characters/{character_id}/skills/";
        private static string SkillsV1AttributesRaw => "/v1/characters/{character_id}/attributes/";
        private static string SkillsV2SkillQueueRaw => "/v2/characters/{character_id}/skillqueue/";

        public static string SkillsV4Skills(int characterId)
        {
            return UrlBuilder(SkillsV4SkillsRaw, "{character_id}", characterId.ToString());
        }

        public static string SkillsV1Attributes(int characterId)
        {
            return UrlBuilder(SkillsV1AttributesRaw, "{character_id}", characterId.ToString());
        }

        public static string SkillsV2SkillQueue(int characterId)
        {
            return UrlBuilder(SkillsV2SkillQueueRaw, "{character_id}", characterId.ToString());
        }

        #endregion

        #region Sovereignty

        private static string SovereigntyV1CampaignsRaw => "/v1/sovereignty/campaigns/";
        private static string SovereigntyV1MapRaw => "/v1/sovereignty/map/";
        private static string SovereigntyV1StructuresRaw => "/v1/sovereignty/structures/";

        public static string SovereigntyV1Campaigns()
        {
            return UrlBuilder(SovereigntyV1CampaignsRaw);
        }

        public static string SovereigntyV1Map()
        {
            return UrlBuilder(SovereigntyV1MapRaw);
        }

        public static string SovereigntyV1Structures()
        {
            return UrlBuilder(SovereigntyV1StructuresRaw);
        }

        #endregion 

        #region Status

        private static string StatusV1StatusRaw => "/v1/status/";

        public static string StatusV1Status()
        {
            return UrlBuilder(StatusV1StatusRaw);
        }

        #endregion 

        #region Universe

        private static string UniverseV1AncestriesRaw => "/v1/universe/ancestries/";
        private static string UniverseV1AsteroidBeltRaw => "/v1/universe/asteroid_belts/{asteroid_belt_id}/";
        private static string UniverseV1BloodlinesRaw => "/v1/universe/bloodlines/";
        private static string UniverseV1CategoriesRaw => "/v1/universe/categories/";
        private static string UniverseV1CategoryRaw => "/v1/universe/categories/{category_id}/";
        private static string UniverseV1ConstellationsRaw => "/v1/universe/constellations/";
        private static string UniverseV1ConstellationRaw => "/v1/universe/constellations/{constellation_id}/";
        private static string UniverseV2FactionsRaw => "/v2/universe/factions/";
        private static string UniverseV1GraphicsRaw => "/v1/universe/graphics/";
        private static string UniverseV1GraphicRaw => "/v1/universe/graphics/{graphic_id}/";
        private static string UniverseV1GroupsRaw => "/v1/universe/groups/";
        private static string UniverseV1GroupRaw => "/v1/universe/groups/{group_id}/";
        private static string UniverseV1IdsRaw => "/v1/universe/ids/";
        private static string UniverseV1MoonRaw => "/v1/universe/moons/{moon_id}/";
        private static string UniverseV3NamesRaw => "/v3/universe/names/";
        private static string UniverseV1PlanetRaw => "/v1/universe/planets/{planet_id}/";
        private static string UniverseV1RacesRaw => "/v1/universe/races/";
        private static string UniverseV1RegionsRaw => "/v1/universe/regions/";
        private static string UniverseV1RegionRaw => "/v1/universe/regions/{region_id}/";
        private static string UniverseV1StargateRaw => "/v1/universe/stargates/{stargate_id}/";
        private static string UniverseV1StarRaw => "/v1/universe/stars/{star_id}/";
        private static string UniverseV2StationRaw => "/v2/universe/stations/{station_id}/";
        private static string UniverseV1StructuresRaw => "/v1/universe/structures/";
        private static string UniverseV2StructureRaw => "/v2/universe/structures/{structure_id}/";
        private static string UniverseV1SystemJumpsRaw => "/v1/universe/system_jumps/";
        private static string UniverseV2SystemKillsRaw => "/v2/universe/system_kills/";
        private static string UniverseV1SystemsRaw => "/v1/universe/systems/";
        private static string UniverseV4SystemRaw => "/v4/universe/systems/{system_id}/";
        private static string UniverseV1TypesRaw => "/v1/universe/types/";
        private static string UniverseV3TypeRaw => "/v3/universe/types/{type_id}/";

        public static string UniverseV1Ancestries()
        {
            return UrlBuilder(UniverseV1AncestriesRaw);
        }

        public static string UniverseV1AsteroidBelt(int asteroidBeltId)
        {
            return UrlBuilder(UniverseV1AsteroidBeltRaw, "{asteroid_belt_id}", asteroidBeltId.ToString());
        }

        public static string UniverseV1Bloodlines()
        {
            return UrlBuilder(UniverseV1BloodlinesRaw);
        }

        public static string UniverseV1Categories()
        {
            return UrlBuilder(UniverseV1CategoriesRaw);
        }

        public static string UniverseV1Category(int categoryId)
        {
            return UrlBuilder(UniverseV1CategoryRaw, "{category_id}", categoryId.ToString());
        }

        public static string UniverseV1Constellations()
        {
            return UrlBuilder(UniverseV1ConstellationsRaw);
        }

        public static string UniverseV1Constellation(int constellationId)
        {
            return UrlBuilder(UniverseV1ConstellationRaw, "{constellation_id}", constellationId.ToString());
        }

        public static string UniverseV2Factions()
        {
            return UrlBuilder(UniverseV2FactionsRaw);
        }

        public static string UniverseV1Graphics()
        {
            return UrlBuilder(UniverseV1GraphicsRaw);
        }

        public static string UniverseV1Graphic(int graphicId)
        {
            return UrlBuilder(UniverseV1GraphicRaw, "{graphic_id}", graphicId.ToString());
        }

        public static string UniverseV1Groups(int page)
        {
            return UrlBuilder(UniverseV1GroupsRaw) + $"?page={page}";
        }

        public static string UniverseV1Group(int groupId)
        {
            return UrlBuilder(UniverseV1GroupRaw, "{group_id}", groupId.ToString());
        }

        public static string UniverseV1Ids()
        {
            return UrlBuilder(UniverseV1IdsRaw);
        }

        public static string UniverseV1Moon(int moonId)
        {
            return UrlBuilder(UniverseV1MoonRaw, "{moon_id}", moonId.ToString());
        }

        public static string UniverseV3Names()
        {
            return UrlBuilder(UniverseV3NamesRaw);
        }

        public static string UniverseV1Planet(int planetId)
        {
            return UrlBuilder(UniverseV1PlanetRaw, "{planet_id}", planetId.ToString());
        }

        public static string UniverseV1Races()
        {
            return UrlBuilder(UniverseV1RacesRaw);
        }

        public static string UniverseV1Regions()
        {
            return UrlBuilder(UniverseV1RegionsRaw);
        }

        public static string UniverseV1Region(int regionId)
        {
            return UrlBuilder(UniverseV1RegionRaw, "{region_id}", regionId.ToString());
        }

        public static string UniverseV1Stargate(int stargateId)
        {
            return UrlBuilder(UniverseV1StargateRaw, "{stargate_id}", stargateId.ToString());
        }

        public static string UniverseV1Star(int starId)
        {
            return UrlBuilder(UniverseV1StarRaw, "{star_id}", starId.ToString());
        }

        public static string UniverseV2Station(int stationId)
        {
            return UrlBuilder(UniverseV2StationRaw, "{station_id}", stationId.ToString());
        }

        public static string UniverseV1Structures()
        {
            return UrlBuilder(UniverseV1StructuresRaw);
        }

        public static string UniverseV2Structure(long structureId)
        {
            return UrlBuilder(UniverseV2StructureRaw, "{structure_id}", structureId.ToString());
        }

        public static string UniverseV1SystemJumps()
        {
            return UrlBuilder(UniverseV1SystemJumpsRaw);
        }

        public static string UniverseV2SystemKills()
        {
            return UrlBuilder(UniverseV2SystemKillsRaw);
        }

        public static string UniverseV1Systems()
        {
            return UrlBuilder(UniverseV1SystemsRaw);
        }

        public static string UniverseV4System(int systemId)
        {
            return UrlBuilder(UniverseV4SystemRaw, "{system_id}", systemId.ToString());
        }

        public static string UniverseV1Types(int page)
        {
            return UrlBuilder(UniverseV1TypesRaw) + $"?page={page}";
        }

        public static string UniverseV3Type(int typeId)
        {
            return UrlBuilder(UniverseV3TypeRaw, "{type_id}", typeId.ToString());
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
        private static string WalletV6CharactersWalletJournalRaw => "/v6/characters/{character_id}/wallet/journal/";
        private static string WalletV4CharactersWalletTransactionRaw => "/v1/characters/{character_id}/wallet/transactions/";
        private static string WalletV1CorporationWalletsRaw => "/v1/corporations/{corporation_id}/wallets/";
        private static string WalletV4CorporationDivisionsJournalRaw => "/v4/corporations/{corporation_id}/wallets/{division}/journal/";
        private static string WalletV1CorporationDivisionsTransactionsRaw => "/v1/corporations/{corporation_id}/wallets/{division}/transactions/";

        public static string WalletV1CharactersWallet(int characterId)
        {
            return UrlBuilder(WalletV1CharactersWalletRaw, "{character_id}", characterId.ToString());
        }

        public static string WalletV6CharactersWalletJournal(int characterId, int page)
        {
            return UrlBuilder(WalletV6CharactersWalletJournalRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
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

        public static string WalletV4CorporationDivisionsJournal(int corporationId, int division, int page)
        {
            return UrlBuilder(WalletV4CorporationDivisionsJournalRaw, "{corporation_id}", corporationId.ToString(), "{division}", division.ToString()) + $"?page={page}";
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
