// ReSharper disable MemberCanBePrivate.Global

using ESIConnectionLibrary.Internal_classes;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestEndpoints : ILatestEndpoints
    {
        public IAuthenticationEndpoints AuthenticationEndpoints { get; }
        public ILatestAllianceEndpoints AllianceEndpoints { get; }
        public ILatestAssetsEndpoints AssetsEndpoints { get; }
        public ILatestBookmarksEndpoints BookmarksEndpoints { get; }
        public ILatestCalendarEndpoints CalendarEndpoints { get; }
        public ILatestCharacterEndpoints CharacterEndpoints { get; }
        public ILatestCloneEndpoints CloneEndpoints { get; }
        public ILatestContactsEndpoints ContactsEndpoints { get; }
        public ILatestContractEndpoints ContractEndpoints { get; }
        public ILatestCorporationsEndpoints CorporationsEndpoints { get; }
        public ILatestDogmaEndpoints DogmaEndpoints { get; }
        public ILatestFactionWarfareEndpoints FactionWarfareEndpoints { get; }
        public ILatestFittingsEndpoints FittingsEndpoints { get; }
        public ILatestFleetsEndpoints FleetsEndpoints { get; }
        public ILatestIncursionsEndpoints IncursionsEndpoints { get; }
        public ILatestIndustryEndpoints IndustryEndpoints { get; }
        public ILatestInsuranceEndpoints InsuranceEndpoints { get; }
        public ILatestKillmailsEndpoints KillmailsEndpoints { get; }
        public ILatestLocationEndpoints LocationEndpoints { get; }
        public ILatestLoyaltyEndpoints LoyaltyEndpoints { get; }
        public ILatestMailEndpoints MailEndpoints { get; }
        public ILatestMarketEndpoints MarketEndpoints { get; }
        public ILatestOpportunitiesEndpoints OpportunitiesEndpoints { get; }
        public ILatestPlanetaryInteractionEndpoints PlanetaryInteractionEndpoints { get; }
        public ILatestRoutesEndpoints RoutesEndpoints { get; }
        public ILatestSearchEndpoints SearchEndpoints { get; }
        public ILatestSkillsEndpoints SkillsEndpoints { get; }
        public ILatestSovereigntyEndpoints SovereigntyEndpoints { get; }
        public ILatestStatusEndpoints StatusEndpoints { get; }
        public ILatestUiEndpoints UiEndpoints { get; }
        public ILatestUniverseEndpoints UniverseEndpoints { get; }
        public ILatestWalletEndpoints WalletEndpoints { get; }
        public ILatestWarsEndpoints WarsEndpoints { get; }

        public LatestEndpoints(string userAgent, string redisConnectionString = null)
        {
            WebClient webClient = new WebClient(userAgent, redisConnectionString);

            AuthenticationEndpoints = new AuthenticationEndpoints(userAgent, webClient);
            AllianceEndpoints = new LatestAllianceEndpoints(userAgent, webClient);
            AssetsEndpoints = new LatestAssetsEndpoints(userAgent, webClient);
            BookmarksEndpoints = new LatestBookmarksEndpoints(userAgent, webClient);
            CalendarEndpoints = new LatestCalendarEndpoints(userAgent, webClient);
            CharacterEndpoints = new LatestCharacterEndpoints(userAgent, webClient);
            CloneEndpoints = new LatestCloneEndpoints(userAgent, webClient);
            ContactsEndpoints = new LatestContactsEndpoints(userAgent, webClient);
            ContractEndpoints = new LatestContractEndpoints(userAgent, webClient);
            CorporationsEndpoints = new LatestCorporationsEndpoints(userAgent, webClient);
            DogmaEndpoints = new LatestDogmaEndpoints(userAgent, webClient);
            FactionWarfareEndpoints = new LatestFactionWarfareEndpoints(userAgent, webClient);
            FittingsEndpoints = new LatestFittingsEndpoints(userAgent, webClient);
            FleetsEndpoints = new LatestFleetsEndpoints(userAgent, webClient);
            IncursionsEndpoints = new LatestIncursionsEndpoints(userAgent, webClient);
            IndustryEndpoints = new LatestIndustryEndpoints(userAgent, webClient);
            InsuranceEndpoints = new LatestInsuranceEndpoints(userAgent, webClient);
            KillmailsEndpoints = new LatestKillmailsEndpoints(userAgent, webClient);
            LocationEndpoints = new LatestLocationEndpoints(userAgent, webClient);
            LoyaltyEndpoints = new LatestLoyaltyEndpoints(userAgent, webClient);
            MailEndpoints = new LatestMailEndpoints(userAgent, webClient);
            MarketEndpoints = new LatestMarketEndpoints(userAgent, webClient);
            OpportunitiesEndpoints = new LatestOpportunitiesEndpoints(userAgent, webClient);
            PlanetaryInteractionEndpoints = new LatestPlanetaryInteractionEndpoints(userAgent, webClient);
            RoutesEndpoints = new LatestRoutesEndpoints(userAgent, webClient);
            SearchEndpoints = new LatestSearchEndpoints(userAgent, webClient);
            SkillsEndpoints = new LatestSkillsEndpoints(userAgent, webClient);
            SovereigntyEndpoints = new LatestSovereigntyEndpoints(userAgent, webClient);
            StatusEndpoints = new LatestStatusEndpoints(userAgent, webClient);
            UiEndpoints = new LatestUiEndpoints(userAgent, webClient);
            UniverseEndpoints = new LatestUniverseEndpoints(userAgent, webClient);
            WalletEndpoints = new LatestWalletEndpoints(userAgent, webClient);
            WarsEndpoints = new LatestWarsEndpoints(userAgent, webClient);
        }
    }
}
