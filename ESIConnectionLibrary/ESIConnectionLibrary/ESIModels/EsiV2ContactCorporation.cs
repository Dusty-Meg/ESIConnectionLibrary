﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2ContactCorporation
    {
        [JsonProperty(PropertyName = "contact_id")]
        public int ContactId { get; set; }

        [JsonProperty(PropertyName = "contact_type")]
        public EsiV2ContactCorporationContactTypes ContactType { get; set; }

        [JsonProperty(PropertyName = "is_watched")]
        public bool? IsWatched { get; set; }

        [JsonProperty(PropertyName = "label_ids")]
        public IList<long> LabelIds { get; set; }

        [JsonProperty(PropertyName = "standing")]
        public float Standing { get; set; }
    }
}