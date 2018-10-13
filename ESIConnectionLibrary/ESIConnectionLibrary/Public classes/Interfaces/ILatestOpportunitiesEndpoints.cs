using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestOpportunitiesEndpoints
    {
        IList<V1OpportunitiesCharacter> Character(SsoToken token);
        Task<IList<V1OpportunitiesCharacter>> CharacterAsync(SsoToken token);
        V1OpportunitiesGroup Group(int groupId);
        Task<V1OpportunitiesGroup> GroupAsync(int groupId);
        IList<int> Groups();
        Task<IList<int>> GroupsAsync();
        V1OpportunitiesTask Task(int taskId);
        Task<V1OpportunitiesTask> TaskAsync(int taskId);
        IList<int> Tasks();
        Task<IList<int>> TasksAsync();
    }
}