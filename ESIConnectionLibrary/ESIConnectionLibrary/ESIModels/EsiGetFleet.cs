using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiGetFleet
    {
        [JsonProperty(PropertyName = "is_free_move")]
        public bool IsFreeMove { get; set; }

        [JsonProperty(PropertyName = "is_registered")]
        public bool IsRegistered { get; set; }

        [JsonProperty(PropertyName = "is_voice_enabled")]
        public bool IsVoiceEnabled { get; set; }

        [JsonProperty(PropertyName = "motd")]
        public string Motd { get; set; }
    }
}
