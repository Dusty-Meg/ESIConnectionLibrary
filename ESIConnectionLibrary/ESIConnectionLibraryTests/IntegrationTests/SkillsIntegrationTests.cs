using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class SkillsIntegrationTests
    {
        [Fact]
        public void GetSkillQueue_successfully_returns_a_SkillQueue()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skillqueue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };

            LatestSkillsEndpoints internalLatestSkills = new LatestSkillsEndpoints(string.Empty, true);

            IList<V2SkillsSkillQueue> returnModel = internalLatestSkills.SkillQueue(inputToken);

            Assert.Equal(3, returnModel.Count);
            Assert.Equal(1, returnModel.First().SkillId);
        }

        [Fact]
        public async Task GetSkillQueueAsync_successfully_returns_a_SkillQueue()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skillqueue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };

            LatestSkillsEndpoints internalLatestSkills = new LatestSkillsEndpoints(string.Empty, true);

            IList<V2SkillsSkillQueue> returnModel = await internalLatestSkills.SkillQueueAsync(inputToken);

            Assert.Equal(3, returnModel.Count);
            Assert.Equal(1, returnModel.First().SkillId);
        }

        [Fact]
        public void GetSkills_successfully_returns_a_Skills()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };

            LatestSkillsEndpoints internalLatestSkills = new LatestSkillsEndpoints(string.Empty, true);

            V4SkillsSkills returnModel = internalLatestSkills.Skills(inputToken);

            Assert.NotNull(returnModel.Skills);
            Assert.Equal(20000, returnModel.TotalSp);
            Assert.Equal(2, returnModel.Skills.Count);
            Assert.Equal(10000, returnModel.Skills.First().SkillpointsInSkill);
        }

        [Fact]
        public async Task GetSkillsAsync_successfully_returns_a_Skills()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };

            LatestSkillsEndpoints internalLatestSkills = new LatestSkillsEndpoints(string.Empty, true);

            V4SkillsSkills returnModel = await internalLatestSkills.SkillsAsync(inputToken);

            Assert.NotNull(returnModel.Skills);
            Assert.Equal(20000, returnModel.TotalSp);
            Assert.Equal(2, returnModel.Skills.Count);
            Assert.Equal(10000, returnModel.Skills.First().SkillpointsInSkill);
        }

        [Fact]
        public void GetAttributes_successfully_returns_a_Attributes()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };

            LatestSkillsEndpoints internalLatestSkills = new LatestSkillsEndpoints(string.Empty, true);

            V1SkillsAttributes returnModel = internalLatestSkills.Attributes(inputToken);

            Assert.Equal(20, returnModel.Charisma);
        }

        [Fact]
        public async Task GetAttributesAsync_successfully_returns_a_Attributes()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };

            LatestSkillsEndpoints internalLatestSkills = new LatestSkillsEndpoints(string.Empty, true);

            V1SkillsAttributes returnModel = await internalLatestSkills.AttributesAsync(inputToken);

            Assert.Equal(20, returnModel.Charisma);
        }
    }
}
