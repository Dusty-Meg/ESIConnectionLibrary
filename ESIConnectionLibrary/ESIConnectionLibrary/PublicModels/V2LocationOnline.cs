using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2LocationOnline
    {
        public DateTime? LastLogin { get; set; }
        public DateTime? LastLogout { get; set; }
        public int? Logins { get; set; }
        public bool Online { get; set; }
    }
}