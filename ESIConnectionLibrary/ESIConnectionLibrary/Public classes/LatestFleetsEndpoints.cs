using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestFleetsEndpoints : ILatestFleetsEndpoints
    {
        private readonly IInternalLatestFleets _internalLatestFleets;

        public LatestFleetsEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestFleets = new InternalLatestFleets(null, userAgent, testing);
        }

        public V1FleetCharacter Character(SsoToken token)
        {
            return _internalLatestFleets.Character(token);
        }

        public async Task<V1FleetCharacter> CharacterAsync(SsoToken token)
        {
            return await _internalLatestFleets.CharacterAsync(token);
        }

        public V1Fleet Fleet(SsoToken token, long fleetId)
        {
            return _internalLatestFleets.Fleet(token, fleetId);
        }

        public async Task<V1Fleet> FleetAsync(SsoToken token, long fleetId)
        {
            return await _internalLatestFleets.FleetAsync(token, fleetId);
        }

        public void FleetUpdate(SsoToken token, long fleetId, V1FleetUpdate updateModel)
        {
            _internalLatestFleets.FleetUpdate(token, fleetId, updateModel);
        }

        public async Task FleetUpdateAsync(SsoToken token, long fleetId, V1FleetUpdate updateModel)
        {
            await _internalLatestFleets.FleetUpdateAsync(token, fleetId, updateModel);
        }

        public IList<V1FleetMember> Members(SsoToken token, long fleetId)
        {
            return _internalLatestFleets.Members(token, fleetId);
        }

        public async Task<IList<V1FleetMember>> MembersAsync(SsoToken token, long fleetId)
        {
            return await _internalLatestFleets.MembersAsync(token, fleetId);
        }

        public void Invite(SsoToken token, long fleetId, V1FleetMemberInvite inviteModel)
        {
            _internalLatestFleets.Invite(token, fleetId, inviteModel);
        }

        public async Task InviteAsync(SsoToken token, long fleetId, V1FleetMemberInvite inviteModel)
        {
            await _internalLatestFleets.InviteAsync(token, fleetId, inviteModel);
        }

        public void Kick(SsoToken token, long fleetId, int characterId)
        {
            _internalLatestFleets.Kick(token, fleetId, characterId);
        }

        public async Task KickAsync(SsoToken token, long fleetId, int characterId)
        {
            await _internalLatestFleets.KickAsync(token, fleetId, characterId);
        }

        public void Move(SsoToken token, long fleetId, int characterId, V1FleetMemberMove moveModel)
        {
            _internalLatestFleets.Move(token, fleetId, characterId, moveModel);
        }

        public async Task MoveAsync(SsoToken token, long fleetId, int characterId, V1FleetMemberMove moveModel)
        {
            await _internalLatestFleets.MoveAsync(token, fleetId, characterId, moveModel);
        }

        public void DeleteSquad(SsoToken token, long fleetId, int squadId)
        {
            _internalLatestFleets.DeleteSquad(token, fleetId, squadId);
        }

        public async Task DeleteSquadAsync(SsoToken token, long fleetId, int squadId)
        {
            await _internalLatestFleets.DeleteSquadAsync(token, fleetId, squadId);
        }

        public void RenameSquad(SsoToken token, long fleetId, int squadId, string name)
        {
            _internalLatestFleets.RenameSquad(token, fleetId, squadId, name);
        }

        public async Task RenameSquadAsync(SsoToken token, long fleetId, int squadId, string name)
        {
            await _internalLatestFleets.RenameSquadAsync(token, fleetId, squadId, name);
        }

        public IList<V1FleetWing> Wings(SsoToken token, long fleetId)
        {
            return _internalLatestFleets.Wings(token, fleetId);
        }

        public async Task<IList<V1FleetWing>> WingsAsync(SsoToken token, long fleetId)
        {
            return await _internalLatestFleets.WingsAsync(token, fleetId);
        }

        public void CreateWing(SsoToken token, long fleetId)
        {
            _internalLatestFleets.CreateWing(token, fleetId);
        }

        public async Task CreateWingAsync(SsoToken token, long fleetId)
        {
            await _internalLatestFleets.CreateWingAsync(token, fleetId);
        }

        public void DeleteWing(SsoToken token, long fleetId, int wingId)
        {
            _internalLatestFleets.DeleteWing(token, fleetId, wingId);
        }

        public async Task DeleteWingAsync(SsoToken token, long fleetId, int wingId)
        {
            await _internalLatestFleets.DeleteWingAsync(token, fleetId, wingId);
        }

        public void RenameWing(SsoToken token, long fleetId, int wingId, string name)
        {
            _internalLatestFleets.RenameWing(token, fleetId, wingId, name);
        }

        public async Task RenameWingAsync(SsoToken token, long fleetId, int wingId, string name)
        {
            await _internalLatestFleets.RenameWingAsync(token, fleetId, wingId, name);
        }

        public void CreateSquad(SsoToken token, long fleetId, int wingId)
        {
            _internalLatestFleets.CreateSquad(token, fleetId, wingId);
        }

        public async Task CreateSquadAsync(SsoToken token, long fleetId, int wingId)
        {
            await _internalLatestFleets.CreateSquadAsync(token, fleetId, wingId);
        }
    }
}
