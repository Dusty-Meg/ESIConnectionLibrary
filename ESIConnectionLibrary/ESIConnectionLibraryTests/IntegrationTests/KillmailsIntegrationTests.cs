using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class KillmailsIntegrationTests
    {
        [Fact]
        public void GetSingleKillmail_successfully_returns_a_killmail()
        {
            int killmailId = 7777;
            string killmailHash = "ssssss";

            LatestKillmailsEndpoints internalLatestKillmails = new LatestKillmailsEndpoints(string.Empty, true);

            V1GetSingleKillmail killmail = internalLatestKillmails.GetSingleKillmail(killmailId, killmailHash);

            Assert.Equal(1, killmail.Attackers.Count);
            Assert.Equal(95810944, killmail.Attackers.First().CharacterId);
            Assert.Equal(621338554, killmail.Victim.AllianceId);
            Assert.Equal(20, killmail.Victim.Items.First().Flag);
        }

        [Fact]
        public async Task GetSingleKillmailAsync_successfully_returns_a_killmail()
        {
            int killmailId = 7777;
            string killmailHash = "ssssss";

            LatestKillmailsEndpoints internalLatestKillmails = new LatestKillmailsEndpoints(string.Empty, true);

            V1GetSingleKillmail killmail = await internalLatestKillmails.GetSingleKillmailAsync(killmailId, killmailHash);

            Assert.Equal(1, killmail.Attackers.Count);
            Assert.Equal(95810944, killmail.Attackers.First().CharacterId);
            Assert.Equal(621338554, killmail.Victim.AllianceId);
            Assert.Equal(20, killmail.Victim.Items.First().Flag);
        }
    }
}
