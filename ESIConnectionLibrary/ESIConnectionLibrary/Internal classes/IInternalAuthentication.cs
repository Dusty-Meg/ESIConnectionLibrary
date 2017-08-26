using System;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalAuthentication
    {
        SsoLogicToken MakeToken(string code, string evessokey, Guid userId);
        SsoLogicToken RefreshToken(SsoLogicToken token, string evessokey);
    }
}