﻿using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class KillmailsTests
    {
        [Fact]
        public void GetSingleKillmail_successfully_returns_a_killmail()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int killmailId = 7777;
            string killmailHash = "ssssss";
            string json = "{\"attackers\": [{\"character_id\": 95810944,\"corporation_id\": 1000179,\"damage_done\": 5745,\"faction_id\": 500003,\"final_blow\": true,\"security_status\": -0.3,\"ship_type_id\": 17841,\"weapon_type_id\": 3074}],\"killmail_id\": 56733821,\"killmail_time\": \"2016-10-22T17:13:36Z\",\"solar_system_id\": 30002976,\"victim\": {\"alliance_id\": 621338554,\"character_id\": 92796241,\"corporation_id\": 841363671,\"damage_taken\": 5745,\"items\": [{\"flag\": 20,\"item_type_id\": 5973,\"quantity_dropped\": 1,\"singleton\": 0}],\"position\": {\"x\": 452186600569.4748,\"y\": 146704961490.90222,\"z\": 109514596532.54477},\"ship_type_id\": 17812}}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestKillmails internalLatestKillmails = new InternalLatestKillmails(mockedWebClient.Object, string.Empty);

            V1GetSingleKillmail killmail = internalLatestKillmails.GetSingleKillmail(killmailId, killmailHash);

            Assert.Equal(1, killmail.Attackers.Count);
            Assert.Equal(95810944, killmail.Attackers.First().CharacterId);
            Assert.Equal(621338554, killmail.Victim.AllianceId);
            Assert.Equal(20, killmail.Victim.Items.First().Flag);
        }

        [Fact]
        public async Task GetSingleKillmailAsync_successfully_returns_a_killmail()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int killmailId = 7777;
            string killmailHash = "ssssss";
            string json = "{\"attackers\": [{\"character_id\": 95810944,\"corporation_id\": 1000179,\"damage_done\": 5745,\"faction_id\": 500003,\"final_blow\": true,\"security_status\": -0.3,\"ship_type_id\": 17841,\"weapon_type_id\": 3074}],\"killmail_id\": 56733821,\"killmail_time\": \"2016-10-22T17:13:36Z\",\"solar_system_id\": 30002976,\"victim\": {\"alliance_id\": 621338554,\"character_id\": 92796241,\"corporation_id\": 841363671,\"damage_taken\": 5745,\"items\": [{\"flag\": 20,\"item_type_id\": 5973,\"quantity_dropped\": 1,\"singleton\": 0}],\"position\": {\"x\": 452186600569.4748,\"y\": 146704961490.90222,\"z\": 109514596532.54477},\"ship_type_id\": 17812}}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestKillmails internalLatestKillmails = new InternalLatestKillmails(mockedWebClient.Object, string.Empty);

            V1GetSingleKillmail killmail = await internalLatestKillmails.GetSingleKillmailAsync(killmailId, killmailHash);

            Assert.Equal(1, killmail.Attackers.Count);
            Assert.Equal(95810944, killmail.Attackers.First().CharacterId);
            Assert.Equal(621338554, killmail.Victim.AllianceId);
            Assert.Equal(20, killmail.Victim.Items.First().Flag);
        }
    }
}
