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
            IList<Scopes> scopes = new List<Scopes>{ Scopes.esi_skills_read_skillqueue_v1 };

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, ScopeList = scopes};
            string skillQueueJson = "[{\"finish_date\": \"2016-06-29T10:47:00Z\",\"finished_level\": 3,\"queue_position\": 0,\"skill_id\": 1,\"start_date\": \"2016-06-29T10:46:00Z\"},{\"finish_date\": \"2016-07-15T10:47:00Z\", \"finished_level\": 4,\"queue_position\": 1,\"skill_id\": 1,\"start_date\": \"2016-06-29T10:47:00Z\"},{\"finish_date\": \"2016-08-30T10:47:00Z\",\"finished_level\": 2,\"queue_position\": 2,\"skill_id\": 2,\"start_date\": \"2016-07-15T10:47:00Z\"}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(skillQueueJson);

            InternalSkills internalSkills = new InternalSkills(mockedWebClient.Object);

            IList<SkillQueueSkill> skillQueue = internalSkills.GetSkillQueue(inputToken);

            Assert.Equal(3, skillQueue.Count);
            Assert.NotNull(skillQueue.First().SkillId);
        }

        [Fact]
        public void Passing_in_a_null_as_token_to_GetSkillQueue_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            InternalSkills internalSkills = new InternalSkills(mockedWebClient.Object);

            Exception ex = Assert.Throws<ESIException>(() => internalSkills.GetSkillQueue(null));

            Assert.Equal("Token can not be null", ex.Message);
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public void Passing_in_a_token_without_the_needed_scope_to_GetSkillQueue_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            SsoToken inputToken = new SsoToken();

            InternalSkills internalSkills = new InternalSkills(mockedWebClient.Object);

            Exception ex = Assert.Throws<ESIException>(() => internalSkills.GetSkillQueue(inputToken));

            Assert.Equal("This token does not have esi_skills_read_skillqueue_v1", ex.Message);
            Assert.Null(ex.InnerException);
        }


        [Fact]
        public void GetSkills_successfully_returns_a_Skills()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IList<Scopes> scopes = new List<Scopes> { Scopes.esi_skills_read_skills_v1 };

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, ScopeList = scopes };
            string skillJson = "{\"skills\": [{\"current_skill_level\": 1,\"skill_id\": 1,\"skillpoints_in_skill\": 10000},{\"current_skill_level\": 1,\"skill_id\": 2,\"skillpoints_in_skill\": 10000}],\"total_sp\": 20000}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(skillJson);

            InternalSkills internalSkills = new InternalSkills(mockedWebClient.Object);

            Skills skills = internalSkills.GetSkills(inputToken);

            Assert.NotNull(skills.skills);
            Assert.Equal(20000, skills.TotalSp);
            Assert.Equal(2, skills.skills.Length);
            Assert.Equal(10000, skills.skills.First().SkillpointsInSkill);
        }

        [Fact]
        public void Passing_in_a_null_as_token_to_GetSkills_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            InternalSkills internalSkills = new InternalSkills(mockedWebClient.Object);

            Exception ex = Assert.Throws<ESIException>(() => internalSkills.GetSkills(null));

            Assert.Equal("Token can not be null", ex.Message);
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public void Passing_in_a_token_without_the_needed_scope_to_GetSkills_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            SsoToken inputToken = new SsoToken();

            InternalSkills internalSkills = new InternalSkills(mockedWebClient.Object);

            Exception ex = Assert.Throws<ESIException>(() => internalSkills.GetSkills(inputToken));

            Assert.Equal("This token does not have esi_skills_read_skills_v1", ex.Message);
            Assert.Null(ex.InnerException);
        }


        [Fact]
        public void GetAttributes_successfully_returns_a_Attributes()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IList<Scopes> scopes = new List<Scopes> { Scopes.esi_skills_read_skills_v1 };

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, ScopeList = scopes };
            string attributesJson = "{\"charisma\": 20,\"intelligence\": 20,\"memory\": 20,\"perception\": 20,\"willpower\": 20}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(attributesJson);

            InternalSkills internalSkills = new InternalSkills(mockedWebClient.Object);

            Attributes attributes = internalSkills.GetAttributes(inputToken);

            Assert.Equal(20, attributes.Charisma);
        }

        [Fact]
        public void Passing_in_a_null_as_token_to_GetAttributes_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            InternalSkills internalSkills = new InternalSkills(mockedWebClient.Object);

            Exception ex = Assert.Throws<ESIException>(() => internalSkills.GetAttributes(null));

            Assert.Equal("Token can not be null", ex.Message);
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public void Passing_in_a_token_without_the_needed_scope_to_GetAttributes_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            SsoToken inputToken = new SsoToken();

            InternalSkills internalSkills = new InternalSkills(mockedWebClient.Object);

            Exception ex = Assert.Throws<ESIException>(() => internalSkills.GetAttributes(inputToken));

            Assert.Equal("This token does not have esi_skills_read_skills_v1", ex.Message);
            Assert.Null(ex.InnerException);
        }
    }
}
