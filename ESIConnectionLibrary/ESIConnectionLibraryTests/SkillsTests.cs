using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class SkillsTests
    {
        [Fact]
        public void SkillQueue_successfully_returns_a_SkillQueue()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skillqueue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };
            string json = "[{\"finish_date\": \"2016-06-29T10:47:00Z\",\"finished_level\": 3,\"queue_position\": 0,\"skill_id\": 1,\"start_date\": \"2016-06-29T10:46:00Z\"},{\"finish_date\": \"2016-07-15T10:47:00Z\", \"finished_level\": 4,\"queue_position\": 1,\"skill_id\": 1,\"start_date\": \"2016-06-29T10:47:00Z\"},{\"finish_date\": \"2016-08-30T10:47:00Z\",\"finished_level\": 2,\"queue_position\": 2,\"skill_id\": 2,\"start_date\": \"2016-07-15T10:47:00Z\"}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            IList<V2SkillsSkillQueue> returnModel = internalLatestSkills.SkillQueue(inputToken);

            Assert.Equal(3, returnModel.Count);
            Assert.Equal(1, returnModel.First().SkillId);
        }

        [Fact]
        public async Task SkillQueueAsync_successfully_returns_a_SkillQueue()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skillqueue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };
            string json = "[{\"finish_date\": \"2016-06-29T10:47:00Z\",\"finished_level\": 3,\"queue_position\": 0,\"skill_id\": 1,\"start_date\": \"2016-06-29T10:46:00Z\"},{\"finish_date\": \"2016-07-15T10:47:00Z\", \"finished_level\": 4,\"queue_position\": 1,\"skill_id\": 1,\"start_date\": \"2016-06-29T10:47:00Z\"},{\"finish_date\": \"2016-08-30T10:47:00Z\",\"finished_level\": 2,\"queue_position\": 2,\"skill_id\": 2,\"start_date\": \"2016-07-15T10:47:00Z\"}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            IList<V2SkillsSkillQueue> returnModel = await internalLatestSkills.SkillQueueAsync(inputToken);

            Assert.Equal(3, returnModel.Count);
            Assert.Equal(1, returnModel.First().SkillId);
        }

        [Fact]
        public void Passing_in_a_null_as_token_to_GetSkillQueue_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<EsiException>(() => internalLatestSkills.SkillQueue(null));

            Assert.Equal("Token can not be null", ex.Message);
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public void Passing_in_a_token_without_the_needed_scope_to_GetSkillQueue_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            SsoToken inputToken = new SsoToken();

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<EsiException>(() => internalLatestSkills.SkillQueue(inputToken));

            Assert.Equal("This token does not have esi_skills_read_skillqueue_v1 it has: None", ex.Message);
            Assert.Null(ex.InnerException);
        }


        [Fact]
        public void Skills_successfully_returns_a_Skills()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };
            string json = "{\"skills\": [{\"current_skill_level\": 1,\"skill_id\": 1,\"skillpoints_in_skill\": 10000},{\"current_skill_level\": 1,\"skill_id\": 2,\"skillpoints_in_skill\": 10000}],\"total_sp\": 20000}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            V4SkillsSkills returnModel = internalLatestSkills.Skills(inputToken);

            Assert.NotNull(returnModel.Skills);
            Assert.Equal(20000, returnModel.TotalSp);
            Assert.Equal(2, returnModel.Skills.Count);
            Assert.Equal(10000, returnModel.Skills.First().SkillpointsInSkill);
        }

        [Fact]
        public async Task SkillsAsync_successfully_returns_a_Skills()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };
            string json = "{\"skills\": [{\"current_skill_level\": 1,\"skill_id\": 1,\"skillpoints_in_skill\": 10000},{\"current_skill_level\": 1,\"skill_id\": 2,\"skillpoints_in_skill\": 10000}],\"total_sp\": 20000}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            V4SkillsSkills returnModel = await internalLatestSkills.SkillsAsync(inputToken);

            Assert.NotNull(returnModel.Skills);
            Assert.Equal(20000, returnModel.TotalSp);
            Assert.Equal(2, returnModel.Skills.Count);
            Assert.Equal(10000, returnModel.Skills.First().SkillpointsInSkill);
        }

        [Fact]
        public void Passing_in_a_null_as_token_to_GetSkills_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<EsiException>(() => internalLatestSkills.Skills(null));

            Assert.Equal("Token can not be null", ex.Message);
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public void Passing_in_a_token_without_the_needed_scope_to_GetSkills_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            SsoToken inputToken = new SsoToken();

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<EsiException>(() => internalLatestSkills.Skills(inputToken));

            Assert.Equal("This token does not have esi_skills_read_skills_v1 it has: None", ex.Message);
            Assert.Null(ex.InnerException);
        }


        [Fact]
        public void Attributes_successfully_returns_a_Attributes()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };
            string json = "{\"charisma\": 20,\"intelligence\": 20,\"memory\": 20,\"perception\": 20,\"willpower\": 20}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            V1SkillsAttributes returnModel = internalLatestSkills.Attributes(inputToken);

            Assert.Equal(20, returnModel.Charisma);
        }

        [Fact]
        public async Task AttributesAsync_successfully_returns_a_Attributes()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            SkillScopes scopes = SkillScopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, SkillScopesFlags = scopes };
            string json = "{\"charisma\": 20,\"intelligence\": 20,\"memory\": 20,\"perception\": 20,\"willpower\": 20}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            V1SkillsAttributes returnModel = await internalLatestSkills.AttributesAsync(inputToken);

            Assert.Equal(20, returnModel.Charisma);
        }

        [Fact]
        public void Passing_in_a_null_as_token_to_GetAttributes_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<EsiException>(() => internalLatestSkills.Attributes(null));

            Assert.Equal("Token can not be null", ex.Message);
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public void Passing_in_a_token_without_the_needed_scope_to_GetAttributes_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            SsoToken inputToken = new SsoToken();

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<EsiException>(() => internalLatestSkills.Attributes(inputToken));

            Assert.Equal("This token does not have esi_skills_read_skills_v1 it has: None", ex.Message);
            Assert.Null(ex.InnerException);
        }
    }
}
