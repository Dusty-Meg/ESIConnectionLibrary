using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class PagedModel<T>
    {
        public IList<T> Model { get; set; }
        public int CurrentPage { get; set; }
        public int MaxPages { get; set; }
    }
}
