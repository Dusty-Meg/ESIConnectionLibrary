using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersStatsOrbital
    {
        [JsonProperty(PropertyName = "strike_characters_killed")]
        public long? StrikeCharactersKilled { get; set; }

        [JsonProperty(PropertyName = "strike_damage_to_players_armor_amount")]
        public long? StrikeDamageToPlayersArmorAmount { get; set; }

        [JsonProperty(PropertyName = "strike_damage_to_players_shield_amount")]
        public long? StrikeDamageToPlayersShieldAmount { get; set; }
    }
}