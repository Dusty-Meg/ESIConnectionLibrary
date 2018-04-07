using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CharactersChatChannelsBlocked
    {
        public int AccessorId { get; set; }

        public ChatAccessorType AccessorType { get; set; }

        public string Reason { get; set; }

        public DateTime? EndAt { get; set; }
    }
}