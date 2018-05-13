using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1MailGetMail
    {
        public string Body { get; set; }
        public int? From { get; set; }
        public IList<int> Labels { get; set; }
        public bool? Read { get; set; }
        public IList<V1MailGetCharactersMailRecipients> Recipients { get; set; }
        public string Subject { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}