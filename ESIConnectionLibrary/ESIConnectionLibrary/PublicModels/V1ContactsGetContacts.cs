namespace ESIConnectionLibrary.PublicModels
{
    public class V1ContactsGetContacts
    {
        public float Standing { get; set; }
        public V1ContactsContactType ContactType { get; set; }
        public int ContactId { get; set; }
        public bool? IsWatched { get; set; }
        public bool? IsBlocked { get; set; }
        public long LabelId { get; set; }
    }
}