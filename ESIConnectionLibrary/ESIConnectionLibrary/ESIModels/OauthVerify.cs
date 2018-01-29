using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class OauthVerify
    {
        [JsonProperty(PropertyName = "CharacterID")]
        public int CharacterId { get; set; }

        public string CharacterName { get; set; }

        public DateTime ExpiresOn { get; set; }

        public string Scopes { get; set; }

        public string TokenType { get; set; }

        public string CharacterOwnerHash { get; set; }
    }
}
