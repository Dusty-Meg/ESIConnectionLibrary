using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3CharactersClones
    {
        public IList<V3CharactersClonesJumpClone> JumpClones { get; set; }
        public V3CharactersClonesHomeLocation HomeLocation { get; set; }
        public DateTime? LastCloneJumpDate { get; set; }
        public DateTime? LastStationChangeDate { get; set; }
    }
}