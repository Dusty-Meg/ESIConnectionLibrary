using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestCorporations
    {
        IList<V2CorporationAllianceHistory> AllianceHistory(long corporationId);
        Task<IList<V2CorporationAllianceHistory>> AllianceHistoryAsync(long corporationId);
        PagedModel<V2CorporationBlueprints> Blueprints(SsoToken token, long corporationId, int page);
        Task<PagedModel<V2CorporationBlueprints>> BlueprintsAsync(SsoToken token, long corporationId, int page);
        PagedModel<V2CorporationContainerLogs> ContainerLogs(SsoToken token, long corporationId, int page);
        Task<PagedModel<V2CorporationContainerLogs>> ContainerLogsAsync(SsoToken token, long corporationId, int page);
        V2CorporationDivisions Divisions(SsoToken token, long corporationId);
        Task<V2CorporationDivisions> DivisionsAsync(SsoToken token, long corporationId);
        IList<V1CorporationFacilities> Facilities(SsoToken token, long corporationId);
        Task<IList<V1CorporationFacilities>> FacilitiesAsync(SsoToken token, long corporationId);
        V1CorporationIcons Icons(long corporationId);
        Task<V1CorporationIcons> IconsAsync(long corporationId);
        PagedModel<V1CorporationMedalsIssued> IssuedMedals(SsoToken token, long corporationId, int page);
        Task<PagedModel<V1CorporationMedalsIssued>> IssuedMedalsAsync(SsoToken token, long corporationId, int page);
        PagedModel<V1CorporationMedals> Medals(SsoToken token, long corporationId, int page);
        Task<PagedModel<V1CorporationMedals>> MedalsAsync(SsoToken token, long corporationId, int page);
        IList<int> Members(SsoToken token, long corporationId);
        Task<IList<int>> MembersAsync(SsoToken token, long corporationId);
        int MembersLimit(SsoToken token, long corporationId);
        Task<int> MembersLimitAsync(SsoToken token, long corporationId);
        IList<V1CorporationMembersTitles> MembersTitles(SsoToken token, long corporationId);
        Task<IList<V1CorporationMembersTitles>> MembersTitlesAsync(SsoToken token, long corporationId);
        IList<V2CorporationMemberTracking> MemberTracking(SsoToken token, long corporationId);
        Task<IList<V2CorporationMemberTracking>> MemberTrackingAsync(SsoToken token, long corporationId);
        IList<int> NpcCorps();
        Task<IList<int>> NpcCorpsAsync();
        V4CorporationPublicInfo PublicInfo(long corporationId);
        Task<V4CorporationPublicInfo> PublicInfoAsync(long corporationId);
        PagedModel<V1CorporationRolesHistory> RoleHistory(SsoToken token, long corporationId, int page);
        Task<PagedModel<V1CorporationRolesHistory>> RoleHistoryAsync(SsoToken token, long corporationId, int page);
        IList<V1CorporationRoles> Roles(SsoToken token, long corporationId);
        Task<IList<V1CorporationRoles>> RolesAsync(SsoToken token, long corporationId);
        PagedModel<V1CorporationShareholders> Shareholders(SsoToken token, long corporationId, int page);
        Task<PagedModel<V1CorporationShareholders>> ShareholdersAsync(SsoToken token, long corporationId, int page);
        PagedModel<V1CorporationStandings> Standings(SsoToken token, long corporationId, int page);
        Task<PagedModel<V1CorporationStandings>> StandingsAsync(SsoToken token, long corporationId, int page);
        V1CorporationStarbase Starbase(SsoToken token, long corporationId, int starbaseId);
        Task<V1CorporationStarbase> StarbaseAsync(SsoToken token, long corporationId, int starbaseId);
        PagedModel<V1CorporationStarbases> Starbases(SsoToken token, long corporationId, int page);
        Task<PagedModel<V1CorporationStarbases>> StarbasesAsync(SsoToken token, long corporationId, int page);
        PagedModel<V4CorporationStructures> Structures(SsoToken token, long corporationId, int page);
        Task<PagedModel<V4CorporationStructures>> StructuresAsync(SsoToken token, long corporationId, int page);
        IList<V1CorporationTitles> Titles(SsoToken token, long corporationId);
        Task<IList<V1CorporationTitles>> TitlesAsync(SsoToken token, long corporationId);
    }
}