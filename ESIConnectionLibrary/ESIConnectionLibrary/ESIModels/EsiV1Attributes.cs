using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1Attributes
    {
        [JsonProperty(PropertyName = "accrued_remap_cooldown_date")]
        public string AccruedRemapCooldownDate { get; set; }

        [JsonProperty(PropertyName = "bonus_remaps")]
        public int? BonusRemaps { get; set; }

        [JsonProperty(PropertyName = "charisma")]
        public int Charisma { get; set; }

        [JsonProperty(PropertyName = "intelligence")]
        public int Intelligence { get; set; }

        [JsonProperty(PropertyName = "last_remap_date")]
        public DateTime? LastRemapDate { get; set; }

        [JsonProperty(PropertyName = "memory")]
        public int Memory { get; set; }

        [JsonProperty(PropertyName = "perception")]
        public int Perception { get; set; }

        [JsonProperty(PropertyName = "willpower")]
        public int Willpower { get; set; }
    }
}
