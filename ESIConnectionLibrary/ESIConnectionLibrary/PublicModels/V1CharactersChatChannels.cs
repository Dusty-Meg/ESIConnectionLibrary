using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CharactersChatChannels
    {
        public int ChannelId { get; set; }

        public string Name { get; set; }

        public int OwnerId { get; set; }

        public string ComparisonKey { get; set; }

        public bool HasPassword { get; set; }

        public string Motd { get; set; }

        public IList<V1CharactersChatChannelsAllowed> Allowed { get; set; }

        public IList<V1CharactersChatChannelsOperators> Operators { get; set; }

        public IList<V1CharactersChatChannelsBlocked> Blocked { get; set; }

        public IList<V1CharactersChatChannelsMuted> Muted { get; set; }
    }
}
