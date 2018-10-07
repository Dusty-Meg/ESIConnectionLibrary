using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1FittingsCharacterSave
    {
        public string Description { get; set; }
        public IList<V1FittingsCharacterSaveItem> Items { get; set; }
        public string Name { get; set; }
        public int ShipTypeId { get; set; }
    }
}