using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3ClonesClone
    {
        public IList<V3ClonesJumpClone> JumpClones { get; set; }
        public V3ClonesHomeLocation HomeLocation { get; set; }
        public DateTime? LastCloneJumpDate { get; set; }
        public DateTime? LastStationChangeDate { get; set; }
    }
}