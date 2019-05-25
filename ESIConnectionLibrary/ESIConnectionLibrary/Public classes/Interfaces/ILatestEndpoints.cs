namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestEndpoints
    {
        IAuthenticationEndpoints AuthenticationEndpoints { get; }
        ILatestAllianceEndpoints AllianceEndpoints { get; }
        ILatestAssetsEndpoints AssetsEndpoints { get; }
        ILatestBookmarksEndpoints BookmarksEndpoints { get; }
        ILatestCalendarEndpoints CalendarEndpoints { get; }
        ILatestCharacterEndpoints CharacterEndpoints { get; }
        ILatestCloneEndpoints CloneEndpoints { get; }
        ILatestContactsEndpoints ContactsEndpoints { get; }
        ILatestContractEndpoints ContractEndpoints { get; }
        ILatestCorporationsEndpoints CorporationsEndpoints { get; }
        ILatestDogmaEndpoints DogmaEndpoints { get; }
        ILatestFactionWarfareEndpoints FactionWarfareEndpoints { get; }
        ILatestFittingsEndpoints FittingsEndpoints { get; }
        ILatestFleetsEndpoints FleetsEndpoints { get; }
        ILatestIncursionsEndpoints IncursionsEndpoints { get; }
        ILatestIndustryEndpoints IndustryEndpoints { get; }
        ILatestInsuranceEndpoints InsuranceEndpoints { get; }
        ILatestKillmailsEndpoints KillmailsEndpoints { get; }
        ILatestLocationEndpoints LocationEndpoints { get; }
        ILatestLoyaltyEndpoints LoyaltyEndpoints { get; }
        ILatestMailEndpoints MailEndpoints { get; }
        ILatestMarketEndpoints MarketEndpoints { get; }
        ILatestOpportunitiesEndpoints OpportunitiesEndpoints { get; }
        ILatestPlanetaryInteractionEndpoints PlanetaryInteractionEndpoints { get; }
        ILatestRoutesEndpoints RoutesEndpoints { get; }
        ILatestSearchEndpoints SearchEndpoints { get; }
        ILatestSkillsEndpoints SkillsEndpoints { get; }
        ILatestSovereigntyEndpoints SovereigntyEndpoints { get; }
        ILatestStatusEndpoints StatusEndpoints { get; }
        ILatestUiEndpoints UiEndpoints { get; }
        ILatestUniverseEndpoints UniverseEndpoints { get; }
        ILatestWalletEndpoints WalletEndpoints { get; }
        ILatestWarsEndpoints WarsEndpoints { get; }
    }
}