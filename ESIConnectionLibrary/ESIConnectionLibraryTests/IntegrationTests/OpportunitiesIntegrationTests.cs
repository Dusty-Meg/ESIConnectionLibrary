using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class OpportunitiesIntegrationTests
    {
        [Fact]
        public void Character_successfully_returns_a_listV1OpportunitiesCharacter()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_opportunities_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestOpportunitiesEndpoints internalLatestOpportunities = new LatestOpportunitiesEndpoints(string.Empty, true);

            IList<V1OpportunitiesCharacter> returnModel = internalLatestOpportunities.Character(inputToken);

            Assert.Single(returnModel);

            Assert.Equal(new DateTime(2016, 04, 29, 12, 34, 56), returnModel[0].CompletedAt);
            Assert.Equal(1, returnModel[0].TaskId);
        }

        [Fact]
        public async Task CharacterAsync_successfully_returns_a_listV1OpportunitiesCharacter()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_opportunities_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestOpportunitiesEndpoints internalLatestOpportunities = new LatestOpportunitiesEndpoints(string.Empty, true);

            IList<V1OpportunitiesCharacter> returnModel = await internalLatestOpportunities.CharacterAsync(inputToken);

            Assert.Single(returnModel);

            Assert.Equal(new DateTime(2016, 04, 29, 12, 34, 56), returnModel[0].CompletedAt);
            Assert.Equal(1, returnModel[0].TaskId);
        }

        [Fact]
        public void Groups_successfully_returns_a_listint()
        {
            LatestOpportunitiesEndpoints internalLatestOpportunities = new LatestOpportunitiesEndpoints(string.Empty, true);

            IList<int> returnModel = internalLatestOpportunities.Groups();

            Assert.Equal(4, returnModel.Count);

            Assert.Equal(100, returnModel[0]);
            Assert.Equal(101, returnModel[1]);
            Assert.Equal(102, returnModel[2]);
            Assert.Equal(103, returnModel[3]);
        }

        [Fact]
        public async Task GroupsAsync_successfully_returns_a_listint()
        {
            LatestOpportunitiesEndpoints internalLatestOpportunities = new LatestOpportunitiesEndpoints(string.Empty, true);

            IList<int> returnModel = await internalLatestOpportunities.GroupsAsync();

            Assert.Equal(4, returnModel.Count);

            Assert.Equal(100, returnModel[0]);
            Assert.Equal(101, returnModel[1]);
            Assert.Equal(102, returnModel[2]);
            Assert.Equal(103, returnModel[3]);
        }

        [Fact]
        public void Tasks_successfully_returns_a_listint()
        {
            LatestOpportunitiesEndpoints internalLatestOpportunities = new LatestOpportunitiesEndpoints(string.Empty, true);

            IList<int> returnModel = internalLatestOpportunities.Tasks();

            Assert.Equal(4, returnModel.Count);

            Assert.Equal(1, returnModel[0]);
            Assert.Equal(2, returnModel[1]);
            Assert.Equal(3, returnModel[2]);
            Assert.Equal(4, returnModel[3]);
        }

        [Fact]
        public void Group_successfully_returns_a_V1OpportunitiesGroup()
        {
            LatestOpportunitiesEndpoints internalLatestOpportunities = new LatestOpportunitiesEndpoints(string.Empty, true);

            V1OpportunitiesGroup returnModel = internalLatestOpportunities.Group(22);

            Assert.NotNull(returnModel);

            Assert.Single(returnModel.ConnectedGroups);

            Assert.Equal(100, returnModel.ConnectedGroups[0]);

            Assert.Equal("As a capsuleer...", returnModel.Description);
            Assert.Equal(103, returnModel.GroupId);
            Assert.Equal("Welcome to New Eden", returnModel.Name);
            Assert.Equal("Completed:<br>Welcome to New Eden", returnModel.Notification);

            Assert.Single(returnModel.RequiredTasks);

            Assert.Equal(19, returnModel.RequiredTasks[0]);
        }

        [Fact]
        public async Task GroupAsync_successfully_returns_a_V1OpportunitiesGroup()
        {
            LatestOpportunitiesEndpoints internalLatestOpportunities = new LatestOpportunitiesEndpoints(string.Empty, true);

            V1OpportunitiesGroup returnModel = await internalLatestOpportunities.GroupAsync(22);

            Assert.NotNull(returnModel);

            Assert.Single(returnModel.ConnectedGroups);

            Assert.Equal(100, returnModel.ConnectedGroups[0]);

            Assert.Equal("As a capsuleer...", returnModel.Description);
            Assert.Equal(103, returnModel.GroupId);
            Assert.Equal("Welcome to New Eden", returnModel.Name);
            Assert.Equal("Completed:<br>Welcome to New Eden", returnModel.Notification);

            Assert.Single(returnModel.RequiredTasks);

            Assert.Equal(19, returnModel.RequiredTasks[0]);
        }

        [Fact]
        public async Task TasksAsync_successfully_returns_a_listint()
        {
            LatestOpportunitiesEndpoints internalLatestOpportunities = new LatestOpportunitiesEndpoints(string.Empty, true);

            IList<int> returnModel = await internalLatestOpportunities.TasksAsync();

            Assert.Equal(4, returnModel.Count);

            Assert.Equal(1, returnModel[0]);
            Assert.Equal(2, returnModel[1]);
            Assert.Equal(3, returnModel[2]);
            Assert.Equal(4, returnModel[3]);
        }

        [Fact]
        public void Task_successfully_returns_a_V1OpportunitiesTask()
        {
            LatestOpportunitiesEndpoints internalLatestOpportunities = new LatestOpportunitiesEndpoints(string.Empty, true);

            V1OpportunitiesTask returnModel = internalLatestOpportunities.Task(22);

            Assert.NotNull(returnModel);

            Assert.Equal("To use station services...", returnModel.Description);
            Assert.Equal("Dock in the station", returnModel.Name);
            Assert.Equal("Completed:<br>Docked in a station!", returnModel.Notification);
            Assert.Equal(10, returnModel.TaskId);
        }

        [Fact]
        public async Task TaskAsync_successfully_returns_a_V1OpportunitiesTask()
        {
            LatestOpportunitiesEndpoints internalLatestOpportunities = new LatestOpportunitiesEndpoints(string.Empty, true);

            V1OpportunitiesTask returnModel = await internalLatestOpportunities.TaskAsync(22);

            Assert.NotNull(returnModel);

            Assert.Equal("To use station services...", returnModel.Description);
            Assert.Equal("Dock in the station", returnModel.Name);
            Assert.Equal("Completed:<br>Docked in a station!", returnModel.Notification);
            Assert.Equal(10, returnModel.TaskId);
        }
    }
}
