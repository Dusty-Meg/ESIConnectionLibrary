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
        public void Wars_successfully_returns_a_listInts()
        {
            LatestWarsEndpoints internalLatestWars = new LatestWarsEndpoints(string.Empty, true);

            IList<int> getWars = internalLatestWars.Wars();

            Assert.Equal(3, getWars.Count);
            Assert.Equal(3, getWars[0]);
            Assert.Equal(2, getWars[1]);
            Assert.Equal(1, getWars[2]);
        }

        [Fact]
        public async Task WarsAsync_successfully_returns_a_listInts()
        {
            LatestWarsEndpoints internalLatestWars = new LatestWarsEndpoints(string.Empty, true);

            IList<int> getWars = await internalLatestWars.WarsAsync();

            Assert.Equal(3, getWars.Count);
            Assert.Equal(3, getWars[0]);
            Assert.Equal(2, getWars[1]);
            Assert.Equal(1, getWars[2]);
        }

        [Fact]
        public void War_successfully_returns_a_V1WarsWar()
        {
            LatestWarsEndpoints internalLatestWars = new LatestWarsEndpoints(string.Empty, true);

            V1WarsWar getWar = internalLatestWars.War(0);

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
        public async Task WarAsync_successfully_returns_a_V1WarsWar()
        {
            LatestWarsEndpoints internalLatestWars = new LatestWarsEndpoints(string.Empty, true);

            V1WarsWar getWar = await internalLatestWars.WarAsync(0);

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
        public void Killmails_successfully_returns_a_listV1WarsKillmail()
        {
            LatestWarsEndpoints internalLatestWars = new LatestWarsEndpoints(string.Empty, true);

            IList<V1WarsKillmail> getWars = internalLatestWars.Killmails(0);

            Assert.Equal(2, getWars.Count);
            Assert.Equal("8eef5e8fb6b88fe3407c489df33822b2e3b57a5e", getWars[0].KillmailHash);
            Assert.Equal(2, getWars[0].KillmailId);
            Assert.Equal("b41ccb498ece33d64019f64c0db392aa3aa701fb", getWars[1].KillmailHash);
            Assert.Equal(1, getWars[1].KillmailId);
        }

        [Fact]
        public async Task KillmailsAsync_successfully_returns_a_listV1WarsKillmail()
        {
            LatestWarsEndpoints internalLatestWars = new LatestWarsEndpoints(string.Empty, true);

            IList<V1WarsKillmail> getWars = await internalLatestWars.KillmailsAsync(0);

            Assert.Equal(2, getWars.Count);
            Assert.Equal("8eef5e8fb6b88fe3407c489df33822b2e3b57a5e", getWars[0].KillmailHash);
            Assert.Equal(2, getWars[0].KillmailId);
            Assert.Equal("b41ccb498ece33d64019f64c0db392aa3aa701fb", getWars[1].KillmailHash);
            Assert.Equal(1, getWars[1].KillmailId);
        }
    }
}
