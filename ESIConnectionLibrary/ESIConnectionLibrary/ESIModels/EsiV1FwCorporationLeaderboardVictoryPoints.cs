using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwCorporationLeaderboardVictoryPoints
    {
        [JsonProperty(PropertyName = "active_total")]
        public IList<EsiV1FwCorporationLeaderboardVictoryPointsActiveTotal> ActiveTotal { get; set; }

        [JsonProperty(PropertyName = "last_week")]
        public IList<EsiV1FwCorporationLeaderboardVictoryPointsLastWeek> LastWeek { get; set; }

        [JsonProperty(PropertyName = "yesterday")]
        public IList<EsiV1FwCorporationLeaderboardVictoryPointsYesterday> Yesterday { get; set; }
    }
}