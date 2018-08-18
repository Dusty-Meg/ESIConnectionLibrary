using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwFactionLeaderboardKills
    {
        [JsonProperty(PropertyName = "active_total")]
        public IList<EsiV1FwFactionLeaderboardKillsActiveTotal> ActiveTotal { get; set; }

        [JsonProperty(PropertyName = "last_week")]
        public IList<EsiV1FwFactionLeaderboardKillsLastWeek> LastWeek { get; set; }

        [JsonProperty(PropertyName = "yesterday")]
        public IList<EsiV1FwFactionLeaderboardKillsYesterday> Yesterday { get; set; }
    }
}