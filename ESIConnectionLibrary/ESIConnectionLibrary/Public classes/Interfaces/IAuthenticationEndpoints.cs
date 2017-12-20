using System;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface IAuthenticationEndpoints
    {
        SsoToken CheckToken(SsoToken token, string evessokey);
        Task<SsoToken> CheckTokenAsync(SsoToken token, string evessokey);
        SsoToken CreateToken(string code, string evessokey, Guid userId);
        Task<SsoToken> CreateTokenAsync(string code, string evessokey, Guid userId);
    }
}