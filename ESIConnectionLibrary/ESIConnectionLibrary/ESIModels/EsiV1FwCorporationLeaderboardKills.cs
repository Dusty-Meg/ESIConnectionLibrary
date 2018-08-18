using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwCorporationLeaderboardKills
    {
        [JsonProperty(PropertyName = "active_total")]
        public IList<EsiV1FwCorporationLeaderboardKillsActiveTotal> ActiveTotal { get; set; }

        [JsonProperty(PropertyName = "last_week")]
        public IList<EsiV1FwCorporationLeaderboardKillsLastWeek> LastWeek { get; set; }

        [JsonProperty(PropertyName = "yesterday")]
        public IList<EsiV1FwCorporationLeaderboardKillsYesterday> Yesterday { get; set; }
    }
}