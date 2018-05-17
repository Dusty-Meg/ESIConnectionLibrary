using System;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class AuthenticationEndpoints : IAuthenticationEndpoints
    {
        private readonly IInternalAuthentication _internalAuthentication;

        public AuthenticationEndpoints(string userAgent)
        {
            _internalAuthentication = new InternalAuthentication(null, userAgent);
        }

        public SsoToken CheckToken (SsoToken token, string evessokey)
        {
            if (DateTime.UtcNow.CompareTo(token.ExpiresIn) == 1)
            {
                token = _internalAuthentication.RefreshToken(token, evessokey);
            }

            return token;
        }

        public async Task<SsoToken> CheckTokenAsync(SsoToken token, string evessokey)
        {
            if (DateTime.UtcNow.CompareTo(token.ExpiresIn) == 1)
            {
                token = await _internalAuthentication.RefreshTokenAsync(token, evessokey);
            }

            return token;
        }

        public SsoToken CreateToken(string code, string evessokey, Guid userId)
        {
            return _internalAuthentication.MakeToken(code, evessokey, userId);
        }

        public async Task<SsoToken> CreateTokenAsync(string code, string evessokey, Guid userId)
        {
            return await _internalAuthentication.MakeTokenAsync(code, evessokey, userId);
        }

        public void RevokeToken(string evessokey, string token, RevokeTokenType type)
        {
            _internalAuthentication.RevokeToken(evessokey, token, type);
        }

        public async Task RevokeTokenAsync(string evessokey, string token, RevokeTokenType type)
        {
            await _internalAuthentication.RevokeTokenAsync(evessokey, token, type);
        }
    }
}
