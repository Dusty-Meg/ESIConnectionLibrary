using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1DogmaDynamicItem
    {
        public int CreatedBy { get; set; }
        public IList<V1DogmaDynamicItemAttribute> DogmaAttributes { get; set; }
        public IList<V1DogmaDynamicItemEffect> DogmaEffects { get; set; }
        public int MutatorTypeId { get; set; }
        public int SourceTypeId { get; set; }
    }
}