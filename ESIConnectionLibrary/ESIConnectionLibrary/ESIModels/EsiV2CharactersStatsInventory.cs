using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersStatsInventory
    {
        [JsonProperty(PropertyName = "abandon_loot_quantity")]
        public long? AbandonLootQuantity { get; set; }

        [JsonProperty(PropertyName = "trash_item_quantity")]
        public long? TrashItemQuantity { get; set; }
    }
}