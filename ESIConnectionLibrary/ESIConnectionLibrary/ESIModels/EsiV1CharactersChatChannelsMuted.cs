using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CharactersChatChannelsMuted
    {
        [JsonProperty(PropertyName = "accessor_id")]
        public int AccessorId { get; set; }

        [JsonProperty(PropertyName = "accessor_type")]
        public EsiChatAccessorType AccessorType { get; set; }

        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "end_at")]
        public DateTime? EndAt { get; set; }
    }
}