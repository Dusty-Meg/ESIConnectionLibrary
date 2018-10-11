using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class InsuranceIntegrationTests
    {
        [Fact]
        public void Insurance_successfully_returns_a_listV1InsuranceInsurance()
        {
            LatestInsuranceEndpoints internalLatestInsurance = new LatestInsuranceEndpoints(string.Empty, true);

            IList<V1InsuranceInsurance> returnModel = internalLatestInsurance.Insurance();

            Assert.Single(returnModel);

            Assert.Single(returnModel[0].Levels);

            Assert.Equal(10.01f, returnModel[0].Levels[0].Cost);
            Assert.Equal("Basic", returnModel[0].Levels[0].Name);
            Assert.Equal(20.01f, returnModel[0].Levels[0].Payout);

            Assert.Equal(1, returnModel[0].TypeId);
        }

        [Fact]
        public async Task InsuranceAsync_successfully_returns_a_listV1InsuranceInsurance()
        {
            LatestInsuranceEndpoints internalLatestInsurance = new LatestInsuranceEndpoints(string.Empty, true);

            IList<V1InsuranceInsurance> returnModel = await internalLatestInsurance.InsuranceAsync();

            Assert.Single(returnModel);

            Assert.Single(returnModel[0].Levels);

            Assert.Equal(10.01f, returnModel[0].Levels[0].Cost);
            Assert.Equal("Basic", returnModel[0].Levels[0].Name);
            Assert.Equal(20.01f, returnModel[0].Levels[0].Payout);

            Assert.Equal(1, returnModel[0].TypeId);
        }
    }
}
