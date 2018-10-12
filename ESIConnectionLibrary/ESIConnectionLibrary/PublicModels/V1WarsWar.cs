using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1WarsWar
    {
        public V1WarsWarAggressor Aggressor { get; set; }
        public IList<V1WarsWarAllies> Allies { get; set; }
        public DateTime Declared { get; set; }
        public V1WarsWarDefender Defender { get; set; }
        public DateTime? Finished { get; set; }
        public int Id { get; set; }
        public bool Mutual { get; set; }
        public bool OpenForAllies { get; set; }
        public DateTime? Retracted { get; set; }
        public DateTime? Started { get; set; }
    }
}