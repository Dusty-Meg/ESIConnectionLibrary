namespace ESIConnectionLibrary.PublicModels
{
    public class V2DogmaEffectModifiers
    {
        public string Domain { get; set; }
        public int? EffectId { get; set; }
        public string Func { get; set; }
        public int? ModifiedAttributeId { get; set; }
        public int? ModifyingAttributeId { get; set; }
        public int? Operator { get; set; }
    }
}