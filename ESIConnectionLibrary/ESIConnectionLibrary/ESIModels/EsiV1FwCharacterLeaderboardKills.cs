using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwCharacterLeaderboardKills
    {
        [JsonProperty(PropertyName = "active_total")]
        public IList<EsiV1FwCharacterLeaderboardKillsActiveTotal> ActiveTotal { get; set; }

        [JsonProperty(PropertyName = "last_week")]
        public IList<EsiV1FwCharacterLeaderboardKillsLastWeek> LastWeek { get; set; }

        [JsonProperty(PropertyName = "yesterday")]
        public IList<EsiV1FwCharacterLeaderboardKillsYesterday> Yesterday { get; set; }
    }
}