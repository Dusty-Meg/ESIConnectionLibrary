using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1MailMetadata
    {
        public IList<int> Labels { get; set; }
        public bool? Read { get; set; }
    }
}