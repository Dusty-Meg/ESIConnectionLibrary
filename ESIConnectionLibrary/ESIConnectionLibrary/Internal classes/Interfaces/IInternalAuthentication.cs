using System;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalAuthentication
    {
        SsoToken MakeToken(string code, string evessokey, Guid userId);
        Task<SsoToken> MakeTokenAsync(string code, string evessokey, Guid userId);
        SsoToken RefreshToken(SsoToken token, string evessokey);
        Task<SsoToken> RefreshTokenAsync(SsoToken token, string evessokey);
    }
}