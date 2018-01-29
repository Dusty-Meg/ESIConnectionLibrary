using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public void GetSkillQueue_successfully_returns_a_SkillQueue()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            Scopes scopes = Scopes.esi_skills_read_skillqueue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, ScopesFlags = scopes};
            string skillQueueJson = "[{\"finish_date\": \"2016-06-29T10:47:00Z\",\"finished_level\": 3,\"queue_position\": 0,\"skill_id\": 1,\"start_date\": \"2016-06-29T10:46:00Z\"},{\"finish_date\": \"2016-07-15T10:47:00Z\", \"finished_level\": 4,\"queue_position\": 1,\"skill_id\": 1,\"start_date\": \"2016-06-29T10:47:00Z\"},{\"finish_date\": \"2016-08-30T10:47:00Z\",\"finished_level\": 2,\"queue_position\": 2,\"skill_id\": 2,\"start_date\": \"2016-07-15T10:47:00Z\"}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(skillQueueJson);

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            IList<V2SkillQueueSkill> skillQueue = internalLatestSkills.GetSkillQueue(inputToken);

            Assert.Equal(3, skillQueue.Count);
            Assert.NotNull(skillQueue.First().SkillId);
        }

        [Fact]
        public void Passing_in_a_null_as_token_to_GetSkillQueue_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<ESIException>(() => internalLatestSkills.GetSkillQueue(null));

            Assert.Equal("Token can not be null", ex.Message);
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public void Passing_in_a_token_without_the_needed_scope_to_GetSkillQueue_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            SsoToken inputToken = new SsoToken();

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<ESIException>(() => internalLatestSkills.GetSkillQueue(inputToken));

            Assert.Equal("This token does not have esi_skills_read_skillqueue_v1 None", ex.Message);
            Assert.Null(ex.InnerException);
        }


        [Fact]
        public void GetSkills_successfully_returns_a_Skills()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            Scopes scopes = Scopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, ScopesFlags = scopes };
            string skillJson = "{\"skills\": [{\"current_skill_level\": 1,\"skill_id\": 1,\"skillpoints_in_skill\": 10000},{\"current_skill_level\": 1,\"skill_id\": 2,\"skillpoints_in_skill\": 10000}],\"total_sp\": 20000}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(skillJson);

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            V4Skills v4Skills = internalLatestSkills.GetSkills(inputToken);

            Assert.NotNull(v4Skills.Skills);
            Assert.Equal(20000, v4Skills.TotalSp);
            Assert.Equal(2, v4Skills.Skills.Length);
            Assert.Equal(10000, v4Skills.Skills.First().SkillpointsInSkill);
        }

        [Fact]
        public void Passing_in_a_null_as_token_to_GetSkills_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<ESIException>(() => internalLatestSkills.GetSkills(null));

            Assert.Equal("Token can not be null", ex.Message);
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public void Passing_in_a_token_without_the_needed_scope_to_GetSkills_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            SsoToken inputToken = new SsoToken();

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<ESIException>(() => internalLatestSkills.GetSkills(inputToken));

            Assert.Equal("This token does not have esi_skills_read_skills_v1 None", ex.Message);
            Assert.Null(ex.InnerException);
        }


        [Fact]
        public void GetAttributes_successfully_returns_a_Attributes()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            Scopes scopes = Scopes.esi_skills_read_skills_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, ScopesFlags = scopes };
            string attributesJson = "{\"charisma\": 20,\"intelligence\": 20,\"memory\": 20,\"perception\": 20,\"willpower\": 20}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(attributesJson);

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            V1Attributes v1Attributes = internalLatestSkills.GetAttributes(inputToken);

            Assert.Equal(20, v1Attributes.Charisma);
        }

        [Fact]
        public void Passing_in_a_null_as_token_to_GetAttributes_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<ESIException>(() => internalLatestSkills.GetAttributes(null));

            Assert.Equal("Token can not be null", ex.Message);
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public void Passing_in_a_token_without_the_needed_scope_to_GetAttributes_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            SsoToken inputToken = new SsoToken();

            InternalLatestSkills internalLatestSkills = new InternalLatestSkills(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<ESIException>(() => internalLatestSkills.GetAttributes(inputToken));

            Assert.Equal("This token does not have esi_skills_read_skills_v1 None", ex.Message);
            Assert.Null(ex.InnerException);
        }
    }
}
