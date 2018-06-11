using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2ContactsGetContacts
    {
        public int ContactId { get; set; }
        public V2ContactsContactType ContactType { get; set; }
        public bool? IsBlocked { get; set; }
        public bool? IsWatched { get; set; }
        public IList<long> LabelIds { get; set; }
        public float Standing { get; set; }
    }
}