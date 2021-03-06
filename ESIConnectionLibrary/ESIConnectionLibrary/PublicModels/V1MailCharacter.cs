﻿using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1MailCharacter
    {
        public int? From { get; set; }
        public bool? IsRead { get; set; }
        public IList<int> Labels { get; set; }
        public int? MailId { get; set; }
        public IList<MailRecipients> Recipients { get; set; }
        public string Subject { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}