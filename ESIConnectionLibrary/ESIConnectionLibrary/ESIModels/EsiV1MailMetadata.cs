using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1MailMetadata
    {
        [JsonProperty(PropertyName = "labels")]
        public IList<int> Labels { get; set; }

        [JsonProperty(PropertyName = "read")]
        public bool? Read { get; set; }
    }
}