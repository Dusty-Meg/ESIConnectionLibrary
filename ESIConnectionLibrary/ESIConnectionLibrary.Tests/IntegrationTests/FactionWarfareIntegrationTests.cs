using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibrary.Tests.IntegrationTests
{
    public class FactionWarfareIntegrationTests
    {
        [Fact]
        public void CharacterStats_successfully_returns_a_V1FwCharacterStats()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CharacterScopes scopes = CharacterScopes.esi_characters_read_fw_stats_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CharacterScopesFlags = scopes };

            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            V1FwCharacterStats result = internalLatestFactionWarfare.CharacterStats(inputToken);

            Assert.Equal(new DateTime(2017, 10, 17, 00, 00, 00), result.EnlistedOn);
            Assert.Equal(500001, result.FactionId);
            Assert.Equal(893, result.Kills.LastWeek);
            Assert.Equal(684350, result.Kills.Total);
            Assert.Equal(136, result.Kills.Yesterday);
            Assert.Equal(102640, result.VictoryPoints.LastWeek);
            Assert.Equal(52658260, result.VictoryPoints.Total);
            Assert.Equal(15980, result.VictoryPoints.Yesterday);
        }

        [Fact]
        public async Task CharacterStatsAsync_successfully_returns_a_V1FwCharacterStats()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CharacterScopes scopes = CharacterScopes.esi_characters_read_fw_stats_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CharacterScopesFlags = scopes };

            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            V1FwCharacterStats result = await internalLatestFactionWarfare.CharacterStatsAsync(inputToken);

            Assert.Equal(new DateTime(2017, 10, 17, 00, 00, 00), result.EnlistedOn);
            Assert.Equal(500001, result.FactionId);
            Assert.Equal(893, result.Kills.LastWeek);
            Assert.Equal(684350, result.Kills.Total);
            Assert.Equal(136, result.Kills.Yesterday);
            Assert.Equal(102640, result.VictoryPoints.LastWeek);
            Assert.Equal(52658260, result.VictoryPoints.Total);
            Assert.Equal(15980, result.VictoryPoints.Yesterday);
        }

        [Fact]
        public void CorporationStats_successfully_returns_a_V1FwCorporationStats()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_fw_stats_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            V1FwCorporationStats result = internalLatestFactionWarfare.CorporationStats(inputToken, 33);

            Assert.Equal(new DateTime(2017, 10, 17, 00, 00, 00), result.EnlistedOn);
            Assert.Equal(500001, result.FactionId);
            Assert.Equal(893, result.Kills.LastWeek);
            Assert.Equal(684350, result.Kills.Total);
            Assert.Equal(136, result.Kills.Yesterday);
            Assert.Equal(28863, result.Pilots);
            Assert.Equal(102640, result.VictoryPoints.LastWeek);
            Assert.Equal(52658260, result.VictoryPoints.Total);
            Assert.Equal(15980, result.VictoryPoints.Yesterday);
        }

        [Fact]
        public async Task CorporationStatsAsync_successfully_returns_a_V1FwCorporationStats()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_fw_stats_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            V1FwCorporationStats result = await internalLatestFactionWarfare.CorporationStatsAsync(inputToken, 33);

            Assert.Equal(new DateTime(2017, 10, 17, 00, 00, 00), result.EnlistedOn);
            Assert.Equal(500001, result.FactionId);
            Assert.Equal(893, result.Kills.LastWeek);
            Assert.Equal(684350, result.Kills.Total);
            Assert.Equal(136, result.Kills.Yesterday);
            Assert.Equal(28863, result.Pilots);
            Assert.Equal(102640, result.VictoryPoints.LastWeek);
            Assert.Equal(52658260, result.VictoryPoints.Total);
            Assert.Equal(15980, result.VictoryPoints.Yesterday);
        }

        [Fact]
        public void FactionLeaderboard_successfully_returns_a_V1FwFactionLeaderboard()
        {
            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            V1FwFactionLeaderboard result = internalLatestFactionWarfare.FactionLeaderboard();

            Assert.Equal(2, result.Kills.ActiveTotal.Count);
            Assert.Equal(832273, result.Kills.ActiveTotal[0].Amount);
            Assert.Equal(500004, result.Kills.ActiveTotal[0].FactionId);
            Assert.Equal(687915, result.Kills.ActiveTotal[1].Amount);
            Assert.Equal(500001, result.Kills.ActiveTotal[1].FactionId);

            Assert.Equal(2, result.Kills.LastWeek.Count);
            Assert.Equal(730, result.Kills.LastWeek[0].Amount);
            Assert.Equal(500001, result.Kills.LastWeek[0].FactionId);
            Assert.Equal(671, result.Kills.LastWeek[1].Amount);
            Assert.Equal(500004, result.Kills.LastWeek[1].FactionId);

            Assert.Equal(2, result.Kills.Yesterday.Count);
            Assert.Equal(100, result.Kills.Yesterday[0].Amount);
            Assert.Equal(500001, result.Kills.Yesterday[0].FactionId);
            Assert.Equal(50, result.Kills.Yesterday[1].Amount);
            Assert.Equal(500004, result.Kills.Yesterday[1].FactionId);

            Assert.Equal(2, result.VictoryPoints.ActiveTotal.Count);
            Assert.Equal(53130500, result.VictoryPoints.ActiveTotal[0].Amount);
            Assert.Equal(500001, result.VictoryPoints.ActiveTotal[0].FactionId);
            Assert.Equal(50964263, result.VictoryPoints.ActiveTotal[1].Amount);
            Assert.Equal(500004, result.VictoryPoints.ActiveTotal[1].FactionId);

            Assert.Equal(2, result.VictoryPoints.LastWeek.Count);
            Assert.Equal(97360, result.VictoryPoints.LastWeek[0].Amount);
            Assert.Equal(500001, result.VictoryPoints.LastWeek[0].FactionId);
            Assert.Equal(84980, result.VictoryPoints.LastWeek[1].Amount);
            Assert.Equal(500004, result.VictoryPoints.LastWeek[1].FactionId);

            Assert.Equal(2, result.VictoryPoints.Yesterday.Count);
            Assert.Equal(5000, result.VictoryPoints.Yesterday[0].Amount);
            Assert.Equal(500002, result.VictoryPoints.Yesterday[0].FactionId);
            Assert.Equal(3500, result.VictoryPoints.Yesterday[1].Amount);
            Assert.Equal(500003, result.VictoryPoints.Yesterday[1].FactionId);
        }

        [Fact]
        public async Task FactionLeaderboardAsync_successfully_returns_a_V1FwFactionLeaderboard()
        {
            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            V1FwFactionLeaderboard result = await internalLatestFactionWarfare.FactionLeaderboardAsync();

            Assert.Equal(2, result.Kills.ActiveTotal.Count);
            Assert.Equal(832273, result.Kills.ActiveTotal[0].Amount);
            Assert.Equal(500004, result.Kills.ActiveTotal[0].FactionId);
            Assert.Equal(687915, result.Kills.ActiveTotal[1].Amount);
            Assert.Equal(500001, result.Kills.ActiveTotal[1].FactionId);

            Assert.Equal(2, result.Kills.LastWeek.Count);
            Assert.Equal(730, result.Kills.LastWeek[0].Amount);
            Assert.Equal(500001, result.Kills.LastWeek[0].FactionId);
            Assert.Equal(671, result.Kills.LastWeek[1].Amount);
            Assert.Equal(500004, result.Kills.LastWeek[1].FactionId);

            Assert.Equal(2, result.Kills.Yesterday.Count);
            Assert.Equal(100, result.Kills.Yesterday[0].Amount);
            Assert.Equal(500001, result.Kills.Yesterday[0].FactionId);
            Assert.Equal(50, result.Kills.Yesterday[1].Amount);
            Assert.Equal(500004, result.Kills.Yesterday[1].FactionId);

            Assert.Equal(2, result.VictoryPoints.ActiveTotal.Count);
            Assert.Equal(53130500, result.VictoryPoints.ActiveTotal[0].Amount);
            Assert.Equal(500001, result.VictoryPoints.ActiveTotal[0].FactionId);
            Assert.Equal(50964263, result.VictoryPoints.ActiveTotal[1].Amount);
            Assert.Equal(500004, result.VictoryPoints.ActiveTotal[1].FactionId);

            Assert.Equal(2, result.VictoryPoints.LastWeek.Count);
            Assert.Equal(97360, result.VictoryPoints.LastWeek[0].Amount);
            Assert.Equal(500001, result.VictoryPoints.LastWeek[0].FactionId);
            Assert.Equal(84980, result.VictoryPoints.LastWeek[1].Amount);
            Assert.Equal(500004, result.VictoryPoints.LastWeek[1].FactionId);

            Assert.Equal(2, result.VictoryPoints.Yesterday.Count);
            Assert.Equal(5000, result.VictoryPoints.Yesterday[0].Amount);
            Assert.Equal(500002, result.VictoryPoints.Yesterday[0].FactionId);
            Assert.Equal(3500, result.VictoryPoints.Yesterday[1].Amount);
            Assert.Equal(500003, result.VictoryPoints.Yesterday[1].FactionId);
        }

        [Fact]
        public void CharacterLeaderboard_successfully_returns_a_V1FwCharacterLeaderboard()
        {
            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            V1FwCharacterLeaderboard result = internalLatestFactionWarfare.CharacterLeaderboard();

            Assert.Equal(2, result.Kills.ActiveTotal.Count);
            Assert.Equal(10000, result.Kills.ActiveTotal[0].Amount);
            Assert.Equal(2112625428, result.Kills.ActiveTotal[0].CharacterId);
            Assert.Equal(8500, result.Kills.ActiveTotal[1].Amount);
            Assert.Equal(95465499, result.Kills.ActiveTotal[1].CharacterId);

            Assert.Equal(2, result.Kills.LastWeek.Count);
            Assert.Equal(100, result.Kills.LastWeek[0].Amount);
            Assert.Equal(2112625428, result.Kills.LastWeek[0].CharacterId);
            Assert.Equal(70, result.Kills.LastWeek[1].Amount);
            Assert.Equal(95465499, result.Kills.LastWeek[1].CharacterId);

            Assert.Equal(2, result.Kills.Yesterday.Count);
            Assert.Equal(34, result.Kills.Yesterday[0].Amount);
            Assert.Equal(2112625428, result.Kills.Yesterday[0].CharacterId);
            Assert.Equal(20, result.Kills.Yesterday[1].Amount);
            Assert.Equal(95465499, result.Kills.Yesterday[1].CharacterId);

            Assert.Equal(2, result.VictoryPoints.ActiveTotal.Count);
            Assert.Equal(1239158, result.VictoryPoints.ActiveTotal[0].Amount);
            Assert.Equal(2112625428, result.VictoryPoints.ActiveTotal[0].CharacterId);
            Assert.Equal(1139029, result.VictoryPoints.ActiveTotal[1].Amount);
            Assert.Equal(95465499, result.VictoryPoints.ActiveTotal[1].CharacterId);

            Assert.Equal(2, result.VictoryPoints.LastWeek.Count);
            Assert.Equal(2660, result.VictoryPoints.LastWeek[0].Amount);
            Assert.Equal(2112625428, result.VictoryPoints.LastWeek[0].CharacterId);
            Assert.Equal(2000, result.VictoryPoints.LastWeek[1].Amount);
            Assert.Equal(95465499, result.VictoryPoints.LastWeek[1].CharacterId);

            Assert.Equal(2, result.VictoryPoints.Yesterday.Count);
            Assert.Equal(620, result.VictoryPoints.Yesterday[0].Amount);
            Assert.Equal(2112625428, result.VictoryPoints.Yesterday[0].CharacterId);
            Assert.Equal(550, result.VictoryPoints.Yesterday[1].Amount);
            Assert.Equal(95465499, result.VictoryPoints.Yesterday[1].CharacterId);
        }

        [Fact]
        public async Task CharacterLeaderboardAsync_successfully_returns_a_V1FwCharacterLeaderboard()
        {
            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            V1FwCharacterLeaderboard result = await internalLatestFactionWarfare.CharacterLeaderboardAsync();

            Assert.Equal(2, result.Kills.ActiveTotal.Count);
            Assert.Equal(10000, result.Kills.ActiveTotal[0].Amount);
            Assert.Equal(2112625428, result.Kills.ActiveTotal[0].CharacterId);
            Assert.Equal(8500, result.Kills.ActiveTotal[1].Amount);
            Assert.Equal(95465499, result.Kills.ActiveTotal[1].CharacterId);

            Assert.Equal(2, result.Kills.LastWeek.Count);
            Assert.Equal(100, result.Kills.LastWeek[0].Amount);
            Assert.Equal(2112625428, result.Kills.LastWeek[0].CharacterId);
            Assert.Equal(70, result.Kills.LastWeek[1].Amount);
            Assert.Equal(95465499, result.Kills.LastWeek[1].CharacterId);

            Assert.Equal(2, result.Kills.Yesterday.Count);
            Assert.Equal(34, result.Kills.Yesterday[0].Amount);
            Assert.Equal(2112625428, result.Kills.Yesterday[0].CharacterId);
            Assert.Equal(20, result.Kills.Yesterday[1].Amount);
            Assert.Equal(95465499, result.Kills.Yesterday[1].CharacterId);

            Assert.Equal(2, result.VictoryPoints.ActiveTotal.Count);
            Assert.Equal(1239158, result.VictoryPoints.ActiveTotal[0].Amount);
            Assert.Equal(2112625428, result.VictoryPoints.ActiveTotal[0].CharacterId);
            Assert.Equal(1139029, result.VictoryPoints.ActiveTotal[1].Amount);
            Assert.Equal(95465499, result.VictoryPoints.ActiveTotal[1].CharacterId);

            Assert.Equal(2, result.VictoryPoints.LastWeek.Count);
            Assert.Equal(2660, result.VictoryPoints.LastWeek[0].Amount);
            Assert.Equal(2112625428, result.VictoryPoints.LastWeek[0].CharacterId);
            Assert.Equal(2000, result.VictoryPoints.LastWeek[1].Amount);
            Assert.Equal(95465499, result.VictoryPoints.LastWeek[1].CharacterId);

            Assert.Equal(2, result.VictoryPoints.Yesterday.Count);
            Assert.Equal(620, result.VictoryPoints.Yesterday[0].Amount);
            Assert.Equal(2112625428, result.VictoryPoints.Yesterday[0].CharacterId);
            Assert.Equal(550, result.VictoryPoints.Yesterday[1].Amount);
            Assert.Equal(95465499, result.VictoryPoints.Yesterday[1].CharacterId);
        }

        [Fact]
        public void CorporationLeaderboard_successfully_returns_a_V1FwCorporationLeaderboard()
        {
            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            V1FwCorporationLeaderboard result = internalLatestFactionWarfare.CorporationLeaderboard();

            Assert.Equal(2, result.Kills.ActiveTotal.Count);
            Assert.Equal(81692, result.Kills.ActiveTotal[0].Amount);
            Assert.Equal(1000180, result.Kills.ActiveTotal[0].CorporationId);
            Assert.Equal(76793, result.Kills.ActiveTotal[1].Amount);
            Assert.Equal(1000182, result.Kills.ActiveTotal[1].CorporationId);

            Assert.Equal(2, result.Kills.LastWeek.Count);
            Assert.Equal(290, result.Kills.LastWeek[0].Amount);
            Assert.Equal(1000180, result.Kills.LastWeek[0].CorporationId);
            Assert.Equal(169, result.Kills.LastWeek[1].Amount);
            Assert.Equal(1000182, result.Kills.LastWeek[1].CorporationId);

            Assert.Equal(2, result.Kills.Yesterday.Count);
            Assert.Equal(51, result.Kills.Yesterday[0].Amount);
            Assert.Equal(1000180, result.Kills.Yesterday[0].CorporationId);
            Assert.Equal(39, result.Kills.Yesterday[1].Amount);
            Assert.Equal(1000182, result.Kills.Yesterday[1].CorporationId);

            Assert.Equal(2, result.VictoryPoints.ActiveTotal.Count);
            Assert.Equal(18640927, result.VictoryPoints.ActiveTotal[0].Amount);
            Assert.Equal(1000180, result.VictoryPoints.ActiveTotal[0].CorporationId);
            Assert.Equal(18078265, result.VictoryPoints.ActiveTotal[1].Amount);
            Assert.Equal(1000181, result.VictoryPoints.ActiveTotal[1].CorporationId);

            Assert.Equal(2, result.VictoryPoints.LastWeek.Count);
            Assert.Equal(91980, result.VictoryPoints.LastWeek[0].Amount);
            Assert.Equal(1000180, result.VictoryPoints.LastWeek[0].CorporationId);
            Assert.Equal(58920, result.VictoryPoints.LastWeek[1].Amount);
            Assert.Equal(1000181, result.VictoryPoints.LastWeek[1].CorporationId);

            Assert.Equal(2, result.VictoryPoints.Yesterday.Count);
            Assert.Equal(12600, result.VictoryPoints.Yesterday[0].Amount);
            Assert.Equal(1000180, result.VictoryPoints.Yesterday[0].CorporationId);
            Assert.Equal(8240, result.VictoryPoints.Yesterday[1].Amount);
            Assert.Equal(1000181, result.VictoryPoints.Yesterday[1].CorporationId);
        }

        [Fact]
        public async Task CorporationLeaderboardAsync_successfully_returns_a_V1FwCorporationLeaderboard()
        {
            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            V1FwCorporationLeaderboard result = await internalLatestFactionWarfare.CorporationLeaderboardAsync();

            Assert.Equal(2, result.Kills.ActiveTotal.Count);
            Assert.Equal(81692, result.Kills.ActiveTotal[0].Amount);
            Assert.Equal(1000180, result.Kills.ActiveTotal[0].CorporationId);
            Assert.Equal(76793, result.Kills.ActiveTotal[1].Amount);
            Assert.Equal(1000182, result.Kills.ActiveTotal[1].CorporationId);

            Assert.Equal(2, result.Kills.LastWeek.Count);
            Assert.Equal(290, result.Kills.LastWeek[0].Amount);
            Assert.Equal(1000180, result.Kills.LastWeek[0].CorporationId);
            Assert.Equal(169, result.Kills.LastWeek[1].Amount);
            Assert.Equal(1000182, result.Kills.LastWeek[1].CorporationId);

            Assert.Equal(2, result.Kills.Yesterday.Count);
            Assert.Equal(51, result.Kills.Yesterday[0].Amount);
            Assert.Equal(1000180, result.Kills.Yesterday[0].CorporationId);
            Assert.Equal(39, result.Kills.Yesterday[1].Amount);
            Assert.Equal(1000182, result.Kills.Yesterday[1].CorporationId);

            Assert.Equal(2, result.VictoryPoints.ActiveTotal.Count);
            Assert.Equal(18640927, result.VictoryPoints.ActiveTotal[0].Amount);
            Assert.Equal(1000180, result.VictoryPoints.ActiveTotal[0].CorporationId);
            Assert.Equal(18078265, result.VictoryPoints.ActiveTotal[1].Amount);
            Assert.Equal(1000181, result.VictoryPoints.ActiveTotal[1].CorporationId);

            Assert.Equal(2, result.VictoryPoints.LastWeek.Count);
            Assert.Equal(91980, result.VictoryPoints.LastWeek[0].Amount);
            Assert.Equal(1000180, result.VictoryPoints.LastWeek[0].CorporationId);
            Assert.Equal(58920, result.VictoryPoints.LastWeek[1].Amount);
            Assert.Equal(1000181, result.VictoryPoints.LastWeek[1].CorporationId);

            Assert.Equal(2, result.VictoryPoints.Yesterday.Count);
            Assert.Equal(12600, result.VictoryPoints.Yesterday[0].Amount);
            Assert.Equal(1000180, result.VictoryPoints.Yesterday[0].CorporationId);
            Assert.Equal(8240, result.VictoryPoints.Yesterday[1].Amount);
            Assert.Equal(1000181, result.VictoryPoints.Yesterday[1].CorporationId);
        }

        [Fact]
        public void FactionStats_successfully_returns_a_list_of_V1FwFactionStats()
        {
            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            IList<V1FwFactionStats> result = internalLatestFactionWarfare.FactionStats();

            Assert.Equal(500001, result[0].FactionId);
            Assert.Equal(893, result[0].Kills.LastWeek);
            Assert.Equal(684350, result[0].Kills.Total);
            Assert.Equal(136, result[0].Kills.Yesterday);
            Assert.Equal(28863, result[0].Pilots);
            Assert.Equal(20, result[0].SystemsControlled);
            Assert.Equal(102640, result[0].VictoryPoints.LastWeek);
            Assert.Equal(52658260, result[0].VictoryPoints.Total);
            Assert.Equal(15980, result[0].VictoryPoints.Yesterday);
        }

        [Fact]
        public async Task FactionStatsAsync_successfully_returns_a_list_of_V1FwFactionStats()
        {
            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            IList<V1FwFactionStats> result = await internalLatestFactionWarfare.FactionStatsAsync();

            Assert.Equal(500001, result[0].FactionId);
            Assert.Equal(893, result[0].Kills.LastWeek);
            Assert.Equal(684350, result[0].Kills.Total);
            Assert.Equal(136, result[0].Kills.Yesterday);
            Assert.Equal(28863, result[0].Pilots);
            Assert.Equal(20, result[0].SystemsControlled);
            Assert.Equal(102640, result[0].VictoryPoints.LastWeek);
            Assert.Equal(52658260, result[0].VictoryPoints.Total);
            Assert.Equal(15980, result[0].VictoryPoints.Yesterday);
        }

        [Fact]
        public void Systems_successfully_returns_a_list_of_V2FwSystems()
        {
            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            IList<V2FwSystems> result = internalLatestFactionWarfare.Systems();

            Assert.Equal(V2FwSystemsContested.Uncontested, result[0].Contested);
            Assert.Equal(500001, result[0].OccupierFactionId);
            Assert.Equal(500001, result[0].OwnerFactionId);
            Assert.Equal(30002096, result[0].SolarSystemId);
            Assert.Equal(60, result[0].VictoryPoints);
            Assert.Equal(3000, result[0].VictoryPointsThreshold);
        }

        [Fact]
        public async Task SystemsAsync_successfully_returns_a_list_of_V2FwSystems()
        {
            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            IList<V2FwSystems> result = await internalLatestFactionWarfare.SystemsAsync();

            Assert.Equal(V2FwSystemsContested.Uncontested, result[0].Contested);
            Assert.Equal(500001, result[0].OccupierFactionId);
            Assert.Equal(500001, result[0].OwnerFactionId);
            Assert.Equal(30002096, result[0].SolarSystemId);
            Assert.Equal(60, result[0].VictoryPoints);
            Assert.Equal(3000, result[0].VictoryPointsThreshold);
        }

        [Fact]
        public void Wars_successfully_returns_a_list_of_V1FwWars()
        {
            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            IList<V1FwWars> result = internalLatestFactionWarfare.Wars();

            Assert.Equal(500002, result[0].AgainstId);
            Assert.Equal(500001, result[0].FactionId);
        }

        [Fact]
        public async Task WarsAsync_successfully_returns_a_list_of_V1FwWars()
        {
            LatestFactionWarfareEndpoints internalLatestFactionWarfare = new LatestFactionWarfareEndpoints(string.Empty, true);

            IList<V1FwWars> result = await internalLatestFactionWarfare.WarsAsync();

            Assert.Equal(500002, result[0].AgainstId);
            Assert.Equal(500001, result[0].FactionId);
        }
    }
}
