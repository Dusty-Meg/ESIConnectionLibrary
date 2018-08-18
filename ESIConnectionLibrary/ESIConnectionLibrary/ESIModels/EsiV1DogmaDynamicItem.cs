using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1DogmaDynamicItem
    {
        [JsonProperty(PropertyName = "created_by")]
        public int CreatedBy { get; set; }

        [JsonProperty(PropertyName = "dogma_attributes")]
        public IList<EsiV1DogmaDynamicItemAttribute> DogmaAttributes { get; set; }

        [JsonProperty(PropertyName = "dogma_effects")]
        public IList<EsiV1DogmaDynamicItemEffect> DogmaEffects { get; set; }

        [JsonProperty(PropertyName = "mutator_type_id")]
        public int MutatorTypeId { get; set; }

        [JsonProperty(PropertyName = "source_type_id")]
        public int SourceTypeId { get; set; }
    }
}