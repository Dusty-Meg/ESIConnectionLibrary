using System;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class AuthenticationEndpoints
    {
        private IInternalAuthentication InternalAuthentication { get; }

        public AuthenticationEndpoints()
        {
            InternalAuthentication = new InternalAuthentication(null);
        }

        public SsoLogicToken CheckToken(SsoLogicToken token, string evessokey)
        {
            if (DateTime.UtcNow.CompareTo(token.ExpiresIn) == 1)
            {
                token = InternalAuthentication.RefreshToken(token, evessokey);
            }

            return token;
        }

        public SsoLogicToken CreateToken(string code, string evessokey, Guid userId)
        {
            return InternalAuthentication.MakeToken(code, evessokey, userId);
        }
    }
}
