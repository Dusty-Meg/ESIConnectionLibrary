using System;
// ReSharper disable InconsistentNaming

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum SkillScopes : long
    {
        None = 0L,
        esi_skills_read_skillqueue_v1 = 1L << 1,
        esi_skills_read_skills_v1 = 1L << 2,
    }
}