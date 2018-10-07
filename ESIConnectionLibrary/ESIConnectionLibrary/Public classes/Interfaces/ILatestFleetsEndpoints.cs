using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestFleetsEndpoints
    {
        V1FleetCharacter Character(SsoToken token);
        Task<V1FleetCharacter> CharacterAsync(SsoToken token);
        void CreateSquad(SsoToken token, long fleetId, int wingId);
        Task CreateSquadAsync(SsoToken token, long fleetId, int wingId);
        void CreateWing(SsoToken token, long fleetId);
        Task CreateWingAsync(SsoToken token, long fleetId);
        void DeleteSquad(SsoToken token, long fleetId, int squadId);
        Task DeleteSquadAsync(SsoToken token, long fleetId, int squadId);
        void DeleteWing(SsoToken token, long fleetId, int wingId);
        Task DeleteWingAsync(SsoToken token, long fleetId, int wingId);
        V1Fleet Fleet(SsoToken token, long fleetId);
        Task<V1Fleet> FleetAsync(SsoToken token, long fleetId);
        void FleetUpdate(SsoToken token, long fleetId, V1FleetUpdate updateModel);
        Task FleetUpdateAsync(SsoToken token, long fleetId, V1FleetUpdate updateModel);
        void Invite(SsoToken token, long fleetId, V1FleetMemberInvite inviteModel);
        Task InviteAsync(SsoToken token, long fleetId, V1FleetMemberInvite inviteModel);
        void Kick(SsoToken token, long fleetId, int characterId);
        Task KickAsync(SsoToken token, long fleetId, int characterId);
        IList<V1FleetMember> Members(SsoToken token, long fleetId);
        Task<IList<V1FleetMember>> MembersAsync(SsoToken token, long fleetId);
        void Move(SsoToken token, long fleetId, int characterId, V1FleetMemberMove moveModel);
        Task MoveAsync(SsoToken token, long fleetId, int characterId, V1FleetMemberMove moveModel);
        void RenameSquad(SsoToken token, long fleetId, int squadId, string name);
        Task RenameSquadAsync(SsoToken token, long fleetId, int squadId, string name);
        void RenameWing(SsoToken token, long fleetId, int wingId, string name);
        Task RenameWingAsync(SsoToken token, long fleetId, int wingId, string name);
        IList<V1FleetWing> Wings(SsoToken token, long fleetId);
        Task<IList<V1FleetWing>> WingsAsync(SsoToken token, long fleetId);
    }
}