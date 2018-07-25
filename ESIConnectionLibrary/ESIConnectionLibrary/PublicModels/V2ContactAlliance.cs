using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2ContactAlliance
    {
        public int ContactId { get; set; }
        public V2ContactAllianceContactTypes ContactType { get; set; }
        public IList<long> LabelIds { get; set; }
        public float Standing { get; set; }
    }
}