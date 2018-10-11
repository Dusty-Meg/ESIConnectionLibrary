using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1InsuranceInsurance
    {
        public IList<V1InsuranceInsuranceLevels> Levels { get; set; }
        public int TypeId { get; set; }
    }
}