using System;

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum MailScopes : long
    {
        None = 0L,
        esi_mail_organize_mail_v1 = 1L << 1,
        esi_mail_read_mail_v1 = 1L << 2,
        esi_mail_send_mail_v1 = 1L << 3,
    }
}