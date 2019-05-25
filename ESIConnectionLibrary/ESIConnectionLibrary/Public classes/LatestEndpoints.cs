// ReSharper disable MemberCanBePrivate.Global

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

        public LatestEndpoints(string userAgent)
        {
            AuthenticationEndpoints = new AuthenticationEndpoints(userAgent);
            AllianceEndpoints = new LatestAllianceEndpoints(userAgent);
            AssetsEndpoints = new LatestAssetsEndpoints(userAgent);
            BookmarksEndpoints = new LatestBookmarksEndpoints(userAgent);
            CalendarEndpoints = new LatestCalendarEndpoints(userAgent);
            CharacterEndpoints = new LatestCharacterEndpoints(userAgent);
            CloneEndpoints = new LatestCloneEndpoints(userAgent);
            ContactsEndpoints = new LatestContactsEndpoints(userAgent);
            ContractEndpoints = new LatestContractEndpoints(userAgent);
            CorporationsEndpoints = new LatestCorporationsEndpoints(userAgent);
            DogmaEndpoints = new LatestDogmaEndpoints(userAgent);
            FactionWarfareEndpoints = new LatestFactionWarfareEndpoints(userAgent);
            FittingsEndpoints = new LatestFittingsEndpoints(userAgent);
            FleetsEndpoints = new LatestFleetsEndpoints(userAgent);
            IncursionsEndpoints = new LatestIncursionsEndpoints(userAgent);
            IndustryEndpoints = new LatestIndustryEndpoints(userAgent);
            InsuranceEndpoints = new LatestInsuranceEndpoints(userAgent);
            KillmailsEndpoints = new LatestKillmailsEndpoints(userAgent);
            LocationEndpoints = new LatestLocationEndpoints(userAgent);
            LoyaltyEndpoints = new LatestLoyaltyEndpoints(userAgent);
            MailEndpoints = new LatestMailEndpoints(userAgent);
            MarketEndpoints = new LatestMarketEndpoints(userAgent);
            OpportunitiesEndpoints = new LatestOpportunitiesEndpoints(userAgent);
            PlanetaryInteractionEndpoints = new LatestPlanetaryInteractionEndpoints(userAgent);
            RoutesEndpoints = new LatestRoutesEndpoints(userAgent);
            SearchEndpoints = new LatestSearchEndpoints(userAgent);
            SkillsEndpoints = new LatestSkillsEndpoints(userAgent);
            SovereigntyEndpoints = new LatestSovereigntyEndpoints(userAgent);
            StatusEndpoints = new LatestStatusEndpoints(userAgent);
            UiEndpoints = new LatestUiEndpoints(userAgent);
            UniverseEndpoints = new LatestUniverseEndpoints(userAgent);
            WalletEndpoints = new LatestWalletEndpoints(userAgent);
            WarsEndpoints = new LatestWarsEndpoints(userAgent);
        }
    }
}
