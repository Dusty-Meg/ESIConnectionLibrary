using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CharactersResearchAgents
    {
        public int AgentId { get; set; }

        public int SkillTypeId { get; set; }

        public DateTime StartedAt { get; set; }

        public float PointsPerDay { get; set; }

        public float RemainderPoints { get; set; }
    }
}
