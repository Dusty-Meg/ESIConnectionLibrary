using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class IndustryIntegrationTests
    {
        [Fact]
        public void GetCharactersIndustryJobs_successfully_returns_a_SkillQueue()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_character_jobs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

            IList<V1CharacterIndustryJob> characterIndustryJob = internalLatestIndustry.GetCharacterIndustryJobs(inputToken, false);

            Assert.Equal(1, characterIndustryJob.Count);
            Assert.Equal(1, characterIndustryJob.First().ActivityId);
            Assert.Equal(V1IndustryJobStatus.Active, characterIndustryJob.First().Status);
        }

        [Fact]
        public async Task GetCharactersIndustryJobsAsync_successfully_returns_a_SkillQueue()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_character_jobs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

            IList<V1CharacterIndustryJob> characterIndustryJob = await internalLatestIndustry.GetCharacterIndustryJobsAsync(inputToken, false);

            Assert.Equal(1, characterIndustryJob.Count);
            Assert.Equal(1, characterIndustryJob.First().ActivityId);
            Assert.Equal(V1IndustryJobStatus.Active, characterIndustryJob.First().Status);
        }
    }
}
