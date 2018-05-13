using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2LocationCharacterOnline
    {
        [JsonProperty(PropertyName = "last_login")]
        public DateTime? LastLogin { get; set; }

        [JsonProperty(PropertyName = "last_logout")]
        public DateTime? LastLogout { get; set; }

        [JsonProperty(PropertyName = "logins")]
        public int? Logins { get; set; }

        [JsonProperty(PropertyName = "online")]
        public bool Online { get; set; }
    }
}