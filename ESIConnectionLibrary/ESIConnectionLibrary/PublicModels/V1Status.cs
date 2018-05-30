using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1Status
    {
        public int Players { get; set; }
        public string ServerVersion { get; set; }
        public DateTime StartTime { get; set; }
        public bool? Vip { get; set; }
    }
}