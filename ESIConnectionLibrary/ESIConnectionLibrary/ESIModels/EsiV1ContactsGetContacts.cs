using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1ContactsGetContacts
    {
        [JsonProperty(PropertyName = "standing")]
        public float Standing { get; set; }

        [JsonProperty(PropertyName = "contact_type")]
        public EsiV1ContactsContactType ContactType { get; set; }

        [JsonProperty(PropertyName = "contact_id")]
        public int ContactId { get; set; }

        [JsonProperty(PropertyName = "is_watched")]
        public bool? IsWatched { get; set; }

        [JsonProperty(PropertyName = "is_blocked")]
        public bool? IsBlocked { get; set; }

        [JsonProperty(PropertyName = "label_id")]
        public long LabelId { get; set; }
    }
}
