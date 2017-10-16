using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class UniverseGetType
    {
        public long? Capacity { get; set; }
        public string Description { get; set; }
        public IList<UniverseGetTypeDogmaAttribute> DogmaAttributes { get; set; }
        public IList<UniverseGetTypeDogmaEffect> DogmaEffects { get; set; }
        public long? GraphicId { get; set; }
        public int GroupId { get; set; }
        public long? IconId { get; set; }
        public long? MarketGroupId { get; set; }
        public long? Mass { get; set; }
        public string Name { get; set; }
        public long? PackagedVolume { get; set; }
        public long? PortionSize { get; set; }
        public bool Published { get; set; }
        public long? Radius { get; set; }
        public long TypeId { get; set; }
        public long? Volume { get; set; }
    }
}