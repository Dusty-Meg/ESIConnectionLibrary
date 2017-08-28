using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class IndustryTests
    {
        [Fact]
        public void GetCharactersIndustryJobs_successfully_returns_a_SkillQueue()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IList<Scopes> scopes = new List<Scopes> { Scopes.esi_industry_read_character_jobs_v1 };

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, ScopeList = scopes };
            string charactersIndustryJobsJson = "[{\"activity_id\": 1,\"blueprint_id\": 1015116533326,\"blueprint_location_id\": 60006382,\"blueprint_type_id\": 2047,\"cost\": 118,\"duration\": 548,\"end_date\": \"2014-07-19T15:56:14Z\",\"facility_id\": 60006382,\"installer_id\": 498338451,\"job_id\": 229136101,\"licensed_runs\": 200,\"output_location_id\": 60006382,\"runs\": 1,\"start_date\": \"2014-07-19T15:47:06Z\",\"station_id\": 60006382,\"status\": \"active\"}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(charactersIndustryJobsJson);

            InternalIndustry internalIndustry = new InternalIndustry(mockedWebClient.Object, string.Empty);

            IList<CharacterIndustryJob> characterIndustryJob = internalIndustry.GetCharactersIndustryJobs(inputToken, false);

            Assert.Equal(1, characterIndustryJob.Count);
            Assert.NotNull(characterIndustryJob.First().ActivityId);
        }
    }
}
