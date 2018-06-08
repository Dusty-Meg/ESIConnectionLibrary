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

            IList<V2SkillQueueSkill> skillQueue = internalLatestSkills.GetSkillQueue(inputToken);

            Assert.Equal(3, skillQueue.Count);
            Assert.Equal(1, skillQueue.First().SkillId);
        }

        [Fact]
        public async Task GetSkillQueueAsync_successfully_returns_a_SkillQueue()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skillqueue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };

            LatestSkillsEndpoints internalLatestSkills = new LatestSkillsEndpoints(string.Empty, true);

            IList<V2SkillQueueSkill> skillQueue = await internalLatestSkills.GetSkillQueueAsync(inputToken);

            Assert.Equal(3, skillQueue.Count);
            Assert.Equal(1, skillQueue.First().SkillId);
        }

        [Fact]
        public void GetSkills_successfully_returns_a_Skills()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };

            LatestSkillsEndpoints internalLatestSkills = new LatestSkillsEndpoints(string.Empty, true);

            V4Skills v4Skills = internalLatestSkills.GetSkills(inputToken);

            Assert.NotNull(v4Skills.Skills);
            Assert.Equal(20000, v4Skills.TotalSp);
            Assert.Equal(2, v4Skills.Skills.Length);
            Assert.Equal(10000, v4Skills.Skills.First().SkillpointsInSkill);
        }

        [Fact]
        public async Task GetSkillsAsync_successfully_returns_a_Skills()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };

            LatestSkillsEndpoints internalLatestSkills = new LatestSkillsEndpoints(string.Empty, true);

            V4Skills v4Skills = await internalLatestSkills.GetSkillsAsync(inputToken);

            Assert.NotNull(v4Skills.Skills);
            Assert.Equal(20000, v4Skills.TotalSp);
            Assert.Equal(2, v4Skills.Skills.Length);
            Assert.Equal(10000, v4Skills.Skills.First().SkillpointsInSkill);
        }

        [Fact]
        public void GetAttributes_successfully_returns_a_Attributes()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };

            LatestSkillsEndpoints internalLatestSkills = new LatestSkillsEndpoints(string.Empty, true);

            V1Attributes v1Attributes = internalLatestSkills.GetAttributes(inputToken);

            Assert.Equal(20, v1Attributes.Charisma);
        }

        [Fact]
        public async Task GetAttributesAsync_successfully_returns_a_Attributes()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };

            LatestSkillsEndpoints internalLatestSkills = new LatestSkillsEndpoints(string.Empty, true);

            V1Attributes v1Attributes = await internalLatestSkills.GetAttributesAsync(inputToken);

            Assert.Equal(20, v1Attributes.Charisma);
        }
    }
}
