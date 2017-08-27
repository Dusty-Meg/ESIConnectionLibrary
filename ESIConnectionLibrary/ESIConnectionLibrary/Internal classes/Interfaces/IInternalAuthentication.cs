using System;
using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalAuthentication
    {
        SsoToken MakeToken(string code, string evessokey, Guid userId);
        SsoToken RefreshToken(SsoToken token, string evessokey);
    }
}