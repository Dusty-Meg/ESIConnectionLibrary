using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1WarsIndividualWar
    {
        public V1WarsIndividualWarAggressor Aggressor { get; set; }
        public IList<V1WarsIndividualWarAllies> Allies { get; set; }
        public DateTime Declared { get; set; }
        public V1WarsIndividualWarDefender Defender { get; set; }
        public DateTime? Finished { get; set; }
        public int Id { get; set; }
        public bool Mutual { get; set; }
        public bool OpenForAllies { get; set; }
        public DateTime? Retracted { get; set; }
        public DateTime? Started { get; set; }
    }
}