using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CharactersChatChannels
    {
        [JsonProperty(PropertyName = "channel_id")]
        public int ChannelId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty(PropertyName = "comparison_key")]
        public string ComparisonKey { get; set; }

        [JsonProperty(PropertyName = "has_password")]
        public bool HasPassword { get; set; }

        [JsonProperty(PropertyName = "motd")]
        public string Motd { get; set; }

        [JsonProperty(PropertyName = "allowed")]
        public IList<EsiV1CharactersChatChannelsAllowed> Allowed { get; set; }

        [JsonProperty(PropertyName = "operators")]
        public IList<EsiV1CharactersChatChannelsOperators> Operators { get; set; }

        [JsonProperty(PropertyName = "blocked")]
        public IList<EsiV1CharactersChatChannelsBlocked> Blocked { get; set; }

        [JsonProperty(PropertyName = "muted")]
        public IList<EsiV1CharactersChatChannelsMuted> Muted { get; set; }
    }
}
