using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalSkills
    {
        private IWebClient WebClient { get; }

        public InternalSkills(IWebClient webClient)
        {
            WebClient = webClient ?? new WebClient();
        }

        public void GetSkillQueue(SsoLogicToken token)
        {
            if (!token.ScopeList.Contains(Scopes.esi_skills_read_skillqueue_v1))
            {
                throw new ESIException("This token does not have esi-skills.read_skillqueue.v1");
            }


        }
    }
}
