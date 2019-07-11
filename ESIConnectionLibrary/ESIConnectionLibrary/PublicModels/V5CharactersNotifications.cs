using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V5CharactersNotifications
    {
        public long NotificationId { get; set; }

        public int SenderId { get; set; }

        public SenderType SenderType { get; set; }

        public DateTime Timestamp { get; set; }

        public bool? IsRead { get; set; }

        public string Text { get; set; }

        public V5CharactersNotificationType Type { get; set; }
    }
}
