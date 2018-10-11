using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1IndustryCorporationObservers
    {
        public DateTime LastUpdated { get; set; }
        public long ObserverId { get; set; }
        public V1IndustryCorporationObserversType ObserverType { get; set; }
    }
}