namespace ESIConnectionLibrary.PublicModels
{
    public class V1CorporationShareholders
    {
        public long ShareCount { get; set; }
        public int ShareholderId { get; set; }
        public V1CorporationShareholdersShareholdersType ShareholderType { get; set; }
    }
}