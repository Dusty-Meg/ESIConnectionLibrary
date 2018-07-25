using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2ContactCharacterAdd
    {
        public IList<int> ContactIds { get; set; }
        public IList<int> LabelIds { get; set; }
        public float Standing { get; set; }
        public bool? Watched { get; set; }
    }
}
