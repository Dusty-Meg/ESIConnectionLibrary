﻿using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3UniverseSystemPlanets
    {
        public IList<int> AsteroidBelts { get; set; }
        public IList<int> Moons { get; set; }
        public int PlanetId { get; set; }
    }
}