using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestFleets : IInternalLatestFleets
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestFleets(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public V1FleetCharacter Character(SsoToken token)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_read_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1CharacterFleet(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 60));

            EsiV1FleetCharacter model = JsonConvert.DeserializeObject<EsiV1FleetCharacter>(esiRaw.Model);

            return _mapper.Map<EsiV1FleetCharacter, V1FleetCharacter>(model);
        }

        public async Task<V1FleetCharacter> CharacterAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_read_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1CharacterFleet(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 60));

            EsiV1FleetCharacter model = JsonConvert.DeserializeObject<EsiV1FleetCharacter>(esiRaw.Model);

            return _mapper.Map<EsiV1FleetCharacter, V1FleetCharacter>(model);
        }

        public V1Fleet Fleet(SsoToken token, long fleetId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_read_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1FleetGet(fleetId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1Fleet model = JsonConvert.DeserializeObject<EsiV1Fleet>(esiRaw.Model);

            return _mapper.Map<EsiV1Fleet, V1Fleet>(model);
        }

        public async Task<V1Fleet> FleetAsync(SsoToken token, long fleetId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_read_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1FleetGet(fleetId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1Fleet model = JsonConvert.DeserializeObject<EsiV1Fleet>(esiRaw.Model);

            return _mapper.Map<EsiV1Fleet, V1Fleet>(model);
        }

        public void FleetUpdate(SsoToken token, long fleetId, V1FleetUpdate updateModel)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1FleetUpdate(fleetId), _testing);

            EsiV1FleetUpdate model = _mapper.Map<EsiV1FleetUpdate>(updateModel);

            string objectModel = JsonConvert.SerializeObject(model);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Put(StaticMethods.CreateHeaders(token), url, objectModel));
        }

        public async Task FleetUpdateAsync(SsoToken token, long fleetId, V1FleetUpdate updateModel)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1FleetUpdate(fleetId), _testing);

            EsiV1FleetUpdate model = _mapper.Map<EsiV1FleetUpdate>(updateModel);

            string objectModel = JsonConvert.SerializeObject(model);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.PutAsync(StaticMethods.CreateHeaders(token), url, objectModel));
        }

        public IList<V1FleetMember> Members(SsoToken token, long fleetId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_read_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1MembersGet(fleetId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            IList<EsiV1FleetMember> model = JsonConvert.DeserializeObject<IList<EsiV1FleetMember>>(esiRaw.Model);

            return _mapper.Map< IList<EsiV1FleetMember>, IList<V1FleetMember>>(model);
        }

        public async Task<IList<V1FleetMember>> MembersAsync(SsoToken token, long fleetId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_read_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1MembersGet(fleetId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 5));

            IList<EsiV1FleetMember> model = JsonConvert.DeserializeObject<IList<EsiV1FleetMember>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1FleetMember>, IList<V1FleetMember>>(model);
        }

        public void Invite(SsoToken token, long fleetId, V1FleetMemberInvite inviteModel)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1MembersInvite(fleetId), _testing);

            EsiV1FleetMemberInvite model = _mapper.Map<EsiV1FleetMemberInvite>(inviteModel);

            string objectModel = JsonConvert.SerializeObject(model);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, objectModel));
        }

        public async Task InviteAsync(SsoToken token, long fleetId, V1FleetMemberInvite inviteModel)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1MembersInvite(fleetId), _testing);

            EsiV1FleetMemberInvite model = _mapper.Map<EsiV1FleetMemberInvite>(inviteModel);

            string objectModel = JsonConvert.SerializeObject(model);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, objectModel));
        }

        public void Kick(SsoToken token, long fleetId, int characterId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1MemberKick(fleetId, characterId), _testing);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Delete(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public async Task KickAsync(SsoToken token, long fleetId, int characterId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1MemberKick(fleetId, characterId), _testing);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.DeleteAsync(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public void Move(SsoToken token, long fleetId, int characterId, V1FleetMemberMove moveModel)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1MemberMove(fleetId, characterId), _testing);

            EsiV1FleetMemberInvite model = _mapper.Map<EsiV1FleetMemberInvite>(moveModel);

            string objectModel = JsonConvert.SerializeObject(model);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Put(StaticMethods.CreateHeaders(token), url, objectModel));
        }

        public async Task MoveAsync(SsoToken token, long fleetId, int characterId, V1FleetMemberMove moveModel)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1MemberMove(fleetId, characterId), _testing);

            EsiV1FleetMemberInvite model = _mapper.Map<EsiV1FleetMemberInvite>(moveModel);

            string objectModel = JsonConvert.SerializeObject(model);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PutAsync(StaticMethods.CreateHeaders(token), url, objectModel));
        }

        public void DeleteSquad(SsoToken token, long fleetId, int squadId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1SquadDelete(fleetId, squadId), _testing);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Delete(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public async Task DeleteSquadAsync(SsoToken token, long fleetId, int squadId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1SquadDelete(fleetId, squadId), _testing);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.DeleteAsync(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public void RenameSquad(SsoToken token, long fleetId, int squadId, string name)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1SquadRename(fleetId, squadId), _testing);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Put(StaticMethods.CreateHeaders(token), url, name));
        }

        public async Task RenameSquadAsync(SsoToken token, long fleetId, int squadId, string name)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1SquadRename(fleetId, squadId), _testing);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PutAsync(StaticMethods.CreateHeaders(token), url, name));
        }

        public IList<V1FleetWing> Wings(SsoToken token, long fleetId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_read_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1WingsGet(fleetId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            IList<EsiV1FleetWing> model = JsonConvert.DeserializeObject<IList<EsiV1FleetWing>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1FleetWing>, IList<V1FleetWing>>(model);
        }

        public async Task<IList<V1FleetWing>> WingsAsync(SsoToken token, long fleetId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_read_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1WingsGet(fleetId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 5));

            IList<EsiV1FleetWing> model = JsonConvert.DeserializeObject<IList<EsiV1FleetWing>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1FleetWing>, IList<V1FleetWing>>(model);
        }

        public void CreateWing(SsoToken token, long fleetId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1WingsCreate(fleetId), _testing);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public async Task CreateWingAsync(SsoToken token, long fleetId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1WingsCreate(fleetId), _testing);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public void DeleteWing(SsoToken token, long fleetId, int wingId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1WingsDelete(fleetId, wingId), _testing);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Delete(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public async Task DeleteWingAsync(SsoToken token, long fleetId, int wingId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1WingsDelete(fleetId, wingId), _testing);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.DeleteAsync(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public void RenameWing(SsoToken token, long fleetId, int wingId, string name)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1WingsRename(fleetId, wingId), _testing);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Put(StaticMethods.CreateHeaders(token), url, name));
        }

        public async Task RenameWingAsync(SsoToken token, long fleetId, int wingId, string name)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1WingsRename(fleetId, wingId), _testing);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PutAsync(StaticMethods.CreateHeaders(token), url, name));
        }

        public void CreateSquad(SsoToken token, long fleetId, int wingId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1SquadCreate(fleetId, wingId), _testing);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, string.Empty));
        }

        public async Task CreateSquadAsync(SsoToken token, long fleetId, int wingId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_write_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsV1SquadCreate(fleetId, wingId), _testing);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, string.Empty));
        }
    }
}
