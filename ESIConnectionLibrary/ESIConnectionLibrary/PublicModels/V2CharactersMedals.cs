using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2CharactersMedals
    {
        public int MedalId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CorporationId { get; set; }

        public int IssuerId { get; set; }

        public DateTime Date { get; set; }

        public string Reason { get; set; }

        public MedalsStatus Status { get; set; }

        public IList<V2CharactersMedalsGraphics> Graphics { get; set; }
    }
}
