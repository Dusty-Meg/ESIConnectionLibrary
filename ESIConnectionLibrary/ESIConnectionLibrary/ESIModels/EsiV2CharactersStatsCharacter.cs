using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersStatsCharacter
    {
        [JsonProperty(PropertyName = "days_of_activity")]
        public long? DaysOfActivity { get; set; }

        [JsonProperty(PropertyName = "minutes")]
        public long? Minutes { get; set; }

        [JsonProperty(PropertyName = "sessions_started")]
        public long? SessionsStarted { get; set; }
    }
}