using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalCorporations : IInternalCorporations
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalCorporations(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CorporationRolesMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public IList<CorporationsRoles> GetCorporationRoles(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CorporationsGetRoles(corporationId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiCorporationsRoles> esiCorporationsRoles = JsonConvert.DeserializeObject<IList<EsiCorporationsRoles>>(esiRaw);

            return _mapper.Map<IList<EsiCorporationsRoles>, IList<CorporationsRoles>>(esiCorporationsRoles);
        }
    }
}
