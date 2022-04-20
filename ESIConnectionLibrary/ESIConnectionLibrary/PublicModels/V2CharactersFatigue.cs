using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2CharactersFatigue
    {
        public DateTime? LastJumpDate { get; set; }

        public DateTime? JumpFatigueExpireDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }
    }
}
