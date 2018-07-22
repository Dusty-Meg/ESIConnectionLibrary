using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CorporationMembersTitles
    {
        public int CharacterId { get; set; }
        public IList<int> Titles { get; set; }
    }
}