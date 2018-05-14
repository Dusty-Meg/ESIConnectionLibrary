using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3CharactersClonesJumpClone
    {
        [JsonProperty(PropertyName = "implants")]
        public IList<int> Implants { get; set; }

        [JsonProperty(PropertyName = "jump_clone_id")]
        public int JumpCloneId { get; set; }

        [JsonProperty(PropertyName = "location_id")]
        public long LocationId { get; set; }

        [JsonProperty(PropertyName = "location_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EsiV3CharactersClonesLocationType LocationType { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}