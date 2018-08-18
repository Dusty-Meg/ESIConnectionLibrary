using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2DogmaEffect
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "disallow_auto_repeat")]
        public bool? DisallowAutoRepeat { get; set; }

        [JsonProperty(PropertyName = "discharge_attribute_id")]
        public int? DischargeAttributeId { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "duration_attribute_id")]
        public int? DurationAttributeId { get; set; }

        [JsonProperty(PropertyName = "effect_category")]
        public int? EffectCategory { get; set; }

        [JsonProperty(PropertyName = "effect_id")]
        public int EffectId { get; set; }

        [JsonProperty(PropertyName = "electronic_chance")]
        public bool? ElectronicChance { get; set; }

        [JsonProperty(PropertyName = "falloff_attribute_id")]
        public int? FalloffAttributeId { get; set; }

        [JsonProperty(PropertyName = "icon_id")]
        public int? IconId { get; set; }

        [JsonProperty(PropertyName = "is_assistance")]
        public bool? IsAssistance { get; set; }

        [JsonProperty(PropertyName = "is_offensive")]
        public bool? IsOffensive { get; set; }

        [JsonProperty(PropertyName = "is_warp_safe")]
        public bool? IsWarpSafe { get; set; }

        [JsonProperty(PropertyName = "modifiers")]
        public EsiV2DogmaEffectModifiers Modifiers { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "post_expression")]
        public int? PostExpression { get; set; }

        [JsonProperty(PropertyName = "pre_expression")]
        public int? PreExpression { get; set; }

        [JsonProperty(PropertyName = "published")]
        public bool? Published { get; set; }

        [JsonProperty(PropertyName = "range_attribute_id")]
        public int? RangeAttributeId { get; set; }

        [JsonProperty(PropertyName = "range_chance")]
        public bool? RangeChance { get; set; }

        [JsonProperty(PropertyName = "tracking_speed_attribute_id")]
        public int? TrackingSpeedAttributeId { get; set; }
    }
}