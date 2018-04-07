using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CharactersChatChannelsOperators
    {
        [JsonProperty(PropertyName = "accessor_id")]
        public int AccessorId { get; set; }

        [JsonProperty(PropertyName = "accessor_type")]
        public EsiChatAccessorType AccessorType { get; set; }
    }
}