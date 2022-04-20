using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersFatigue
    {
        [JsonProperty(PropertyName = "last_jump_date")]
        public DateTime? LastJumpDate { get; set; }

        [JsonProperty(PropertyName = "jump_fatigue_expire_date")]
        public DateTime? JumpFatigueExpireDate { get; set; }

        [JsonProperty(PropertyName = "last_update_date")]
        public DateTime? LastUpdateDate { get; set; }
    }
}
