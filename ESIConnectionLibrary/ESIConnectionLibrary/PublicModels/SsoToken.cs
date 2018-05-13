using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class SsoToken
    {
        public Guid UserId { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string RefreshToken { get; set; }

        public long CharacterId { get; set; }
        public string CharacterName { get; set; }
        public TokenType TokenType { get; set; }

        public AllianceScopes AllianceScopesFlags { get; set; }
        public AssetScopes AssetScopesFlags { get; set; }
        public BookmarkScopes BookmarkScopesFlags { get; set; }
        public CalendarScopes CalendarScopesFlags { get; set; }
        public CharacterScopes CharacterScopesFlags { get; set; }
        public CloneScopes CloneScopesFlags { get; set; }
        public ContractScopes ContractScopesFlags { get; set; }
        public CorporationScopes CorporationScopesFlags { get; set; }
        public FittingScopes FittingScopesFlags { get; set; }
        public FleetScopes FleetScopesFlags { get; set; }
        public IndustryScopes IndustryScopesFlags { get; set; }
        public KillmailScopes KillmailScopesFlags { get; set; }
        public LocationScopes LocationScopesFlags { get; set; }
        public MailScopes MailScopesFlags { get; set; }
        public MarketScopes MarketScopesFlags { get; set; }
        public PlanetScopes PlanetScopesFlags { get; set; }
        public SearchScopes SearchScopesFlags { get; set; }
        public SkillScopes SkillScopesFlags { get; set; }
        public UiScopes UiScopesFlags { get; set; }
        public UniverseScopes UniverseScopesFlags { get; set; }
        public WalletScopes WalletScopesFlags { get; set; }
    }
}
