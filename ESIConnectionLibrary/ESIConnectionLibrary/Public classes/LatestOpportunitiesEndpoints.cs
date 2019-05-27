using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestOpportunitiesEndpoints : ILatestOpportunitiesEndpoints
    {
        private readonly IInternalLatestOpportunities _internalLatestOpportunities;

        public LatestOpportunitiesEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestOpportunities = new InternalLatestOpportunities(null, userAgent, testing);
        }

        internal LatestOpportunitiesEndpoints(string userAgent, IWebClient webClient, bool testing = false)
        {
            _internalLatestOpportunities = new InternalLatestOpportunities(webClient, userAgent, testing);
        }

        public IList<V1OpportunitiesCharacter> Character(SsoToken token)
        {
            return _internalLatestOpportunities.Character(token);
        }

        public async Task<IList<V1OpportunitiesCharacter>> CharacterAsync(SsoToken token)
        {
            return await _internalLatestOpportunities.CharacterAsync(token);
        }

        public IList<int> Groups()
        {
            return _internalLatestOpportunities.Groups();
        }

        public async Task<IList<int>> GroupsAsync()
        {
            return await _internalLatestOpportunities.GroupsAsync();
        }

        public V1OpportunitiesGroup Group(int groupId)
        {
            return _internalLatestOpportunities.Group(groupId);
        }

        public async Task<V1OpportunitiesGroup> GroupAsync(int groupId)
        {
            return await _internalLatestOpportunities.GroupAsync(groupId);
        }

        public IList<int> Tasks()
        {
            return _internalLatestOpportunities.Tasks();
        }

        public async Task<IList<int>> TasksAsync()
        {
            return await _internalLatestOpportunities.TasksAsync();
        }

        public V1OpportunitiesTask Task(int taskId)
        {
            return _internalLatestOpportunities.Task(taskId);
        }

        public async Task<V1OpportunitiesTask> TaskAsync(int taskId)
        {
            return await _internalLatestOpportunities.TaskAsync(taskId);
        }
    }
}
