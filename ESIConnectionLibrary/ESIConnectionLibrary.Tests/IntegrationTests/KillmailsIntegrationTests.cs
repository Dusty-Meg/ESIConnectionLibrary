﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibrary.Tests.IntegrationTests
{
    public class KillmailsIntegrationTests
    {
        [Fact]
        public void Character_successfully_returns_a_listV1KillmailCharacter()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            KillmailScopes scopes = KillmailScopes.esi_killmails_read_killmails_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, KillmailScopesFlags = scopes };

            LatestKillmailsEndpoints internalLatestKillmails = new LatestKillmailsEndpoints(string.Empty, true);

            IList<V1KillmailCharacter> returnModel = internalLatestKillmails.Character(inputToken, 1);

            Assert.Equal(2, returnModel.Count);

            Assert.Equal("8eef5e8fb6b88fe3407c489df33822b2e3b57a5e", returnModel[0].KillmailHash);
            Assert.Equal(2, returnModel[0].KillmailId);

            Assert.Equal("b41ccb498ece33d64019f64c0db392aa3aa701fb", returnModel[1].KillmailHash);
            Assert.Equal(1, returnModel[1].KillmailId);
        }

        [Fact]
        public async Task CharacterAsync_successfully_returns_a_listV1KillmailCharacter()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            KillmailScopes scopes = KillmailScopes.esi_killmails_read_killmails_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, KillmailScopesFlags = scopes };

            LatestKillmailsEndpoints internalLatestKillmails = new LatestKillmailsEndpoints(string.Empty, true);

            IList<V1KillmailCharacter> returnModel = await internalLatestKillmails.CharacterAsync(inputToken, 1);

            Assert.Equal(2, returnModel.Count);

            Assert.Equal("8eef5e8fb6b88fe3407c489df33822b2e3b57a5e", returnModel[0].KillmailHash);
            Assert.Equal(2, returnModel[0].KillmailId);

            Assert.Equal("b41ccb498ece33d64019f64c0db392aa3aa701fb", returnModel[1].KillmailHash);
            Assert.Equal(1, returnModel[1].KillmailId);
        }

        [Fact]
        public void Corporation_successfully_returns_a_listV1KillmailCorporation()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            KillmailScopes scopes = KillmailScopes.esi_killmails_read_corporation_killmails_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, KillmailScopesFlags = scopes };

            LatestKillmailsEndpoints internalLatestKillmails = new LatestKillmailsEndpoints(string.Empty, true);

            IList<V1KillmailCorporation> returnModel = internalLatestKillmails.Corporation(inputToken, 2, 1);

            Assert.Equal(2, returnModel.Count);

            Assert.Equal("8eef5e8fb6b88fe3407c489df33822b2e3b57a5e", returnModel[0].KillmailHash);
            Assert.Equal(2, returnModel[0].KillmailId);

            Assert.Equal("b41ccb498ece33d64019f64c0db392aa3aa701fb", returnModel[1].KillmailHash);
            Assert.Equal(1, returnModel[1].KillmailId);
        }

        [Fact]
        public async Task CorporationAsync_successfully_returns_a_listV1KillmailCorporation()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            KillmailScopes scopes = KillmailScopes.esi_killmails_read_corporation_killmails_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, KillmailScopesFlags = scopes };

            LatestKillmailsEndpoints internalLatestKillmails = new LatestKillmailsEndpoints(string.Empty, true);

            IList<V1KillmailCorporation> returnModel = await internalLatestKillmails.CorporationAsync(inputToken, 2, 1);

            Assert.Equal(2, returnModel.Count);

            Assert.Equal("8eef5e8fb6b88fe3407c489df33822b2e3b57a5e", returnModel[0].KillmailHash);
            Assert.Equal(2, returnModel[0].KillmailId);

            Assert.Equal("b41ccb498ece33d64019f64c0db392aa3aa701fb", returnModel[1].KillmailHash);
            Assert.Equal(1, returnModel[1].KillmailId);
        }

        [Fact]
        public void Killmail_successfully_returns_a_V1KillmailKillmail()
        {
            int killmailId = 7777;
            string killmailHash = "ssssss";

            LatestKillmailsEndpoints internalLatestKillmails = new LatestKillmailsEndpoints(string.Empty, true);

            V1KillmailKillmail returnModel = internalLatestKillmails.Killmail(killmailId, killmailHash);

            Assert.Single(returnModel.Attackers);

            Assert.Equal(95810944, returnModel.Attackers[0].CharacterId);
            Assert.Equal(1000179, returnModel.Attackers[0].CorporationId);
            Assert.Equal(5745, returnModel.Attackers[0].DamageDone);
            Assert.Equal(500003, returnModel.Attackers[0].FactionId);
            Assert.True(returnModel.Attackers[0].FinalBlow);
            Assert.Equal(-0.3f, returnModel.Attackers[0].SecurityStatus);
            Assert.Equal(17841, returnModel.Attackers[0].ShipTypeId);
            Assert.Equal(3074, returnModel.Attackers[0].WeaponTypeId);

            Assert.Equal(56733821, returnModel.KillmailId);
            Assert.Equal(new DateTime(2016, 10, 22, 17, 13, 36), returnModel.KillmailTime);
            Assert.Equal(30002976, returnModel.SolarSystemId);

            Assert.Equal(621338554, returnModel.Victim.AllianceId);
            Assert.Equal(92796241, returnModel.Victim.CharacterId);
            Assert.Equal(841363671, returnModel.Victim.CorporationId);
            Assert.Equal(5745, returnModel.Victim.DamageTaken);

            Assert.Single(returnModel.Victim.Items);

            Assert.Equal(20, returnModel.Victim.Items[0].Flag);
            Assert.Equal(5973, returnModel.Victim.Items[0].ItemTypeId);
            Assert.Equal(1, returnModel.Victim.Items[0].QuantityDropped);
            Assert.Equal(0, returnModel.Victim.Items[0].Singleton);

            Assert.Equal(452186600569.4748f, returnModel.Victim.Position.X);
            Assert.Equal(146704961490.90222f, returnModel.Victim.Position.Y);
            Assert.Equal(109514596532.54477f, returnModel.Victim.Position.Z);

            Assert.Equal(17812, returnModel.Victim.ShipTypeId);
        }

        [Fact]
        public async Task KillmailAsync_successfully_returns_a_V1KillmailKillmail()
        {
            int killmailId = 7777;
            string killmailHash = "ssssss";

            LatestKillmailsEndpoints internalLatestKillmails = new LatestKillmailsEndpoints(string.Empty, true);

            V1KillmailKillmail returnModel = await internalLatestKillmails.KillmailAsync(killmailId, killmailHash);

            Assert.Single(returnModel.Attackers);

            Assert.Equal(95810944, returnModel.Attackers[0].CharacterId);
            Assert.Equal(1000179, returnModel.Attackers[0].CorporationId);
            Assert.Equal(5745, returnModel.Attackers[0].DamageDone);
            Assert.Equal(500003, returnModel.Attackers[0].FactionId);
            Assert.True(returnModel.Attackers[0].FinalBlow);
            Assert.Equal(-0.3f, returnModel.Attackers[0].SecurityStatus);
            Assert.Equal(17841, returnModel.Attackers[0].ShipTypeId);
            Assert.Equal(3074, returnModel.Attackers[0].WeaponTypeId);

            Assert.Equal(56733821, returnModel.KillmailId);
            Assert.Equal(new DateTime(2016, 10, 22, 17, 13, 36), returnModel.KillmailTime);
            Assert.Equal(30002976, returnModel.SolarSystemId);

            Assert.Equal(621338554, returnModel.Victim.AllianceId);
            Assert.Equal(92796241, returnModel.Victim.CharacterId);
            Assert.Equal(841363671, returnModel.Victim.CorporationId);
            Assert.Equal(5745, returnModel.Victim.DamageTaken);

            Assert.Single(returnModel.Victim.Items);

            Assert.Equal(20, returnModel.Victim.Items[0].Flag);
            Assert.Equal(5973, returnModel.Victim.Items[0].ItemTypeId);
            Assert.Equal(1, returnModel.Victim.Items[0].QuantityDropped);
            Assert.Equal(0, returnModel.Victim.Items[0].Singleton);

            Assert.Equal(452186600569.4748f, returnModel.Victim.Position.X);
            Assert.Equal(146704961490.90222f, returnModel.Victim.Position.Y);
            Assert.Equal(109514596532.54477f, returnModel.Victim.Position.Z);

            Assert.Equal(17812, returnModel.Victim.ShipTypeId);
        }
    }
}
