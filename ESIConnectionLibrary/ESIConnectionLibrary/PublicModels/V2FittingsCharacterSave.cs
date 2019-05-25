using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2FittingsCharacterSave
    {
        public string Description { get; set; }
        public IList<V2FittingsCharacterSaveItem> Items { get; set; }
        public string Name { get; set; }
        public int ShipTypeId { get; set; }
    }
}