using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class EsiModel
    {
        public string Model { get; set; }
        public int? MaxPages { get; set; }
        public string Etag { get; set; }
        public DateTime Expires { get; set; }
        public DateTime LastModified { get; set; }

        public Dictionary<string, string> ResponseHeaders { get; set; }
    }
}