using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    public class EsiError
    {
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "sso_status")]
        public int SsoStatus { get; set; }
    }
}