using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CorporationMedals
    {
        public DateTime CreatedAt { get; set; }
        public int CreatorId { get; set; }
        public string Description { get; set; }
        public int MedalId { get; set; }
        public string Title { get; set; }
    }
}