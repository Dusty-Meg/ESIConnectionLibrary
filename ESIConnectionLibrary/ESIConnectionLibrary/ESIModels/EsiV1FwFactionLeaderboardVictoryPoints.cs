using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwFactionLeaderboardVictoryPoints
    {
        [JsonProperty(PropertyName = "active_total")]
        public IList<EsiV1FwFactionLeaderboardVictoryPointsActiveTotal> ActiveTotal { get; set; }

        [JsonProperty(PropertyName = "last_week")]
        public IList<EsiV1FwFactionLeaderboardVictoryPointsLastWeek> LastWeek { get; set; }

        [JsonProperty(PropertyName = "yesterday")]
        public IList<EsiV1FwFactionLeaderboardVictoryPointsYesterday> Yesterday { get; set; }
    }
}