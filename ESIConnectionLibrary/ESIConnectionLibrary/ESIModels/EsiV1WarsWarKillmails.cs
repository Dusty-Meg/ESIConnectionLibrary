using System.Text;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1WarsWarKillmails
    {
        [JsonProperty(PropertyName = "killmail_hash")]
        public string KillmailHash { get; set; }

        [JsonProperty(PropertyName = "killmail_id")]
        public int KillmailId { get; set; }
    }
}
