using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1WarsWar
    {
        [JsonProperty(PropertyName = "aggressor")]
        public EsiV1WarsWarAggressor Aggressor { get; set; }

        [JsonProperty(PropertyName = "allies")]
        public IList<EsiV1WarsWarAllies> Allies { get; set; }

        [JsonProperty(PropertyName = "declared")]
        public DateTime Declared { get; set; }

        [JsonProperty(PropertyName = "defender")]
        public EsiV1WarsWarDefender Defender { get; set; }

        [JsonProperty(PropertyName = "finished")]
        public DateTime? Finished { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "mutual")]
        public bool Mutual { get; set; }

        [JsonProperty(PropertyName = "open_for_allies")]
        public bool OpenForAllies { get; set; }

        [JsonProperty(PropertyName = "retracted")]
        public DateTime? Retracted { get; set; }

        [JsonProperty(PropertyName = "started")]
        public DateTime? Started { get; set; }
    }
}