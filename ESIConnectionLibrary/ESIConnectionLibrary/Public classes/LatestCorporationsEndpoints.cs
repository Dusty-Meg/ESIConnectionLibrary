using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestCorporationsEndpoints : ILatestCorporationsEndpoints
    {
        private readonly IInternalLatestCorporations _internalLatestCorporations;

        public LatestCorporationsEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestCorporations = new InternalLatestCorporations(null, userAgent, testing);
        }

        internal LatestCorporationsEndpoints(string userAgent, IWebClient webClient, bool testing = false)
        {
            _internalLatestCorporations = new InternalLatestCorporations(webClient, userAgent, testing);
        }

        public V4CorporationPublicInfo PublicInfo(long corporationId)
        {
            return _internalLatestCorporations.PublicInfo(corporationId);
        }

        public async Task<V4CorporationPublicInfo> PublicInfoAsync(long corporationId)
        {
            return await _internalLatestCorporations.PublicInfoAsync(corporationId);
        }

        public IList<V3CorporationAllianceHistory> AllianceHistory(long corporationId)
        {
            return _internalLatestCorporations.AllianceHistory(corporationId);
        }

        public async Task<IList<V3CorporationAllianceHistory>> AllianceHistoryAsync(long corporationId)
        {
            return await _internalLatestCorporations.AllianceHistoryAsync(corporationId);
        }

        public PagedModel<V3CorporationBlueprints> Blueprints(SsoToken token, long corporationId, int page)
        {
            return _internalLatestCorporations.Blueprints(token, corporationId, page);
        }

        public async Task<PagedModel<V3CorporationBlueprints>> BlueprintsAsync(SsoToken token, long corporationId, int page)
        {
            return await _internalLatestCorporations.BlueprintsAsync(token, corporationId, page);
        }

        public PagedModel<V3CorporationContainerLogs> ContainerLogs(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestCorporations.ContainerLogs(token, corporationId, page);
        }

        public async Task<PagedModel<V3CorporationContainerLogs>> ContainerLogsAsync(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestCorporations.ContainerLogsAsync(token, corporationId, page);
        }

        public V2CorporationDivisions Divisions(SsoToken token, long corporationId)
        {
            return _internalLatestCorporations.Divisions(token, corporationId);
        }

        public async Task<V2CorporationDivisions> DivisionsAsync(SsoToken token, long corporationId)
        {
            return await _internalLatestCorporations.DivisionsAsync(token, corporationId);
        }

        public IList<V1CorporationFacilities> Facilities(SsoToken token, long corporationId)
        {
            return _internalLatestCorporations.Facilities(token, corporationId);
        }

        public async Task<IList<V1CorporationFacilities>> FacilitiesAsync(SsoToken token, long corporationId)
        {
            return await _internalLatestCorporations.FacilitiesAsync(token, corporationId);
        }

        public V2CorporationIcons Icons(long corporationId)
        {
            return _internalLatestCorporations.Icons(corporationId);
        }

        public async Task<V2CorporationIcons> IconsAsync(long corporationId)
        {
            return await _internalLatestCorporations.IconsAsync(corporationId);
        }

        public PagedModel<V2CorporationMedals> Medals(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestCorporations.Medals(token, corporationId, page);
        }

        public async Task<PagedModel<V2CorporationMedals>> MedalsAsync(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestCorporations.MedalsAsync(token, corporationId, page);
        }

        public PagedModel<V2CorporationMedalsIssued> IssuedMedals(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestCorporations.IssuedMedals(token, corporationId, page);
        }

        public async Task<PagedModel<V2CorporationMedalsIssued>> IssuedMedalsAsync(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestCorporations.IssuedMedalsAsync(token, corporationId, page);
        }

        public IList<int> Members(SsoToken token, long corporationId)
        {
            return _internalLatestCorporations.Members(token, corporationId);
        }

        public async Task<IList<int>> MembersAsync(SsoToken token, long corporationId)
        {
            return await _internalLatestCorporations.MembersAsync(token, corporationId);
        }

        public int MembersLimit(SsoToken token, long corporationId)
        {
            return _internalLatestCorporations.MembersLimit(token, corporationId);
        }

        public async Task<int> MembersLimitAsync(SsoToken token, long corporationId)
        {
            return await _internalLatestCorporations.MembersLimitAsync(token, corporationId);
        }

        public IList<V2CorporationMembersTitles> MembersTitles(SsoToken token, long corporationId)
        {
            return _internalLatestCorporations.MembersTitles(token, corporationId);
        }

        public async Task<IList<V2CorporationMembersTitles>> MembersTitlesAsync(SsoToken token, long corporationId)
        {
            return await _internalLatestCorporations.MembersTitlesAsync(token, corporationId);
        }

        public IList<V2CorporationMemberTracking> MemberTracking(SsoToken token, long corporationId)
        {
            return _internalLatestCorporations.MemberTracking(token, corporationId);
        }

        public async Task<IList<V2CorporationMemberTracking>> MemberTrackingAsync(SsoToken token, long corporationId)
        {
            return await _internalLatestCorporations.MemberTrackingAsync(token, corporationId);
        }

        public IList<V2CorporationRoles> Roles(SsoToken token, long corporationId)
        {
            return _internalLatestCorporations.Roles(token, corporationId);
        }

        public async Task<IList<V2CorporationRoles>> RolesAsync(SsoToken token, long corporationId)
        {
            return await _internalLatestCorporations.RolesAsync(token, corporationId);
        }

        public PagedModel<V2CorporationRolesHistory> RoleHistory(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestCorporations.RoleHistory(token, corporationId, page);
        }

        public async Task<PagedModel<V2CorporationRolesHistory>> RoleHistoryAsync(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestCorporations.RoleHistoryAsync(token, corporationId, page);
        }

        public PagedModel<V1CorporationShareholders> Shareholders(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestCorporations.Shareholders(token, corporationId, page);
        }

        public async Task<PagedModel<V1CorporationShareholders>> ShareholdersAsync(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestCorporations.ShareholdersAsync(token, corporationId, page);
        }

        public PagedModel<V1CorporationStandings> Standings(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestCorporations.Standings(token, corporationId, page);
        }

        public async Task<PagedModel<V1CorporationStandings>> StandingsAsync(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestCorporations.StandingsAsync(token, corporationId, page);
        }

        public PagedModel<V2CorporationStarbases> Starbases(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestCorporations.Starbases(token, corporationId, page);
        }

        public async Task<PagedModel<V2CorporationStarbases>> StarbasesAsync(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestCorporations.StarbasesAsync(token, corporationId, page);
        }

        public V2CorporationStarbase Starbase(SsoToken token, long corporationId, int starbaseId)
        {
            return _internalLatestCorporations.Starbase(token, corporationId, starbaseId);
        }

        public async Task<V2CorporationStarbase> StarbaseAsync(SsoToken token, long corporationId, int starbaseId)
        {
            return await _internalLatestCorporations.StarbaseAsync(token, corporationId, starbaseId);
        }

        public PagedModel<V4CorporationStructures> Structures(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestCorporations.Structures(token, corporationId, page);
        }

        public async Task<PagedModel<V4CorporationStructures>> StructuresAsync(SsoToken token, long corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestCorporations.StructuresAsync(token, corporationId, page);
        }

        public IList<V2CorporationTitles> Titles(SsoToken token, long corporationId)
        {
            return _internalLatestCorporations.Titles(token, corporationId);
        }

        public async Task<IList<V2CorporationTitles>> TitlesAsync(SsoToken token, long corporationId)
        {
            return await _internalLatestCorporations.TitlesAsync(token, corporationId);
        }

        public IList<int> NpcCorps()
        {
            return _internalLatestCorporations.NpcCorps();
        }

        public async Task<IList<int>> NpcCorpsAsync()
        {
            return await _internalLatestCorporations.NpcCorpsAsync();
        }
    }
}
