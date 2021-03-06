﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class WarsTests
    {
        [Fact]
        public void Wars_successfully_returns_a_listInts()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  3,\r\n  2,\r\n  1\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestWars internalLatestWars = new InternalLatestWars(mockedWebClient.Object, string.Empty);

            IList<int> getWars = internalLatestWars.Wars(0);

            Assert.Equal(3, getWars.Count);
            Assert.Equal(3, getWars[0]);
            Assert.Equal(2, getWars[1]);
            Assert.Equal(1, getWars[2]);
        }

        [Fact]
        public async Task WarsAsync_successfully_returns_a_listInts()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  3,\r\n  2,\r\n  1\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestWars internalLatestWars = new InternalLatestWars(mockedWebClient.Object, string.Empty);

            IList<int> getWars = await internalLatestWars.WarsAsync(0);

            Assert.Equal(3, getWars.Count);
            Assert.Equal(3, getWars[0]);
            Assert.Equal(2, getWars[1]);
            Assert.Equal(1, getWars[2]);
        }

        [Fact]
        public void War_successfully_returns_a_V1WarsWar()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"aggressor\": {\r\n    \"corporation_id\": 986665792,\r\n    \"isk_destroyed\": 0,\r\n    \"ships_killed\": 0\r\n  },\r\n  \"declared\": \"2004-05-22T05:20:00Z\",\r\n  \"defender\": {\r\n    \"corporation_id\": 1001562011,\r\n    \"isk_destroyed\": 0,\r\n    \"ships_killed\": 0\r\n  },\r\n  \"id\": 1941,\r\n  \"mutual\": false,\r\n  \"open_for_allies\": false\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestWars internalLatestWars = new InternalLatestWars(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"aggressor\": {\r\n    \"corporation_id\": 986665792,\r\n    \"isk_destroyed\": 0,\r\n    \"ships_killed\": 0\r\n  },\r\n  \"declared\": \"2004-05-22T05:20:00Z\",\r\n  \"defender\": {\r\n    \"corporation_id\": 1001562011,\r\n    \"isk_destroyed\": 0,\r\n    \"ships_killed\": 0\r\n  },\r\n  \"id\": 1941,\r\n  \"mutual\": false,\r\n  \"open_for_allies\": false\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestWars internalLatestWars = new InternalLatestWars(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"killmail_hash\": \"8eef5e8fb6b88fe3407c489df33822b2e3b57a5e\",\r\n    \"killmail_id\": 2\r\n  },\r\n  {\r\n    \"killmail_hash\": \"b41ccb498ece33d64019f64c0db392aa3aa701fb\",\r\n    \"killmail_id\": 1\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestWars internalLatestWars = new InternalLatestWars(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"killmail_hash\": \"8eef5e8fb6b88fe3407c489df33822b2e3b57a5e\",\r\n    \"killmail_id\": 2\r\n  },\r\n  {\r\n    \"killmail_hash\": \"b41ccb498ece33d64019f64c0db392aa3aa701fb\",\r\n    \"killmail_id\": 1\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestWars internalLatestWars = new InternalLatestWars(mockedWebClient.Object, string.Empty);

            IList<V1WarsKillmail> getWars = await internalLatestWars.KillmailsAsync(0);

            Assert.Equal(2, getWars.Count);
            Assert.Equal("8eef5e8fb6b88fe3407c489df33822b2e3b57a5e", getWars[0].KillmailHash);
            Assert.Equal(2, getWars[0].KillmailId);
            Assert.Equal("b41ccb498ece33d64019f64c0db392aa3aa701fb", getWars[1].KillmailHash);
            Assert.Equal(1, getWars[1].KillmailId);
        }
    }
}
