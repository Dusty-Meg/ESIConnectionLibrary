using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3CharactersClones
    {
        [JsonProperty(PropertyName = "jump_clones")]
        public IList<EsiV3CharactersClonesJumpClone> JumpClones { get; set; }

        [JsonProperty(PropertyName = "home_location")]
        public EsiV3CharactersClonesHomeLocation HomeLocation { get; set; }

        [JsonProperty(PropertyName = "last_clone_jump_date")]
        public DateTime? LastCloneJumpDate { get; set; }

        [JsonProperty(PropertyName = "last_station_change_date")]
        public DateTime? LastStationChangeDate { get; set; }
    }
}