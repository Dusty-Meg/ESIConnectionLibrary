using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1Status
    {
        [JsonProperty(PropertyName = "players")]
        public int Players { get; set; }

        [JsonProperty(PropertyName = "server_version")]
        public string ServerVersion { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty(PropertyName = "vip")]
        public bool? Vip { get; set; }
    }
}
