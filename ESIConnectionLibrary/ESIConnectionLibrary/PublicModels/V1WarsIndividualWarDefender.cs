﻿namespace ESIConnectionLibrary.PublicModels
{
    public class V1WarsIndividualWarDefender
    {
        public int? AllianceId { get; set; }
        public int? CorporationId { get; set; }
        public float IskDestroyed { get; set; }
        public int ShipsKilled { get; set; }
    }
}