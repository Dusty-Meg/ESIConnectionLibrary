using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2FittingsCharacter
    {
        public string Description { get; set; }
        public int FittingId { get; set; }
        public IList<V2FittingsCharacterItem> Items { get; set; }
        public string Name { get; set; }
        public int ShipTypeId { get; set; }
    }
}