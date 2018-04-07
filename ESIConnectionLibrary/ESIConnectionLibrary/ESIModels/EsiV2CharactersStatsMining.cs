using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersStatsMining
    {
        [JsonProperty(PropertyName = "drone_mine")]
        public long? DroneMine { get; set; }

        [JsonProperty(PropertyName = "ore_arkonor")]
        public long? OreArkonor { get; set; }

        [JsonProperty(PropertyName = "ore_bistot")]
        public long? OreBistot { get; set; }

        [JsonProperty(PropertyName = "ore_crokite")]
        public long? OreCrokite { get; set; }

        [JsonProperty(PropertyName = "ore_dark_ochre")]
        public long? OreDarkOchre { get; set; }

        [JsonProperty(PropertyName = "ore_gneiss")]
        public long? OreGneiss { get; set; }

        [JsonProperty(PropertyName = "ore_harvestable_cloud")]
        public long? OreHarvestableCloud { get; set; }

        [JsonProperty(PropertyName = "ore_hedbergite")]
        public long? OreHedbergite { get; set; }

        [JsonProperty(PropertyName = "ore_hemorphite")]
        public long? OreHemorphite { get; set; }

        [JsonProperty(PropertyName = "ore_ice")]
        public long? OreIce { get; set; }

        [JsonProperty(PropertyName = "ore_jaspet")]
        public long? OreJaspet { get; set; }

        [JsonProperty(PropertyName = "ore_kernite")]
        public long? OreKernite { get; set; }

        [JsonProperty(PropertyName = "ore_mercoxit")]
        public long? OreMercoxit { get; set; }

        [JsonProperty(PropertyName = "ore_omber")]
        public long? OreOmber { get; set; }

        [JsonProperty(PropertyName = "ore_plagioclase")]
        public long? OrePlagioclase { get; set; }

        [JsonProperty(PropertyName = "ore_pyroxeres")]
        public long? OrePyroxeres { get; set; }

        [JsonProperty(PropertyName = "ore_scordite")]
        public long? OreScordite { get; set; }

        [JsonProperty(PropertyName = "ore_spodumain")]
        public long? OreSpodumain { get; set; }

        [JsonProperty(PropertyName = "ore_veldspar")]
        public long? OreVeldspar { get; set; }
    }
}