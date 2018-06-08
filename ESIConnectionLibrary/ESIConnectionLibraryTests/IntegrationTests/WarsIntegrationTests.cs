using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class WarsIntegrationTests
    {
        [Fact]
        public void GetWars_successfully_returns_a_listInts()
        {
            LatestWarsEndpoints internalLatestWars = new LatestWarsEndpoints(string.Empty, true);

            IList<int> getWars = internalLatestWars.GetWars(0);

            Assert.Equal(3, getWars.Count);
            Assert.Equal(3, getWars[0]);
            Assert.Equal(2, getWars[1]);
            Assert.Equal(1, getWars[2]);
        }

        [Fact]
        public async Task GetWarsAsync_successfully_returns_a_listInts()
        {
            LatestWarsEndpoints internalLatestWars = new LatestWarsEndpoints(string.Empty, true);

            IList<int> getWars = await internalLatestWars.GetWarsAsync(0);

            Assert.Equal(3, getWars.Count);
            Assert.Equal(3, getWars[0]);
            Assert.Equal(2, getWars[1]);
            Assert.Equal(1, getWars[2]);
        }

        [Fact]
        public void GetIndividualWar_successfully_returns_a_V1WarsIndividualWar()
        {
            LatestWarsEndpoints internalLatestWars = new LatestWarsEndpoints(string.Empty, true);

            V1WarsIndividualWar getWar = internalLatestWars.GetIndividualWar(0);

            Assert.Equal(986665792, getWar.Aggressor.CorporationId);
            Assert.Equal(0, getWar.Aggressor.IskDestroyed);
            Assert.Equal(0, getWar.Aggressor.ShipsKilled);
            Assert.Equal(new DateTime(2004, 05, 22, 05, 20, 00), getWar.Declared);
            Assert.Equal(1001562011, getWar.Defender.CorporationId);
            Assert.Equal(0, getWar.Defender.IskDestroyed);
            Assert.Equal(0, getWar.Defender.ShipsKilled);
            Assert.Equal(1941, getWar.Id);
            Assert.False(getWar.Mutual);
            Assert.False(getWar.OpenForAllies);
        }

        [Fact]
        public async Task GetIndividualWarAsync_successfully_returns_a_V1WarsIndividualWar()
        {
            LatestWarsEndpoints internalLatestWars = new LatestWarsEndpoints(string.Empty, true);

            V1WarsIndividualWar getWar = await internalLatestWars.GetIndividualWarAsync(0);

            Assert.Equal(986665792, getWar.Aggressor.CorporationId);
            Assert.Equal(0, getWar.Aggressor.IskDestroyed);
            Assert.Equal(0, getWar.Aggressor.ShipsKilled);
            Assert.Equal(new DateTime(2004, 05, 22, 05, 20, 00), getWar.Declared);
            Assert.Equal(1001562011, getWar.Defender.CorporationId);
            Assert.Equal(0, getWar.Defender.IskDestroyed);
            Assert.Equal(0, getWar.Defender.ShipsKilled);
            Assert.Equal(1941, getWar.Id);
            Assert.False(getWar.Mutual);
            Assert.False(getWar.OpenForAllies);
        }

        [Fact]
        public void GetIndividualWarsKillmails_successfully_returns_a_listV1WarsWarKillmails()
        {
            LatestWarsEndpoints internalLatestWars = new LatestWarsEndpoints(string.Empty, true);

            IList<V1WarsWarKillmails> getWars = internalLatestWars.GetIndividualWarsKillmails(0);

            Assert.Equal(2, getWars.Count);
            Assert.Equal("8eef5e8fb6b88fe3407c489df33822b2e3b57a5e", getWars[0].KillmailHash);
            Assert.Equal(2, getWars[0].KillmailId);
            Assert.Equal("b41ccb498ece33d64019f64c0db392aa3aa701fb", getWars[1].KillmailHash);
            Assert.Equal(1, getWars[1].KillmailId);
        }

        [Fact]
        public async Task GetIndividualWarsKillmailsAsync_successfully_returns_a_listV1WarsWarKillmails()
        {
            LatestWarsEndpoints internalLatestWars = new LatestWarsEndpoints(string.Empty, true);

            IList<V1WarsWarKillmails> getWars = await internalLatestWars.GetIndividualWarsKillmailsAsync(0);

            Assert.Equal(2, getWars.Count);
            Assert.Equal("8eef5e8fb6b88fe3407c489df33822b2e3b57a5e", getWars[0].KillmailHash);
            Assert.Equal(2, getWars[0].KillmailId);
            Assert.Equal("b41ccb498ece33d64019f64c0db392aa3aa701fb", getWars[1].KillmailHash);
            Assert.Equal(1, getWars[1].KillmailId);
        }
    }
}
