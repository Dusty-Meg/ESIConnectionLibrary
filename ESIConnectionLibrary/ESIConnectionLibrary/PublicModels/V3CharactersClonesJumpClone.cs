using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3CharactersClonesJumpClone
    {
        public IList<int> Implants { get; set; }
        public int JumpCloneId { get; set; }
        public long LocationId { get; set; }
        public V3CharactersClonesLocationType LocationType { get; set; }
        public string Name { get; set; }
    }
}