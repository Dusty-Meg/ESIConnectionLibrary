using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CharactersNotificationsContacts
    {
        public float NotificationId { get; set; }

        public DateTime SendDate { get; set; }

        public float StandingLevel { get; set; }

        public string Message { get; set; }

        public int SenderCharacterId { get; set; }
    }
}
