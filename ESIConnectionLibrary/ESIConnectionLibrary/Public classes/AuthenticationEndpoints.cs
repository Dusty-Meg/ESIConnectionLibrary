using System;
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

        public SsoToken CreateToken(string code, string evessokey, Guid userId)
        {
            return _internalAuthentication.MakeToken(code, evessokey, userId);
        }
    }
}
