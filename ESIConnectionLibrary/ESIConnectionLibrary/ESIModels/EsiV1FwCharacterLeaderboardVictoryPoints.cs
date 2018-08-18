using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwCharacterLeaderboardVictoryPoints
    {
        [JsonProperty(PropertyName = "active_total")]
        public IList<EsiV1FwCharacterLeaderboardVictoryPointsActiveTotal> ActiveTotal { get; set; }

        [JsonProperty(PropertyName = "last_week")]
        public IList<EsiV1FwCharacterLeaderboardVictoryPointsLastWeek> LastWeek { get; set; }

        [JsonProperty(PropertyName = "yesterday")]
        public IList<EsiV1FwCharacterLeaderboardVictoryPointsYesterday> Yesterday { get; set; }
    }
}