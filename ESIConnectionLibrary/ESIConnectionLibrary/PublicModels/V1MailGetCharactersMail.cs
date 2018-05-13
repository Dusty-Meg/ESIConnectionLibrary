using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1MailGetCharactersMail
    {
        public int? From { get; set; }
        public bool? IsRead { get; set; }
        public IList<int> Labels { get; set; }
        public int? MailId { get; set; }
        public IList<V1MailGetCharactersMailRecipients> Recipients { get; set; }
        public string Subject { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}