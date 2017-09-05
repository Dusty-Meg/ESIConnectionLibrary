using System;
using System.Collections.Generic;

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
        public string Scopes { get; set; }
        public Scopes ScopesFlags { get; set; }
        public IList<Scopes> ScopeList { get; set; }
        public TokenType TokenType { get; set; }
    }
}
