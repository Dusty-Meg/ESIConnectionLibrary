using System;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface IAuthenticationEndpoints
    {
        SsoToken CheckToken(SsoToken token, string evessokey);
        SsoToken CreateToken(string code, string evessokey, Guid userId);
    }
}