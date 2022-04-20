using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2CharactersCorporationHistory
    {
        public DateTime StartDate { get; set; }

        public int CorporationId { get; set; }

        public bool? IsDeleted { get; set; }

        public int RecordId { get; set; }
    }
}
