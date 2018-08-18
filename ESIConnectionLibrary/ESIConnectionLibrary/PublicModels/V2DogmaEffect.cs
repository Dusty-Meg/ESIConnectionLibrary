namespace ESIConnectionLibrary.PublicModels
{
    public class V2DogmaEffect
    {
        public string Description { get; set; }
        public bool? DisallowAutoRepeat { get; set; }
        public int? DischargeAttributeId { get; set; }
        public string DisplayName { get; set; }
        public int? DurationAttributeId { get; set; }
        public int? EffectCategory { get; set; }
        public int EffectId { get; set; }
        public bool? ElectronicChance { get; set; }
        public int? FalloffAttributeId { get; set; }
        public int? IconId { get; set; }
        public bool? IsAssistance { get; set; }
        public bool? IsOffensive { get; set; }
        public bool? IsWarpSafe { get; set; }
        public V2DogmaEffectModifiers Modifiers { get; set; }
        public string Name { get; set; }
        public int? PostExpression { get; set; }
        public int? PreExpression { get; set; }
        public bool? Published { get; set; }
        public int? RangeAttributeId { get; set; }
        public bool? RangeChance { get; set; }
        public int? TrackingSpeedAttributeId { get; set; }
    }
}