using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1OpportunitiesGroup
    {
        public IList<int> ConnectedGroups { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Notification { get; set; }
        public IList<int> RequiredTasks { get; set; }
    }
}