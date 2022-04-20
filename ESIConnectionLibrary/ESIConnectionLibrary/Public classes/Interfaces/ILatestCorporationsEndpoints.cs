using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestCorporationsEndpoints
    {
        IList<V3CorporationAllianceHistory> AllianceHistory(long corporationId);
        Task<IList<V3CorporationAllianceHistory>> AllianceHistoryAsync(long corporationId);
        PagedModel<V3CorporationBlueprints> Blueprints(SsoToken token, long corporationId, int page);
        Task<PagedModel<V3CorporationBlueprints>> BlueprintsAsync(SsoToken token, long corporationId, int page);
        PagedModel<V3CorporationContainerLogs> ContainerLogs(SsoToken token, long corporationId, int page);
        Task<PagedModel<V3CorporationContainerLogs>> ContainerLogsAsync(SsoToken token, long corporationId, int page);
        V2CorporationDivisions Divisions(SsoToken token, long corporationId);
        Task<V2CorporationDivisions> DivisionsAsync(SsoToken token, long corporationId);
        IList<V2CorporationFacilities> Facilities(SsoToken token, long corporationId);
        Task<IList<V2CorporationFacilities>> FacilitiesAsync(SsoToken token, long corporationId);
        V2CorporationIcons Icons(long corporationId);
        Task<V2CorporationIcons> IconsAsync(long corporationId);
        PagedModel<V2CorporationMedalsIssued> IssuedMedals(SsoToken token, long corporationId, int page);
        Task<PagedModel<V2CorporationMedalsIssued>> IssuedMedalsAsync(SsoToken token, long corporationId, int page);
        PagedModel<V2CorporationMedals> Medals(SsoToken token, long corporationId, int page);
        Task<PagedModel<V2CorporationMedals>> MedalsAsync(SsoToken token, long corporationId, int page);
        IList<int> Members(SsoToken token, long corporationId);
        Task<IList<int>> MembersAsync(SsoToken token, long corporationId);
        int MembersLimit(SsoToken token, long corporationId);
        Task<int> MembersLimitAsync(SsoToken token, long corporationId);
        IList<V2CorporationMembersTitles> MembersTitles(SsoToken token, long corporationId);
        Task<IList<V2CorporationMembersTitles>> MembersTitlesAsync(SsoToken token, long corporationId);
        IList<V2CorporationMemberTracking> MemberTracking(SsoToken token, long corporationId);
        Task<IList<V2CorporationMemberTracking>> MemberTrackingAsync(SsoToken token, long corporationId);
        IList<int> NpcCorps();
        Task<IList<int>> NpcCorpsAsync();
        V5CorporationPublicInfo PublicInfo(long corporationId);
        Task<V5CorporationPublicInfo> PublicInfoAsync(long corporationId);
        PagedModel<V2CorporationRolesHistory> RoleHistory(SsoToken token, long corporationId, int page);
        Task<PagedModel<V2CorporationRolesHistory>> RoleHistoryAsync(SsoToken token, long corporationId, int page);
        IList<V2CorporationRoles> Roles(SsoToken token, long corporationId);
        Task<IList<V2CorporationRoles>> RolesAsync(SsoToken token, long corporationId);
        PagedModel<V1CorporationShareholders> Shareholders(SsoToken token, long corporationId, int page);
        Task<PagedModel<V1CorporationShareholders>> ShareholdersAsync(SsoToken token, long corporationId, int page);
        PagedModel<V1CorporationStandings> Standings(SsoToken token, long corporationId, int page);
        Task<PagedModel<V1CorporationStandings>> StandingsAsync(SsoToken token, long corporationId, int page);
        V2CorporationStarbase Starbase(SsoToken token, long corporationId, int starbaseId);
        Task<V2CorporationStarbase> StarbaseAsync(SsoToken token, long corporationId, int starbaseId);
        PagedModel<V2CorporationStarbases> Starbases(SsoToken token, long corporationId, int page);
        Task<PagedModel<V2CorporationStarbases>> StarbasesAsync(SsoToken token, long corporationId, int page);
        PagedModel<V4CorporationStructures> Structures(SsoToken token, long corporationId, int page);
        Task<PagedModel<V4CorporationStructures>> StructuresAsync(SsoToken token, long corporationId, int page);
        IList<V2CorporationTitles> Titles(SsoToken token, long corporationId);
        Task<IList<V2CorporationTitles>> TitlesAsync(SsoToken token, long corporationId);
    }
}